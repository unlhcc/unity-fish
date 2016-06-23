/*
 * forces the gravity to go upwards(for the sake of making dead fish float).
*/

using UnityEngine;
using System.Collections;

public class WaterBuoyancy : MonoBehaviour {

	void Awake () {
		Physics.gravity = new Vector3 (0,5*transform.localScale.z,0);
	}
}
