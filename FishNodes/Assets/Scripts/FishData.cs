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

	void Awake(){
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody> ();
		mat = GetComponentInChildren<Renderer> ().material;
		SetColor (Color.cyan);
	}

	void Update (){
		if(flash && !isDead){
			float t = Mathf.PingPong(Time.time,1f);
			mat.color = Color.Lerp(fishColor,Color.yellow,t);
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

	public void Resize(){
		float scalePercentage = avgLoad / cpuCount;
		if (scalePercentage < 0.01f) {
			scalePercentage = 0.01f;
			flash = false;
		} else if (scalePercentage > 1) {
			scalePercentage = 1f;
			flash = true;
		} else {
			flash = false;
		}
		scalePercentage = scalePercentage * 20;
		transform.localScale = new Vector3(scalePercentage,scalePercentage,scalePercentage);
	}
}
