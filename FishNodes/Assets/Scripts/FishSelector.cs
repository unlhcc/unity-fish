/*
 * Right click to raycast onto fish and desplay its data.
*/

using UnityEngine;
using System.Collections;

public class FishSelector : MonoBehaviour {
	
	Ray ray;
	RaycastHit hit;
	bool showGUI = false;
	GameObject selectedFish;
	Vector3 fishPosistion;
	FishData data;
	float windowSizeX;
	float windowSizeY;
	int screenSizeX;
	int screenSizeY;
	int lineSize = 20;
	
	void Update () {
		if(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)){
			screenSizeX = Camera.main.pixelWidth;
			windowSizeX = 260f;
			screenSizeY = Camera.main.pixelHeight;
			windowSizeY = lineSize * 5;
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			//Debug.DrawRay (ray.origin, ray.direction*300, Color.yellow);
				
			if(Physics.Raycast(ray.origin, ray.direction, out hit) && hit.collider.tag.Equals("fish")){
				selectedFish = hit.collider.gameObject;
				data = selectedFish.GetComponent<FishData>();
				showGUI = true;
			}else{
				showGUI = false;
			}
		}

	}

	void OnGUI(){
		if(showGUI){
			//make gui follow fish
			fishPosistion = Camera.main.WorldToScreenPoint(selectedFish.transform.position);

			float x1 = fishPosistion.x;
			float y1 = screenSizeY-fishPosistion.y;

			if(fishPosistion.x + windowSizeX >= screenSizeX){
				x1 = screenSizeX - windowSizeX;
			}
			if(fishPosistion.y - windowSizeY <= 0){
				y1 = screenSizeY - windowSizeY;
			}

			GUI.Window(0,new Rect(x1,y1,windowSizeX,windowSizeY), GUIdata, "");
		}
	}

	void GUIdata(int windowID){
		//data to display
		GUI.Label (new Rect(5,0,windowSizeX-10,lineSize), selectedFish.name);
		if (!data.isSchoolLeader) {
			GUI.Label (new Rect (5, lineSize * 1, windowSizeX - 10, lineSize), "Dead? " + data.isDead.ToString ());
			GUI.Label (new Rect (5, lineSize * 2, windowSizeX - 10, lineSize), "Total memory utilization: " + data.GetMemoryUtilizationFormated ());
			GUI.Label (new Rect (5, lineSize * 3, windowSizeX - 10, lineSize), "Total number of CPUs: " + data.cpuCount.ToString ());
			GUI.Label (new Rect (5, lineSize * 4, windowSizeX - 10, lineSize), "Minute load average: " + data.avgLoad.ToString ());
		} else {
			GUI.Label(new Rect(5, lineSize * 1, windowSizeX - 10, lineSize), "Number of Working Nodes: " + data.numberOfLivingFollowers);
			GUI.Label(new Rect(5, lineSize * 2, windowSizeX - 10, lineSize), "Number of Dead Nodes: " + data.numberOfDeadFollowers);
			GUI.Label(new Rect(5, lineSize * 3, windowSizeX - 10, lineSize), "Total Number of Nodes: "+ data.numberOfFollowers);
		}
		/*
		if (GUI.Button (new Rect(windowSizeX-lineSize,0,lineSize,lineSize), "X")) {
			showGUI = false;
		}
		if(GUI.Button(new Rect(windowSizeX*.1f,lineSize*5,windowSizeX*.8f,lineSize),"Kill fish")){
			data.KillFish();
		}if(GUI.Button(new Rect(windowSizeX*.1f,lineSize*6,windowSizeX*.8f,lineSize),"Save fish")){
			data.ReviveFish();
		}
		*/

	}

}
