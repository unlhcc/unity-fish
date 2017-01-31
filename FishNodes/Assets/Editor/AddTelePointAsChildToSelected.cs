using UnityEditor;
using UnityEngine;

public class AddWarpPoints : EditorWindow
{
	GameObject prefab;
	GameObject warpHolder;

	// Add menu item named "My Window" to the Window menu
	[MenuItem("Window/Add Warp Points")]
	public static void ShowWindow()
	{
		//Show existing window instance. If one doesn't exist, make one.
		EditorWindow.GetWindow(typeof(AddWarpPoints));
	}

	void OnGUI()
	{
		GUILayout.Label ("Add Warp Points", EditorStyles.boldLabel);
		prefab = EditorGUILayout.ObjectField ("Warp Object", prefab,typeof(GameObject),true) as GameObject;
		warpHolder = EditorGUILayout.ObjectField ("Warp Holder", warpHolder,typeof(GameObject),true) as GameObject;
		if(GUILayout.Button("Add Warps As Children")){
			Object[] things = Selection.GetFiltered (typeof(GameObject),SelectionMode.Unfiltered);
			foreach(Object o in things){
				GameObject go = o as GameObject;
				GameObject warp = Instantiate (prefab) as GameObject;
				warp.transform.parent = warpHolder.transform;
				warp.transform.position = go.transform.position;
				warp.transform.localScale = Vector3.one;
				//warp.transform.localRotation = Quaternion.identity;
			}
		}
	}
}