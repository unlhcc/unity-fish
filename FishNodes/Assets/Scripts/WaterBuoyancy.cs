/*
 * forces the gravity to go upwards(for the sake of making dead fish float).
*/

using UnityEngine;
using System.Collections;

public class WaterBuoyancy : MonoBehaviour {

	public float buoyancyOfWater = 15;

	void Awake () {
		Physics.gravity = new Vector3 (0,buoyancyOfWater*transform.localScale.z,0);
	}
	/*
	void Update(){
		Physics.gravity = new Vector3 (0,buoyancyOfWater*transform.localScale.z,0);
	}
	*/
}
