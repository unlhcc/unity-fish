/*
 * Various data that needs to be shared between multipul script components of the fish.
*/
using UnityEngine;
using System.Collections;

public class FishData : MonoBehaviour {
	
	Material mat;
	Rigidbody rb;
	Animator anim;
	public bool isDead = false;
	public Color fishColor;
	public bool isSchoolLeader = false;
	public string school = null;
	public int memoryUtilization;
	public int cpuCount;
	public float avgLoad;
	public int fishSize = 1;
	bool flash = false;
	Vector3 origin = new Vector3(0,25,0);
	
	public int numberOfFollowers;
	public int numberOfLivingFollowers;
	public int numberOfDeadFollowers;

	void Awake(){
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody> ();
		mat = GetComponentInChildren<Renderer> ().material;
		SetColor (Color.cyan);
	}

	void Update (){
		if(flash && !isDead){
			float t = Mathf.PingPong(Time.time,1f);
			mat.color = Color.Lerp(fishColor,new Color(fishColor.r,fishColor.g,1),t);
		}
		float distance = Vector3.Distance (transform.position, origin);
		if (distance > 80) {
			transform.position = origin;
		}
	}
	
	public void KillFish(){
		anim.SetBool ("isSwimming", false);
		isDead = true;
		rb.useGravity = true;
		SetColor (Color.black);
	}

	public void ReviveFish(){
		anim.SetBool ("isSwimming", true);
		isDead = false;
		rb.useGravity = false;
		SetColor (fishColor);
	}

	public void SetColor(Color color){
		mat.color = color;
	}

	public string GetMemoryUtilizationFormated(){
		double temp = (memoryUtilization * 0.000001);
		string memUtilString = temp.ToString() + " GB";
		return memUtilString;
	}

	public void Resize(){
		float scalePercentage = avgLoad / cpuCount;
		if (scalePercentage < 0.25f) {
			scalePercentage = 0.25f;
			flash = false;
		} else if (scalePercentage > 1) {
			scalePercentage = 1.20f;
			flash = true;
		} else {
			flash = false;
		}
		scalePercentage = scalePercentage * 20;
		transform.localScale = new Vector3(scalePercentage,scalePercentage,scalePercentage);
	}
	
	public void GetNumberOfFish(){
		numberOfFollowers = 0;
		numberOfLivingFollowers = 0;
		numberOfDeadFollowers = 0;
		GameObject[] listOfFish = GameObject.FindGameObjectsWithTag ("fish");
		foreach (GameObject fish in listOfFish) {
			FishData data = fish.GetComponent<FishData>();
			if(data.school.Equals(school) && fish.transform != transform){
				numberOfFollowers++;
				if(data.isDead){
					numberOfDeadFollowers++;
				}else{
					numberOfLivingFollowers++;
				}
			}
		}
	}

}
