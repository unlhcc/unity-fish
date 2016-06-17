using UnityEngine;
using UnityEditor;
using System.Collections;

public class CreateWallFromAngle : EditorWindow {

	public int rotAmount = -20;

	[MenuItem ("GameObject/Create wall from angle")]

	//Create Window
	static void Init () {
		CreateWallFromAngle window = (CreateWallFromAngle)EditorWindow.GetWindow (typeof (CreateWallFromAngle));
		window.Show();
	}

	void CreateWall(Transform trans){
		if(rotAmount != 0) {
				
			int absRotAmount = Mathf.Abs (rotAmount);
			float centerDistance = (trans.localScale.x / 2) * (1 / (Mathf.Tan ((absRotAmount / 2) * Mathf.Deg2Rad)));

			GameObject container = new GameObject ();
			container.transform.position = new Vector3 (trans.position.x,trans.position.y,trans.position.z+centerDistance);
			container.name = trans.name;
			trans.SetParent (container.transform);

			for(int i = 0; i < 360-absRotAmount;i += absRotAmount){

				Vector3 pos = trans.position;
				Vector3 rot = trans.rotation.eulerAngles;
				float yRotOld = rot.y;

				float hypotenuse = trans.localScale.x / 2;
				float oldZpos = pos.z + (-1 *Mathf.Sin (yRotOld* Mathf.Deg2Rad) * hypotenuse);
				float newZpos = oldZpos + (-1 *Mathf.Sin (yRotOld* Mathf.Deg2Rad + rotAmount* Mathf.Deg2Rad) * hypotenuse);
				float oldXpos = pos.x + (Mathf.Cos (yRotOld* Mathf.Deg2Rad) * hypotenuse);
				float newXpos = oldXpos + (Mathf.Cos (yRotOld * Mathf.Deg2Rad + rotAmount* Mathf.Deg2Rad) * hypotenuse);

				Vector3 newPos = new Vector3 (newXpos,pos.y,newZpos);
				Vector3 newRot = new Vector3 (rot.x,rot.y+rotAmount,rot.z);

				GameObject newWall = Instantiate (trans.gameObject,newPos,Quaternion.identity) as GameObject;
				newWall.transform.Rotate (newRot);
				newWall.name = trans.name;

				trans = newWall.transform;
				trans.SetParent (container.transform);
			}
			//Selection.activeTransform = container.transform;
		}
	}

	void OnGUI(){

		rotAmount = EditorGUILayout.IntField ("rotation amount",rotAmount);

		if (GUILayout.Button ("create next wall") && Selection.transforms.Length != 0) {
			GameObject insideWall = Instantiate (Selection.activeGameObject,
				new Vector3(Selection.activeTransform.position.x,Selection.activeTransform.position.y,Selection.activeTransform.position.z+2.5f),
				Selection.activeTransform.rotation) as GameObject;
			insideWall.transform.Rotate (new Vector3(0,180,0));
			float tanAmount = (Mathf.Tan (((Mathf.Abs (rotAmount)) / 2) * Mathf.Deg2Rad));
			float ajacentWallLenght =(Selection.activeTransform.localScale.x / 2) * (1 / tanAmount);
			float insideScale = 2f*(ajacentWallLenght - 2.5f)*tanAmount;
			Debug.Log (insideScale);
			insideWall.transform.localScale = new Vector3 (insideScale,Selection.activeTransform.lossyScale.y,Selection.activeTransform.lossyScale.z);
			DestroyImmediate(insideWall.transform.GetChild (0).gameObject);

			CreateWall (Selection.activeTransform);
			rotAmount = -rotAmount;
			CreateWall (insideWall.transform);
			rotAmount = -rotAmount;

			Selection.activeTransform = null;
		}
	}
}
