/* NextScene.cs
*  Team: Nuka Cola - MaryAnn Hrynko, Sylke Lopez, Hannah Nye, Joe Wileman
*  Spring 2016 - EME6614
*  Falcon 14 Demo
* 
*  The following script takes the player to the next scene. Used for the button on the
*  transponder map to teleport the player to the lab scene.
*/

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NextScene : MonoBehaviour {

	public Button load;

	void Start () {

		load = load.GetComponent<Button> ();
	
	}

	public void StartLevel(){

		Application.LoadLevel (2);
	}
}