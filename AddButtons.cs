/* AddButtons.cs
*  Team: Nuka Cola - MaryAnn Hrynko, Sylke Lopez, Hannah Nye, Joe Wileman
*  Spring 2016 - EME6614
*  Falcon 14 Demo
* 
*  The following script adds the buttons to the 2D memory puzzle. For efficiency,
*  the buttons are formed when the game is ran and therefore all the button properties
*  must be specified in the game controller and script.
*/

using UnityEngine;
using System.Collections;

public class AddButtons : MonoBehaviour {

	[SerializeField]
	private Transform puzzleField;

	[SerializeField]
	private GameObject btn;

	void Awake(){

		for(int i = 0; i < 12; i++){

			GameObject button = Instantiate (btn);
			button.name = "" + i;
			button.transform.SetParent (puzzleField, false);
		}
	}
}