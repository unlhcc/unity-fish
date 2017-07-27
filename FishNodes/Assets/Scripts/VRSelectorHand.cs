using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem
{
	[RequireComponent( typeof( Interactable ) )]
	public class VRSelectorHand : MonoBehaviour {

		LineRenderer lineRenderer;

		void Awake () {
			lineRenderer = GetComponent<LineRenderer> ();
		}

		private void HandAttachedUpdate( Hand hand ) {
			lineRenderer.SetPosition (0, transform.position);
			lineRenderer.SetPosition (1, transform.position);

			if(hand.controller.GetPress( Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger )){
				RaycastHit hit;
				bool wasHit = Physics.Raycast (transform.position, transform.forward, out hit);
				if(wasHit){
					lineRenderer.SetPosition (1, hit.point);
					if (hand.controller.GetPressDown( Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad )){
						if (hit.collider.gameObject.tag == "fish") {
							transform.Find ("GUIcanvas").GetComponent<VRSelector> ().SetCanvas (hit.collider.gameObject);
						} else {
							transform.Find ("GUIcanvas").GetComponent<VRSelector> ().HideCanvas ();
						}
					}
				}
			}
		}
	
	}
}