/* GalaxyRotate.cs
*  Team: Nuka Cola - MaryAnn Hrynko, Sylke Lopez, Hannah Nye, Joe Wileman
*  Spring 2016 - EME6614
*  Falcon 14 Demo
* 
*  The following script rotates the galaxies in the main menu scene.
*/

using UnityEngine;
using System.Collections;

public class GalaxyRotate : MonoBehaviour {

	public float speed = 5f;

	void Update () {
	
		transform.Rotate (Vector3.down, speed * Time.deltaTime);

	}
}