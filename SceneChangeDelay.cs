/* SceneChangeDelay.cs
*  Team: Nuka Cola - MaryAnn Hrynko, Sylke Lopez, Hannah Nye, Joe Wileman
*  Spring 2016 - EME6614
*  Falcon 14 Demo
* 
*  Adds a delay before loading the next scene.
*/

using UnityEngine;
using System.Collections;

public class SceneChangeDelay : MonoBehaviour {

	// Use this for initialization
	IEnumerator Start () {

		yield return new WaitForSeconds(5f);
		Application.LoadLevel (3);

	}
}