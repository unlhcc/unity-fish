using UnityEngine;
using System.Collections;

public class FishApperanceChanger : MonoBehaviour {

	GameObject tank;
	float tankScale;

	void Start () {
		tank = GameObject.Find ("tank");
		tankScale = tank.transform.localScale.x;
	}

	void ChangeFishSize(int sizeModifer){
		GameObject[] allFish = GameObject.FindGameObjectsWithTag ("fish");
		foreach(GameObject fish in allFish){
			FishData fishData = fish.GetComponent<FishData>();
			fishData.baseScale += sizeModifer * tankScale;
			fishData.Resize();
		}
		Debug.Log(allFish[1].GetComponent<FishData>().baseScale);
	}
	
	void ChangeFishSpeed(int speedModifer){
		GameObject[] allFish = GameObject.FindGameObjectsWithTag ("fish");
		foreach(GameObject fish in allFish){
			FishMovement fishMove = fish.GetComponent<FishMovement>();
			fishMove.swimSpeed += speedModifer * tankScale;
		}
		Debug.Log(allFish[1].GetComponent<FishMovement>().swimSpeed);
	}

	void ChangeFishZone(int zoneModifer){
		GameObject[] allFish = GameObject.FindGameObjectsWithTag ("fish");
		foreach(GameObject fish in allFish){
			FishMovement fishMove = fish.GetComponent<FishMovement>();
			fishMove.ZONE_TWO_DIST += zoneModifer * tankScale;
			fishMove.ZONE_THREE_DIST += (zoneModifer*2);
		}
		Debug.Log(allFish[1].GetComponent<FishMovement>().ZONE_TWO_DIST +", "+ allFish[1].GetComponent<FishMovement>().ZONE_THREE_DIST );
	}

	void Update () {//change fish size
		if(Input.GetKeyDown(KeyCode.KeypadPlus)){
			ChangeFishSize(1);
		}if(Input.GetKeyDown(KeyCode.KeypadMinus)){
			ChangeFishSize(-1);
		}
		//change fish speed
		if(Input.GetKeyDown(KeyCode.Equals)){
			ChangeFishSpeed(1);
		}if(Input.GetKeyDown(KeyCode.Minus)){
			ChangeFishSpeed(-1);
		}
		//change fish zone size
		if(Input.GetKeyDown(KeyCode.UpArrow)){
			ChangeFishZone(1);
		}if(Input.GetKeyDown(KeyCode.DownArrow)){
			ChangeFishZone(-1);
		}
	}
}
