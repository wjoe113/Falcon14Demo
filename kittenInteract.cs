/* kittenInteract.cs
*  Team: Nuka Cola - MaryAnn Hrynko, Sylke Lopez, Hannah Nye, Joe Wileman
*  Spring 2016 - EME6614
*  Falcon 14 Demo
* 
*  The following script makes the kitten in the lab scene interactable. The kitten
*  appearing often in game, appears to have a strange connection to the player...
*/

using UnityEngine;
using System.Collections;

public class kittenInteract : MonoBehaviour {

	private bool selectObject = false;

	public void OnMouseEnter(){
		//Debug.Log ("Enter");
		selectObject = true;
	}

	public void OnMouseExit(){
		//Debug.Log ("Exit");
		selectObject = false;
	}

	void OnGUI(){
		if (selectObject == true) {
			GUI.Label (new Rect (40, 300, 350, 120), "<color=red><size=30>*meow*\nI am your master!\n*meow*</size></color>");
		}
	}
}