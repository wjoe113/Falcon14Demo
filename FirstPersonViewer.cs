/* FirstPersonViewer.cs
*  Team: Nuka Cola - MaryAnn Hrynko, Sylke Lopez, Hannah Nye, Joe Wileman
*  Spring 2016 - EME6614
*  Falcon 14 Demo
* 
*  Similar to the FirstPersonController, the FirstPersonViewer lets the player
*  rotate the camera.
*/

using UnityEngine;
using System.Collections;

public class FirstPersonViewer : MonoBehaviour {

	public float mouseSensitivity = 5.0f;
	float verticalRotation = 0;
	public float upDownRange = 60.0f;

	void Update () {

		//Rotation
		float rotLeftRight = Input.GetAxis ("Mouse X") * mouseSensitivity;
		transform.Rotate(0, rotLeftRight, 0);

		verticalRotation -= Input.GetAxis ("Mouse Y") * mouseSensitivity;
		verticalRotation = Mathf.Clamp (verticalRotation, -upDownRange, upDownRange);
		Camera.main.transform.localRotation = Quaternion.Euler (verticalRotation, 0, 0);

	}
}