using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem
{
	[RequireComponent( typeof( Interactable ) )]
	public class ReturnToTop : MonoBehaviour {
		GameObject camRig;
		Vector3 startingPos;
		//Quaternion startingRot;

		void Awake(){
			camRig = GameObject.Find ("Player");
			startingPos = camRig.transform.position;
			//startingRot = camRig.transform.rotation;
		}

		private void HandAttachedUpdate( Hand hand ) {
			if (hand.controller.GetPressDown( Valve.VR.EVRButtonId.k_EButton_ApplicationMenu )){
				camRig.transform.position = startingPos;
				//camRig.transform.rotation = startingRot;
			}
		}

	}
}
