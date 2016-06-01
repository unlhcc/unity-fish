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
	Color fishColor;
	public bool isSchoolLeader = false;
	public string school = null;

	void Awake(){
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody> ();
		mat = GetComponentInChildren<Renderer> ().material;
		SetColor (Color.cyan);
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
		fishColor = color;
		mat.color = color;
	}
}
