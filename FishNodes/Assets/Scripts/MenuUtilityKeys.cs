using UnityEngine;
using System.Collections;

public class MenuUtilityKeys : MonoBehaviour {

	int width = 1920;
	int height = 1080;

	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)){
			Application.Quit();
		}
		if(Input.GetKeyDown(KeyCode.F11)){
			if(width == 1920 && height == 1080){
				Screen.SetResolution (width,height,true);
				width = 1024;
				height = 768;
			}else{
				Screen.SetResolution (width,height,false);
				width = 1920;
				height = 1080;
			}
		}
	}
}
