/*
 * Allows for spawning of fish.
*/

using UnityEngine;
using System.Collections;

public class FishSpawner : MonoBehaviour {

	public Object fishPrefab;
	void Update(){
		//press keycodes to spawn fish
		if(Input.GetKeyDown(KeyCode.U)){//sand leader
			GameObject fish = SpawnFish("sandhills", true);
			fish.GetComponent<FishData>().memoryUtilization = 12345678;
		}if(Input.GetKeyDown(KeyCode.O)){//red leader
			SpawnFish("red-workers", true);
		}
		if(Input.GetKeyDown(KeyCode.I)){//spwan 50 sand followers
			for(int i=0; i<50; i++){
				SpawnFish("sandhills", false);
			}
		}
		if(Input.GetKeyDown(KeyCode.P)){//spawn 50 red followers
			for(int i=0; i<50; i++){
				SpawnFish("red-workers", false);
			}
		}
		if(Input.GetKeyDown(KeyCode.L)){//kill all leader fish
			GameObject[] allFish = GameObject.FindGameObjectsWithTag("fish");
			foreach(GameObject fish in allFish){
				if(fish.GetComponent<FishData>().isSchoolLeader){
					Destroy(fish);
				}
			}
		}
		if(Input.GetKeyDown(KeyCode.K)){//kill ALL fish
			GameObject[] allFish = GameObject.FindGameObjectsWithTag("fish");
			foreach(GameObject fish in allFish){
				Destroy(fish);
			}
		}
		if(Input.GetKeyDown(KeyCode.D)){//hide all leader fish
			GameObject[] allFish = GameObject.FindGameObjectsWithTag("fish");
			foreach(GameObject fish in allFish){
				if(fish.GetComponent<FishData>().isSchoolLeader){
						fish.gameObject.transform.localScale = new Vector3(0,0,0);
						
					}
				}
			}
			if(Input.GetKeyDown(KeyCode.F)){//show all leader fish
				GameObject[] allFish = GameObject.FindGameObjectsWithTag("fish");
				foreach(GameObject fish in allFish){
					if(fish.GetComponent<FishData>().isSchoolLeader){
							fish.gameObject.transform.localScale = new Vector3(20,20,20);
							
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
        Vector3 RandomDrop = new Vector3(Random.Range(-40.0f, 40.0f), Random.Range(42.0f, 45.0f), Random.Range(-15.0f, 15.0f));
        Quaternion RandomRotation = Quaternion.Euler(Random.Range(45f, 135.0f), Random.Range(0f, 360.0f), Random.Range(0f, 360.0f));
		GameObject fish = Instantiate (fishPrefab, RandomDrop, RandomRotation) as GameObject;

		FishData fd = fish.GetComponent<FishData> ();
		FishMovement fm = fish.GetComponent<FishMovement>();
		fd.school = leader;
		if (isLeader) {
			fd.name = leader;
			fd.isSchoolLeader = isLeader;
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
		if (leader.Equals ("crane")) {
			if(isLeader){
				fd.fishColor = new Color(0f,0f,0.3f);
			}else{
				fd.fishColor = Color.blue;
			}
		} else if (leader.Equals ("red-workers")) {
			if(isLeader){
				fd.fishColor = new Color(0.3f,0f,0f);
			}else{
				fd.fishColor = Color.red;
			}
		}
        else if (leader.Equals("rhino"))
        {
            if (isLeader){
                fd.fishColor = new Color(0.3f, 0.3f, 0f);
            }else{
                fd.fishColor = Color.yellow;
            }
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
