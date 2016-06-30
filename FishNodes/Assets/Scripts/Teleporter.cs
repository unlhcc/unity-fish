using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class Teleporter : MonoBehaviour {

	GameObject camRig;
	SteamVR_TrackedObject trackedObj;
	LineRenderer lineRenderer;
	bool turnOnLazer = false;
	Vector3 startingPos;
	Quaternion startingRot;

	void Awake () {
		camRig = GameObject.Find ("[CameraRig]");
		trackedObj = GetComponent<SteamVR_TrackedObject> ();
		lineRenderer = GetComponent<LineRenderer> ();
		startingPos = camRig.transform.position;
		startingRot = camRig.transform.rotation;
	}

	void Update () {
		lineRenderer.SetPosition (0, transform.position);
		lineRenderer.SetPosition (1, transform.position);
		var device = SteamVR_Controller.Input((int)trackedObj.index);

		if(device.GetPressDown (SteamVR_Controller.ButtonMask.ApplicationMenu)){
			GameObject.Find ("tank").GetComponent<DataRetriever> ().GetXML();
		}
		if(device.GetPressDown (SteamVR_Controller.ButtonMask.Grip)){
			GameObject[] allFish = GameObject.FindGameObjectsWithTag("fish");
			foreach(GameObject fish in allFish){
				Destroy(fish);
			}
		}

		if (device.GetPressDown (SteamVR_Controller.ButtonMask.Trigger)) {
			turnOnLazer = true;
		}
		if(device.GetPressUp (SteamVR_Controller.ButtonMask.Trigger)){
			turnOnLazer = false;
		}
		if(turnOnLazer){
			RaycastHit hit;
			bool wasHit = Physics.Raycast (transform.position, transform.TransformDirection(Vector3.forward), out hit);
			if(wasHit){
				if (device.GetPressDown (SteamVR_Controller.ButtonMask.Touchpad) ){
					if (hit.collider.gameObject.tag == "Warp") {
						Transform warpPoint = hit.collider.gameObject.transform;
						camRig.transform.position = warpPoint.position;
						camRig.transform.rotation = warpPoint.rotation;

						Physics.Raycast (transform.position, transform.TransformDirection (Vector3.forward), out hit);
					} else if (hit.collider.gameObject.tag == "fish") {
						transform.parent.FindChild ("GUIcanvas").GetComponent<VRSelector> ().SetCanvas (hit.collider.gameObject);
					} else {
						transform.parent.FindChild ("GUIcanvas").GetComponent<VRSelector> ().HideCanvas ();
					}
				}
				lineRenderer.SetPosition (0,transform.position);
				lineRenderer.SetPosition (1, hit.point);
			}
		}else if(device.GetPressDown (SteamVR_Controller.ButtonMask.Touchpad)){
			camRig.transform.position = startingPos;
			camRig.transform.rotation = startingRot;
		}
	}
}
