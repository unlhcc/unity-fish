/*
 * retreaves and parses the xml data from the sandhills and red cluster.
 * parsing makes fish. clusters are leader fish and hosts are follower fish.
*/

using UnityEngine;
using System.Collections;
using System.Xml;
using System.IO;
using System.Net;
using System.Net.Sockets;

public class DataRetriever : MonoBehaviour {

	FishSpawner fishSpawner;
	
	string sandhillsURL = "129.93.244.197";
	int sandhillsPort = 8654;
	string redClusterURL = "129.93.239.169";
	int redClusterPort = 8651;

	int bytes;
	Socket soc;
	byte[] bytesReceived;
	string sandhillsXML = "test";
	string redClusterXML = "test";

	void Start () {
		fishSpawner = GetComponent<FishSpawner>();
		//InvokeRepeating ("GetXML",0,300);
		GetXML ();
	}

	string tcpConnect(string ip, int port){
		
		TcpClient tcp = new TcpClient(AddressFamily.InterNetwork);
		tcp.Connect(IPAddress.Parse(ip), port);
		
		StreamReader data = new StreamReader(tcp.GetStream());
		
		string output = data.ReadToEnd ();
		
		data.Close();
		tcp.Close ();

		return output;
	}
	
	void GetXML(){

		sandhillsXML = tcpConnect (sandhillsURL, sandhillsPort);
		redClusterXML = tcpConnect (redClusterURL, redClusterPort);

		
		/*
		Debug.Log("Writing Data to Files...");
		File.WriteAllText ("Data/sandhllsXML.txt",sandhillsXML);
		File.WriteAllText ("Data/redClusterXML.txt",redClusterXML);
		Debug.Log("Finished Writing Data!");
		*/
		
		//sandhillsXML = File.ReadAllText ("Data/sandhllsXML.txt");
		//redClusterXML = File.ReadAllText ("Data/redClusterXML.txt");

		ParseXML (sandhillsXML);		
		ParseXML (redClusterXML);


	}

	void ParseXML(string xmlInput){
		XmlDocument doc = new XmlDocument ();
		doc.LoadXml (xmlInput);
		XmlNodeList ganglias = doc.GetElementsByTagName ("GANGLIA_XML");
		foreach(XmlNode ganglia in ganglias){
			/*
			ganglia.Attributes["VERSION"].Value;
			ganglia.Attributes["SOURCE"].Value;
			*/
			XmlNodeList gangChildren = ganglia.ChildNodes;
			foreach(XmlNode gangChild in gangChildren){
				/*if(gangChild.Name == "GRID"){
					ParseGrid(gangChild);
				}else */
				if(gangChild.Name == "CLUSTER"){
					ParseCluster(gangChild);
				}
				/*else if(gangChild.Name == "HOST"){
					ParseHost(gangChild);
				}*/
			}
		}
	}

	void ParseGrid(XmlNode grid){
		/*grid.Attributes["NAME"].Value;
		grid.Attributes["AUTHORITY"].Value;
		grid.Attributes["LOCALTIME"].Value;*/

		foreach(XmlNode gridChild in grid.ChildNodes){
			if(gridChild.Name == "CLUSTER"){
				ParseCluster(gridChild);
			}else if(gridChild.Name == "GRID"){
				ParseGrid(gridChild);
			}
		}
	}

	void ParseCluster(XmlNode cluster){
		string clusterName = cluster.Attributes ["NAME"].Value;
		GameObject fish = GameObject.Find (clusterName);
		if (fish == null) {
			fish = fishSpawner.SpawnFish (clusterName, true);
			//create new fish
		}
		FishData fishData = fish.GetComponent<FishData>();

		/*cluster.Attributes["OWNER"].Value;
		cluster.Attributes["LATLONG"].Value;
		cluster.Attributes["URL"].Value;
		cluster.Attributes["LOCALTIME"].Value;*/

		foreach(XmlNode host in cluster.ChildNodes){
			ParseHost(host, fishData.school);
		}
	}

	void ParseHost(XmlNode host, string clusterName){
		string hostName = host.Attributes ["NAME"].Value;
		GameObject fish = GameObject.Find (hostName);
		if(fish == null){
			fish = fishSpawner.SpawnFish (clusterName, false);
			fish.name = hostName;
		}
		FishData fishData = fish.GetComponent<FishData>();
		/*
		host.Attributes["IP"].Value;
		host.Attributes["LOCATION"].Value;
		host.Attributes["TAGS"].Value;
		host.Attributes["REPORTED"].Value;
		host.Attributes["TN"].Value;
		host.Attributes["TMAX"].Value;
		host.Attributes["DMAX"].Value;
		host.Attributes["GMOND_STARTED"].Value;
		 */

		foreach(XmlNode metric in host.ChildNodes){
			ParseMetric(metric,fishData);
		}
	}

	void ParseMetric(XmlNode metric,FishData fishData){
		string metricName = metric.Attributes["NAME"].Value;
		if(metricName.Equals("procstat_gmond_mem")){
			fishData.memoryUtilization = int.Parse( metric.Attributes["VAL"].Value);

		}else if(metricName.Equals("load_one")){
			fishData.avgLoad = float.Parse( metric.Attributes["VAL"].Value);
			if(fishData.avgLoad != 0 && fishData.cpuCount != 0){
				fishData.Resize ();
			}
		}else if(metricName.Equals("cpu_num")){
			fishData.cpuCount = int.Parse( metric.Attributes["VAL"].Value);
			if(fishData.avgLoad != 0 && fishData.cpuCount != 0){
				fishData.Resize ();
			}
		}

		/*metric.Attributes["NAME"].Value;
			metric.Attributes["VAL"].Value;
			metric.Attributes["TYPE"].Value;
			metric.Attributes["UNITS"].Value;
			metric.Attributes["TN"].Value;
			metric.Attributes["TMAX"].Value;
			metric.Attributes["DMAX"].Value;
			metric.Attributes["SLOPE"].Value;
			metric.Attributes["SOURCE"].Value;*/

		/*
		foreach(XmlNode extraData in metric.ChildNodes){
			ParseExtraData(extraData);
		}*/
	}

	void ParseExtraData(XmlNode extraData){
		/*
		foreach(XmlNode extraElem in extraData){
			string extraElemName = extraElem.Attributes["NAME"].Value;
			if(extraElemName.Equals("GROUP")){
				extraElem.Attributes["VAL"].Value;
			}else if(extraElemName.Equals("DESC")){
				extraElem.Attributes["VAL"].Value;
			}else if(extraElemName.Equals("TITLE")){
				extraElem.Attributes["VAL"].Value;
			}
		}
		*/
	}
}
