using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	
	Transform camPod1;
	Transform camPod2;

	void Start () {
		camPod1 = transform.FindChild ("Camera Pod 1");
		camPod2 = transform.FindChild ("Camera Pod 2");
	}

	void SwitchCamera(int camPodID){
		camPod1.gameObject.SetActive(false);
		camPod2.gameObject.SetActive(false);
		if(camPodID == 1){
			camPod1.gameObject.SetActive(true);
		}if(camPodID == 2){
			camPod2.gameObject.SetActive(true);
		}
	}
	
	void Update () {
		if(Input.GetKeyDown(KeyCode.Alpha1)){
			SwitchCamera(1);
		}else if(Input.GetKeyDown(KeyCode.Alpha2)){
			SwitchCamera(2);
		}
	}
}
