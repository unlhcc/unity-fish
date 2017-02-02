using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VRSelector : MonoBehaviour {

	GameObject Fish;

	GameObject FishName;

	GameObject LeaderData;
	Text WorkingNodes;
	Text DeadNodes;
	Text TotalNodes;

	GameObject FollowerData;
	Text MemoryUtilization;
	Text NumberCPU;
	Text LoadAverage;


	void Start(){
		FishName = transform.FindChild ("FishName").gameObject;

		LeaderData = FishName.transform.FindChild ("LeaderData").gameObject;
		WorkingNodes = LeaderData.transform.FindChild ("WorkingNodes").GetComponent<Text>();
		DeadNodes = LeaderData.transform.FindChild ("DeadNodes").GetComponent<Text>();
		TotalNodes = LeaderData.transform.FindChild ("TotalNodes").GetComponent<Text>();

		FollowerData = FishName.transform.FindChild ("FollowerData").gameObject;
		MemoryUtilization = FollowerData.transform.FindChild ("MemoryUtilization").GetComponent<Text>();
		NumberCPU = FollowerData.transform.FindChild ("NumberCPU").GetComponent<Text>();
		LoadAverage = FollowerData.transform.FindChild ("LoadAverage").GetComponent<Text>();
	}

	public void HideCanvas (){

		if(Fish != null){
			//Fish.GetComponentInChildren<Renderer>().material.shader = Shader.Find("Diffuse");
			Fish.transform.FindChild ("outline").GetComponent<SkinnedMeshRenderer>().enabled = false;
		}

		Color clear = Color.clear;

		TotalNodes.color = clear;
		WorkingNodes.color = clear;
		DeadNodes.color = clear;

		LeaderData.GetComponent<Text> ().color = clear;
		FollowerData.GetComponent<Text> ().color = clear;

		MemoryUtilization.color = clear;
		NumberCPU.color = clear;
		LoadAverage.color = clear;

		FishName.GetComponent<Text> ().color = clear;

	}


	public void SetCanvas(GameObject fish){

		if(Fish != null){
			//Fish.GetComponentInChildren<Renderer>().material.shader = Shader.Find("Diffuse");
			Fish.transform.FindChild ("outline").GetComponent<SkinnedMeshRenderer>().enabled = false;
		}

		Fish = fish;

		//Fish.GetComponentInChildren<Renderer>().material.shader = Shader.Find("Self-Illumin/Outlined Diffuse");
		Fish.transform.FindChild ("outline").GetComponent<SkinnedMeshRenderer>().enabled = true;

		//gameObject.SetActive (true);
		
		FishData fd = fish.GetComponent<FishData> ();

		if (fd.isSchoolLeader) {
			LeaderData.SetActive (true);
			FollowerData.SetActive (false);

			fd.GetNumberOfFish();

			TotalNodes.text = fd.numberOfFollowers.ToString();
			WorkingNodes.text = fd.numberOfLivingFollowers.ToString();
			DeadNodes.text = fd.numberOfDeadFollowers.ToString();

			TotalNodes.color = fd.fishColor;
			WorkingNodes.color = fd.fishColor;
			DeadNodes.color = fd.fishColor;

			LeaderData.GetComponent<Text> ().color = fd.fishColor;

		} else {
			LeaderData.SetActive (false);
			FollowerData.SetActive (true);

			MemoryUtilization.text = fd.GetMemoryUtilizationFormated();
			NumberCPU.text = fd.cpuCount.ToString();
			LoadAverage.text = fd.avgLoad.ToString();

			MemoryUtilization.color = fd.fishColor;
			NumberCPU.color = fd.fishColor;
			LoadAverage.color = fd.fishColor;

			FollowerData.GetComponent<Text> ().color = fd.fishColor;

		}
		FishName.GetComponent<Text> ().text = fish.name;
		FishName.GetComponent<Text> ().color = fd.fishColor;
	}

}
