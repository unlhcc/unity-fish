using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {

	GameObject camRig;

	void Awake () {
		camRig = GameObject.Find ("[CameraRig]");
	}

	void Update () {
		if(SteamVR_Controller.Input(1).GetPressDown(SteamVR_Controller.ButtonMask.Trigger) || SteamVR_Controller.Input(2).GetPressDown(SteamVR_Controller.ButtonMask.Trigger) ){
			Ray ray;
			RaycastHit hit;
			Debug.DrawRay (transform.position, transform.TransformDirection(Vector3.forward) * 5, Color.blue);
			bool wasHit = Physics.Raycast (transform.position, transform.TransformDirection(Vector3.forward), out hit);
			if(wasHit && hit.collider.gameObject.tag == "Warp"){
				Transform warpPoint = hit.collider.gameObject.transform;
				camRig.transform.position = warpPoint.position;
				camRig.transform.rotation = warpPoint.rotation;
			}
		}
	}
}
