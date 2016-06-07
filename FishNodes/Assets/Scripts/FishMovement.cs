/*
 * Fish movement handler.
*/

using UnityEngine;
using System.Collections;

[SelectionBase]
public class FishMovement : MonoBehaviour {
	
	float ZONE_ONE_DIST = 2f;
	float ZONE_TWO_DIST = 20f;
	float ZONE_THREE_DIST = 40f;

	public float swimSpeed = 3f;
	public float turnSpeed = 3f;

	FishData data;
	
	float xRot;
	float yRot;
	float zRot;

	public GameObject leaderFish;

	void Start(){
		data = GetComponent<FishData> ();
		leaderFish = GameObject.Find (data.school);
	}

	//moves the fish in a random direction, but within rotational bounds.
	void MoveRandom(){
		if (transform.rotation.eulerAngles.z > 15 && transform.rotation.eulerAngles.z <= 180) {
			zRot = -1;
		} else if (transform.rotation.eulerAngles.z < 345 && transform.rotation.eulerAngles.z > 180) {
			zRot = 1;
		} else {
			zRot = Random.Range (-1, 1);
		}
		
		if (transform.rotation.eulerAngles.x > 40 && transform.rotation.eulerAngles.x <= 180) {
			xRot = -1;
		} else if (transform.rotation.eulerAngles.x < 320 && transform.rotation.eulerAngles.x > 180) {
			xRot = 1;
		} else {
			xRot = Random.Range (-1, 1);
		}
		yRot = Random.Range (-1, 1);
		transform.Rotate (new Vector3 (xRot, yRot, zRot) * Time.deltaTime * turnSpeed);
		transform.Translate (Vector3.forward * swimSpeed * Time.deltaTime);
	}

	//how the fish should move if dead(aka float to the top).
	void MoveDead(){
		//turn on side without moving
		if ((transform.rotation.eulerAngles.z < 80 && transform.rotation.eulerAngles.z >= 0)
		    || (transform.rotation.eulerAngles.z < 260 && transform.rotation.eulerAngles.z >= 180)) {
			transform.Rotate (new Vector3 (0, 0, 1) * Time.deltaTime * turnSpeed);
		} else if ((transform.rotation.eulerAngles.z < 180 && transform.rotation.eulerAngles.z >= 100)
		           || (transform.rotation.eulerAngles.z < 360 && transform.rotation.eulerAngles.z >= 280)) {
			transform.Rotate (new Vector3 (0, 0, -1) * Time.deltaTime * turnSpeed);
		}
	}

	//how the fish should follow the leader fish.
	void MoveFollow(){
		float distance= Vector3.Distance(leaderFish.transform.position,transform.position);
		if (distance > ZONE_TWO_DIST && distance < ZONE_THREE_DIST) {//need to get closer
			Quaternion rotation = Quaternion.LookRotation (leaderFish.transform.position - transform.position);
			transform.rotation = Quaternion.Slerp (transform.rotation, rotation, (turnSpeed) * Time.deltaTime);
			transform.Translate (Vector3.forward * swimSpeed * Time.deltaTime);
		}
		else if (distance > ZONE_ONE_DIST && distance < ZONE_TWO_DIST) {//get into position
			transform.rotation = Quaternion.Slerp (transform.rotation, leaderFish.transform.rotation, (turnSpeed/distance) * Time.deltaTime);
		}
		else if(distance < ZONE_ONE_DIST){
			transform.Translate (Vector3.forward * swimSpeed * Time.deltaTime * 0.01f);
		}
		else {
			MoveRandom();
		}
	}

	void Update () {
		if (!data.isDead) {//if the fish is alive and well
			if(data.isSchoolLeader || leaderFish == null){//if the fish belongs to noschool or is the leader of its school
				MoveRandom();
			}else{//if the fish is a follower of it's school
				MoveFollow();
			}
		} else {//dead fish rolls onto it's side
			MoveDead();
		}
	}
}
