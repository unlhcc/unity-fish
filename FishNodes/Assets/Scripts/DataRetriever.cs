/*
 * retreaves and parses the xml data from the sandhills and red cluster.
 * parsing makes fish. clusters are leader fish and hosts are follower fish.
*/
using UnityEngine;
using System.Collections;
using System.Diagnostics;
using System.Xml;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System;
using System.Collections.Generic;

public class DataRetriever : MonoBehaviour
{

	FishSpawner fishSpawner;
	string craneURL = "129.93.227.114";
	int cranePort = 8655;
    string rhinoURL = "129.93.241.17";
    int rhinoPort = 8649;
    string redClusterURL = "129.93.244.198";
	int redClusterPort = 8654;

	public bool fishLimiter = true;
	public bool fishUpdater = true;
	public float fishScaleAmount = 1;

	Dictionary<string,Color> statusColors = new Dictionary<string,Color>(){
		{"Major Outage",new Color(1f,0f,0f)},
		{"Partial Outage",new Color(1f,.8f,0f)},
		{"Operational",new Color(0f,1f,0f)},
		{"Maintenance",new Color(1f,0.5f,0f)}
	};

	void Start ()
	{
		fishSpawner = GetComponent<FishSpawner> ();
		if (fishUpdater) {
			InvokeRepeating ("GetXML", 1, 600);
		} else {
			GetXML ();
		}
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.R)){
			GetXML();
		}
		if(Input.GetKeyDown(KeyCode.E)){
			fishLimiter = !fishLimiter;
			UnityEngine.Debug.Log ("Limit number of fish = "+fishLimiter);
		}
	}

	string tcpConnect (string ip, int port)
	{
		TcpClient tcp = new TcpClient (AddressFamily.InterNetwork);
		tcp.Connect (IPAddress.Parse (ip), port);
		
		StreamReader data = new StreamReader (tcp.GetStream ());
		
		string output = data.ReadToEnd ();
		
		data.Close ();
		tcp.Close ();

		return output;
	}

	public void GetXML ()
	{
		StartCoroutine (ParseXML ("craneXML.xml", craneURL, cranePort));
        StartCoroutine(ParseXML("rhinoXML.xml", rhinoURL, rhinoPort));
        StartCoroutine (ParseXML ("redClusterXML.xml", redClusterURL, redClusterPort));
		/*
		File.Delete ("sandhillsXML.xml");
		File.Delete ("redClusterXML.xml");
		*/
		UpdateStatus();
	}

	public string getStatusData(string Cluster){
		string StatusURL = "https://status.hcc.unl.edu";
		string result;
		string tempHold = "";
		Dictionary<string,string> vault = new Dictionary<string,string>();
		using (WebClient client = new WebClient())
		{
			result = client.DownloadString(StatusURL);
		}
		string[] lines = result.Split('\n');
		int tempIndex = 0;
		foreach (string s in lines){
			UnityEngine.Debug.Log(tempIndex);
			if (tempIndex > 1){
			if (s.Contains("serviceList__status") ||  lines[tempIndex - 1].Contains("serviceList__name"))
			{
				if (s.Contains("status")){
					tempHold = s.Split('<')[2].Split('>')[1];
				}else{
					vault.Add(s.Replace("          ",""),tempHold);
				}
			} 
		}tempIndex += 1;}
		return vault[Cluster];
	}

	public void UpdateStatus()
	{
		string tempVal;
		GameObject CraneStat = GameObject.Find("CraneStatus");
		CraneStat.GetComponent<TextMesh>().text = getStatusData("Crane");
		CraneStat.GetComponent<TextMesh>().color = statusColors[getStatusData("Crane")];
		GameObject RedStat = GameObject.Find("RedStatus");
		RedStat.GetComponent<TextMesh>().text = getStatusData("Red");
		RedStat.GetComponent<TextMesh>().color = statusColors[getStatusData("Red")];
		GameObject RhinoStat = GameObject.Find("RhinoStatus");
		RhinoStat.GetComponent<TextMesh>().text = getStatusData("Rhino");
		RhinoStat.GetComponent<TextMesh>().color = statusColors[getStatusData("Rhino")];
		//tempVal.text = "CAKE";
		
	}

	IEnumerator ParseXML (string xmlInput, string url, int port){
		
		GameObject loadingFish;
		try {
			loadingFish = GameObject.Find ("[CameraRig]").transform.Find ("GUIcanvas").Find ("LoadingFish").gameObject;
		} catch {
			loadingFish = new GameObject ();
			loadingFish.name = "loadingFish";
		}

		if (File.Exists ("Downloader.exe") && (Application.platform == RuntimePlatform.LinuxPlayer || Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)) {
			Process downloader = new Process ();
			downloader.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			if(Application.platform == RuntimePlatform.LinuxPlayer){
				downloader.StartInfo.FileName = "mono";
				downloader.StartInfo.Arguments = "Downloader.exe " + xmlInput + " " + url + " " + port;
			}else{
				downloader.StartInfo.FileName = "Downloader.exe";
				downloader.StartInfo.Arguments = xmlInput + " " + url + " " + port;
			}
			downloader.Start ();
			while (!downloader.HasExited) {
				loadingFish.SetActive (true);
				yield return null;
			}
		} else {
			try{
				string xml = tcpConnect (url, port);
				try{
					File.WriteAllText (xmlInput, xml);
				}catch(IOException ioe){
					//File.AppendAllText("errorLog.txt", "\n" + ioe.ToString() + "\n");
					UnityEngine.Debug.Log(ioe.ToString());
				}
			}catch(SocketException se){
				//UnityEngine.Debug.LogException (se);
				//File.AppendAllText("errorLog.txt", "\n" + se.ToString() + "\n");
				UnityEngine.Debug.Log(se.ToString());
			}
		}

		GameObject[] listOfFish = GameObject.FindGameObjectsWithTag ("fish");

		int fishCount = 0;

		XmlTextReader reader = null;
		try{
			reader = new XmlTextReader (xmlInput);
		}catch(FileNotFoundException fnfe){
			//UnityEngine.Debug.LogException (e);
			//File.AppendAllText("errorLog.txt", "\n" + fnfe.ToString() + "\n");
			UnityEngine.Debug.Log(fnfe.ToString());
		}
		if (reader != null && reader.ReadToFollowing ("CLUSTER")) {
			string clusterName = reader.GetAttribute ("NAME");

			foreach (GameObject fish in listOfFish) {
				if(!fish.GetComponent<FishData>().isSchoolLeader && fish.GetComponent<FishData>().school.Equals(clusterName)){
					fish.GetComponent<FishData> ().isDead = true;
				}
			}

			GameObject clusterFish = GameObject.Find (clusterName);
			if (clusterFish == null) {
				clusterFish = fishSpawner.SpawnFish (clusterName, true);
				//create new leader fish
			} else {
				clusterFish.GetComponent<FishData> ().ReviveFish ();
			}
			clusterFish.GetComponent<FishData> ().Resize (transform.localScale.x*(30)*fishScaleAmount);
			if (reader.ReadToDescendant ("HOST")) {
				do {
					string hostName = reader.GetAttribute ("NAME");
					GameObject fish = GameObject.Find (hostName);
					if (fish == null) {
						fish = fishSpawner.SpawnFish (clusterName, false);
						fish.name = hostName;
						//create new follower fish
					} else {
						fish.GetComponent<FishData> ().ReviveFish ();
					}
					FishData fishData = fish.GetComponent<FishData> ();
					fishData.Resize(transform.localScale.x*(24)*fishScaleAmount);
					if (reader.ReadToDescendant ("METRIC")) {
						do {
							//set the follower fish's data
							string metricName = reader.GetAttribute ("NAME");
							if (metricName.Equals ("procstat_gmond_mem")) {
								fishData.memoryUtilization = int.Parse (reader.GetAttribute ("VAL"));
							
							} else if (metricName.Equals ("load_one")) {
								fishData.avgLoad = float.Parse (reader.GetAttribute ("VAL"));
								if (fishData.cpuCount != 0) {
									fishData.Resize ();
								}
							} else if (metricName.Equals ("cpu_num")) {
								fishData.cpuCount = int.Parse (reader.GetAttribute ("VAL"));
								if (fishData.cpuCount != 0) {
									fishData.Resize ();
								}
							}
						} while (reader.ReadToNextSibling("METRIC"));
					}
					fishCount++;
					yield return new WaitForFixedUpdate();
					yield return new WaitForFixedUpdate();
					yield return new WaitForFixedUpdate();
					if(fishLimiter && fishCount >= 50){
						break;
					}
				} while (reader.ReadToNextSibling("HOST"));
			}


			foreach (GameObject fish in listOfFish) {
				if(fish.GetComponent<FishData> ().isDead && fish.GetComponent<FishData>().school.Equals(clusterName)) {
					fish.GetComponent<FishData>().KillFish();
				}
			}

			FishData clusterData = clusterFish.GetComponent<FishData>();
			if(clusterData.isSchoolLeader){
				clusterData.GetNumberOfFish();
			}

		}
		if(reader != null){
			reader.Close ();
		}
		loadingFish.SetActive (false);
		if(loadingFish.name.Equals("loadingFish")){
			DestroyImmediate (loadingFish);
		}
	}
}
