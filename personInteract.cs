/* personInteract.cs
*  Team: Nuka Cola - MaryAnn Hrynko, Sylke Lopez, Hannah Nye, Joe Wileman
*  Spring 2016 - EME6614
*  Falcon 14 Demo
* 
*  The following script makes Einstein in the lab scene interactable. If the player
*  hovers of Einstein, he will talk to you.
*/

using UnityEngine;
using System.Collections;

public class personInteract : MonoBehaviour {

	private bool selectObject = false;

	private int random;

	public void OnMouseEnter(){
		//Debug.Log ("Enter");
		selectObject = true;
		random = Random.Range(1, 5);
		Mathf.Round (random);
	}

	public void OnMouseExit(){
		//Debug.Log ("Exit");
		selectObject = false;
	}

	void OnGUI(){
		if (selectObject == true) {

			Debug.Log (random);

			if (random == 1) {
				GUI.Label (new Rect (75, 200, 350, 240), "<size=30>Hello young explorer!\nToday we will be learning about formulas.</size>");
			} 
			else if (random == 2) {
				GUI.Label (new Rect (75, 200, 350, 240), "<size=30>Strive not to be a success, but rather to be a value.</size>");
			}
			else if (random == 3) {
				GUI.Label (new Rect (75, 200, 350, 240), "<size=30>We cannot solve our problems with the same thinking we used to create them.</size>");
			}
			else if (random == 4) {
				GUI.Label (new Rect (75, 200, 350, 240), "<size=30>Once we accept our limits, we go beyond them.</size>");
			}
			else if (random == 5) {
				GUI.Label (new Rect (75, 200, 350, 240), "<size=30>Without formulas, we would not be able to explain the world around us.</size>");
			}
		}
	}
}