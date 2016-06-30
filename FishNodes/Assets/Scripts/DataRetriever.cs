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

public class DataRetriever : MonoBehaviour
{

	FishSpawner fishSpawner;
	string sandhillsURL = "129.93.244.197";
	int sandhillsPort = 8654;
	string redClusterURL = "129.93.239.169";
	int redClusterPort = 8651;

	bool fishLimiter = true;

	void Start ()
	{
		fishSpawner = GetComponent<FishSpawner> ();
		//InvokeRepeating ("GetXML", 1, 600);
		//GetXML ();
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

	/*string tcpConnect (string ip, int port)
	{
		TcpClient tcp = new TcpClient (AddressFamily.InterNetwork);
		tcp.Connect (IPAddress.Parse (ip), port);
		
		StreamReader data = new StreamReader (tcp.GetStream ());
		
		string output = data.ReadToEnd ();
		
		data.Close ();
		tcp.Close ();

		return output;
	}
	*/
	public void GetXML ()
	{
		/*
		sandhillsXML = tcpConnect (sandhillsURL, sandhillsPort);
		redClusterXML = tcpConnect (redClusterURL, redClusterPort);

		File.WriteAllText ("sandhillsXML.xml", sandhillsXML);
		File.WriteAllText ("redClusterXML.xml", redClusterXML);
		*/

		StartCoroutine (ParseXML ("sandhillsXML.xml", sandhillsURL, sandhillsPort));
		StartCoroutine (ParseXML ("redClusterXML.xml", redClusterURL, redClusterPort));
		/*
		File.Delete ("sandhillsXML.xml");
		File.Delete ("redClusterXML.xml");
		*/
	}

	IEnumerator ParseXML (string xmlInput, string url, int port){

		GameObject loadingFish;
		try{
			loadingFish = GameObject.Find ("[CameraRig]").transform.FindChild ("GUIcanvas").FindChild ("LoadingFish").gameObject;
		}catch{
			loadingFish = new GameObject ();
			loadingFish.name = "loadingFish";
		}

		Process downloader = new Process ();
		downloader.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
		downloader.StartInfo.FileName = "Downloader.exe";
		downloader.StartInfo.Arguments = xmlInput + " " + url + " " + port;
		downloader.Start();
		while(!downloader.HasExited){
			loadingFish.SetActive (true);
			yield return null;
		}

		GameObject[] listOfFish = GameObject.FindGameObjectsWithTag ("fish");

		int fishCount = 0;

		XmlTextReader reader = new XmlTextReader (xmlInput);
		if (reader.ReadToFollowing ("CLUSTER")) {
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
			clusterFish.GetComponent<FishData> ().Resize (transform.localScale.x*(30));
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
					fishData.Resize(transform.localScale.x*(24));
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
		reader.Close ();
		loadingFish.SetActive (false);
		if(loadingFish.name.Equals("loadingFish")){
			DestroyImmediate (loadingFish);
		}
	}
}
