using UnityEngine;
using System.Collections;

public class SizeScaler : MonoBehaviour {

	Transform camRig;

	void Start () {
		camRig = GameObject.Find ("[CameraRig]").transform;
	}

	void Update () {
		if(Input.GetKeyDown(KeyCode.Alpha1)){
			setCamRigTransform (1f,10f,-94f,-180f);
		}
		if(Input.GetKeyDown(KeyCode.Alpha2)){
			setCamRigTransform (20f,10f,-94f,-180f);
		}
		if(Input.GetKeyDown(KeyCode.Alpha3)){
			setCamRigTransform (200f,10f,-148f,-180f);
		}
	}

	void setCamRigTransform(float scale, float x, float y, float z){
		camRig.position = new Vector3(x,y,z);
		camRig.localScale = new Vector3(scale,scale,scale);
	}
}
