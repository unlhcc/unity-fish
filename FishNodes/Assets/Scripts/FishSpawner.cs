/*
 * Allows for spawning of fish.
*/

using UnityEngine;
using System.Collections;

public class FishSpawner : MonoBehaviour {

	public Object fishPrefab;

	void Update(){
		//press keycodes to spawn fish
		if(Input.GetKeyDown(KeyCode.F)){//sand leader
			SpawnFish("sandhills", true);
		}if(Input.GetKeyDown(KeyCode.R)){//red leader
			SpawnFish("red-workers", true);
		}
		if(Input.GetKeyDown(KeyCode.L)){//spwan 50 sand followers
			for(int i=0; i<50; i++){
				SpawnFish("sandhills", false);
			}
		}
		if(Input.GetKeyDown(KeyCode.O)){//spawn 50 red followers
			for(int i=0; i<50; i++){
				SpawnFish("red-workers", false);
			}
		}
		if(Input.GetKeyDown(KeyCode.Y)){//kill all leader fish
			GameObject[] allFish = GameObject.FindGameObjectsWithTag("fish");
			foreach(GameObject fish in allFish){
				if(fish.GetComponent<FishData>().isSchoolLeader){
					Destroy(fish);
				}
			}
		}
	}

	/*
	 * creates a new fish and returns it.
	 * leader is the cluster's name
	 * isLeader defines if it is main fish that represents the cluster.
	 */
	public GameObject SpawnFish(string leader, bool isLeader){

		GameObject fish = Instantiate (fishPrefab, new Vector3 (transform.position.x + (Random.Range (-40, 40)* transform.lossyScale.z),
		                                                        transform.position.y + ((50 + Random.Range (-40, 40))* transform.lossyScale.z),
		                                                       transform.position.z + (Random.Range (-40, 40) * transform.lossyScale.z)),
		                               Quaternion.identity) as GameObject;

		FishData fd = fish.GetComponent<FishData> ();
		FishMovement fm = fish.GetComponent<FishMovement>();
		fd.school = leader;
		if (isLeader) {
			fd.name = leader;
			fd.isSchoolLeader = isLeader;
			fm.swimSpeed += 3f;
			fm.turnSpeed += 3f;
			GameObject[] allfish = GameObject.FindGameObjectsWithTag ("fish");
			foreach (GameObject followerFish in allfish) {
				if (followerFish.GetComponent<FishData> ().school.Equals (leader)) {
					followerFish.GetComponent<FishMovement> ().leaderFish = fish;
				}
				if (followerFish.name.Equals (leader) && followerFish != fish) {
					Destroy (followerFish);
				}
			}
		} else {
			fm.leaderFish = GameObject.Find(leader);
		}
		if (leader.Equals ("sandhills")) {
			fd.fishColor = Color.green;
		} else if (leader.Equals ("red-workers")) {
			fd.fishColor = Color.red;
		} else {
			fd.fishColor = Color.cyan;
		}
		fd.SetColor (fd.fishColor);
		return fish;
	}

	//utility function to destroy all fish
	void DestroyAllFish(){
		GameObject[] allfish = GameObject.FindGameObjectsWithTag ("fish");
		foreach(GameObject fish in allfish){
			Destroy(fish);
		}
	}

}
