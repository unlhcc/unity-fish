/*
 * Fish movement handler.
*/

using UnityEngine;
using System.Collections;

[SelectionBase]
public class FishMovement : MonoBehaviour {
	
	float ZONE_ONE_DIST = 2f;
	public float ZONE_TWO_DIST = 10f;
	public float ZONE_THREE_DIST = 20f;

	public float swimSpeed = 4f;
	public float turnSpeed = 9f;

	FishData data;
	Rigidbody rb;
	
	float xRot=0;
	float yRot=0;

	public GameObject leaderFish;
	GameObject tank;
	Vector3 tankCenter;
	float tankSphereDistance;
	float cornerScale = 0.5f;

	void Awake(){
		tank = GameObject.Find ("tank");
		tankCenter = tank.transform.Find ("center").transform.position;
		tankSphereDistance = Vector3.Distance (tankCenter, tank.transform.Find ("corner").transform.position) * cornerScale;
		swimSpeed = tank.transform.localScale.x * swimSpeed;
		turnSpeed = tank.transform.localScale.x * turnSpeed;
		ZONE_ONE_DIST = tank.transform.localScale.x * ZONE_ONE_DIST;
		ZONE_TWO_DIST = tank.transform.localScale.x * ZONE_TWO_DIST;
		ZONE_THREE_DIST = tank.transform.localScale.x * ZONE_THREE_DIST;
		data = GetComponent<FishData> ();
		rb = GetComponent<Rigidbody> ();
		leaderFish = GameObject.Find (data.school);
	}

	//moves the fish in a random direction, but within rotational bounds.
	void MoveRandom(){
		if (tankSphereDistance < Vector3.Distance (transform.position, tankCenter)) {
			transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.LookRotation (tankCenter - transform.position), Time.deltaTime / turnSpeed);
		} else {
			RaycastHit hitLeft;
			RaycastHit hitRight;
			RaycastHit hitUp;
			RaycastHit hitDown;
			Vector3 direction = transform.forward;
			Vector3 left = Quaternion.AngleAxis (-5, transform.up) * direction;
			Vector3 right = Quaternion.AngleAxis (5, transform.up) * direction;
			Vector3 up = Quaternion.AngleAxis (-5, transform.right) * direction;
			Vector3 down = Quaternion.AngleAxis (5, transform.right) * direction;
			Debug.DrawRay (transform.position, left * 5 * tank.transform.localScale.x, Color.yellow);
			Debug.DrawRay (transform.position, right * 5 * tank.transform.localScale.x, Color.yellow);
			Debug.DrawRay (transform.position, up * 5 * tank.transform.localScale.x, Color.blue);
			Debug.DrawRay (transform.position, down * 5 * tank.transform.localScale.x, Color.red);
			bool hit1 = Physics.Raycast (transform.position, left, out hitLeft, 5 * tank.transform.localScale.x);
			bool hit2 = Physics.Raycast (transform.position, right, out hitRight, 5 * tank.transform.localScale.x);
			bool hit3 = Physics.Raycast (transform.position, up, out hitUp, 5 * tank.transform.localScale.x);
			bool hit4 = Physics.Raycast (transform.position, down, out hitDown, 5 * tank.transform.localScale.x);
			if (hit1 || hit2) {
				float angleLeft = Mathf.Rad2Deg * (Mathf.Acos (Vector3.Dot (left, hitLeft.normal)));
				float angleRight = Mathf.Rad2Deg * (Mathf.Acos (Vector3.Dot (right, hitRight.normal)));
				//Debug.Log ("left="+angleLeft+", right="+angleRight);
				if (angleLeft > angleRight) {
					yRot = 2;
				} else if (hitLeft.collider != hitRight.collider) {
					yRot = 0;
				} else {
					yRot = -2;
				}
			}else{
				yRot = 0;
			} if(hit3 || hit4){
				float angleUp = Mathf.Rad2Deg * (Mathf.Acos (Vector3.Dot (up, hitUp.normal)));
				float angleDown = Mathf.Rad2Deg * (Mathf.Acos (Vector3.Dot (down, hitDown.normal)));
				//Debug.Log ("left="+angleLeft+", right="+angleRight);
				if (angleUp > angleDown) {
					xRot = 2;
				} else if (hitUp.collider != hitDown.collider) {
					xRot = 0;
				} else {
					xRot = -2;
				}
			}else{
				if (transform.rotation.eulerAngles.x > 40 && transform.rotation.eulerAngles.x <= 180) {
					xRot = -1;
				} else if (transform.rotation.eulerAngles.x < 320 && transform.rotation.eulerAngles.x > 180) {
					xRot = 1;
				}
			}

			transform.Rotate (new Vector3 (xRot, yRot, 0) * Time.deltaTime * turnSpeed, Space.Self);
			//transform.RotateAround (transform.position, Vector3.up, Time.deltaTime * turnSpeed * yRot);
		}
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
			transform.rotation = Quaternion.Slerp (transform.rotation, rotation, (turnSpeed/distance) * Time.deltaTime);
			transform.Translate (Vector3.forward * swimSpeed * Time.deltaTime);
		}
		else if (distance > ZONE_ONE_DIST && distance < ZONE_TWO_DIST) {//get into position
			transform.rotation = Quaternion.Slerp (transform.rotation, leaderFish.transform.rotation, (turnSpeed/distance) * Time.deltaTime);
			transform.Translate (Vector3.forward * swimSpeed * Time.deltaTime);
		}
		else if(distance < ZONE_ONE_DIST){
			transform.Translate (Vector3.forward * swimSpeed * Time.deltaTime * 0.01f);
		}
		else {
			MoveRandom();
		}
	}

	void Update () {
		rb.velocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero;

		if (!rb.useGravity) {//if the fish is alive and well
			if (data.isSchoolLeader || leaderFish == null) {//if the fish belongs to noschool or is the leader of its school
				MoveRandom ();
			} else {//if the fish is a follower of it's school
				MoveFollow ();
			}
			transform.Rotate (0, 0, -transform.rotation.eulerAngles.z);
		} else {//dead fish rolls onto it's side
			MoveDead ();
		}

	}
}
