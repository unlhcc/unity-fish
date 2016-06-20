using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class Teleporter : MonoBehaviour {

	GameObject camRig;
	SteamVR_TrackedObject trackedObj;
	LineRenderer lineRenderer;
	bool turnOnLazer = false;

	void Awake () {
		camRig = GameObject.Find ("[CameraRig]");
		trackedObj = GetComponent<SteamVR_TrackedObject> ();
		lineRenderer = GetComponent<LineRenderer> ();
	}

	void Update () {
		lineRenderer.SetPosition (0, transform.position);
		lineRenderer.SetPosition (1, transform.position);
		var device = SteamVR_Controller.Input((int)trackedObj.index);
		if (device.GetPressDown (SteamVR_Controller.ButtonMask.Trigger)) {
			turnOnLazer = true;
		}
		if(device.GetPressUp (SteamVR_Controller.ButtonMask.Trigger)){
			turnOnLazer = false;
		}
		if(turnOnLazer){
			Ray ray;
			RaycastHit hit;
			bool wasHit = Physics.Raycast (transform.position, transform.TransformDirection(Vector3.forward), out hit);
			if(wasHit){
				if (device.GetPressDown (SteamVR_Controller.ButtonMask.Touchpad) && hit.collider.gameObject.tag == "Warp") {
					Transform warpPoint = hit.collider.gameObject.transform;
					camRig.transform.position = warpPoint.position;
					camRig.transform.rotation = warpPoint.rotation;

					Physics.Raycast (transform.position, transform.TransformDirection(Vector3.forward), out hit);
				}
				lineRenderer.SetPosition (0,transform.position);
				lineRenderer.SetPosition (1, hit.point);
			}
		}
	}
}
