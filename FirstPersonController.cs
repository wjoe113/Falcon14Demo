/* FirstPersonController.cs
*  Team: Nuka Cola - MaryAnn Hrynko, Sylke Lopez, Hannah Nye, Joe Wileman
*  Spring 2016 - EME6614
*  Falcon 14 Demo
* 
*  The following script builds the first person controller for the 3D lab scene. The player
*  can jump, move, and rotate their character to explore the room.
*/

using UnityEngine;
using System.Collections;

[RequireComponent (typeof(CharacterController))]

public class FirstPersonController : MonoBehaviour {

	public float movementSpeed = 5.0f;
	public float mouseSensitivity = 5.0f;
	float verticalRotation = 0;
	public float upDownRange = 60.0f;
	float verticalVelocity = 0;
	public float jumpSpeed = 5.0f;
	CharacterController characterController;

	void Start () {
		Screen.lockCursor = true;
		characterController = GetComponent<CharacterController> ();
	}

	void Update () {
		
		//Rotation
		float rotLeftRight = Input.GetAxis ("Mouse X") * mouseSensitivity;
		transform.Rotate(0, rotLeftRight, 0);
			
		verticalRotation -= Input.GetAxis ("Mouse Y") * mouseSensitivity;
		verticalRotation = Mathf.Clamp (verticalRotation, -upDownRange, upDownRange);
		Camera.main.transform.localRotation = Quaternion.Euler (verticalRotation, 0, 0);

		//Movement
		float forwardSpeed = Input.GetAxis ("Vertical") * movementSpeed;
		float sideSpeed = Input.GetAxis ("Horizontal") * movementSpeed;

		verticalVelocity += Physics.gravity.y * Time.deltaTime;

		Vector3 speed = new Vector3 ( sideSpeed, verticalVelocity, forwardSpeed);

		//Jumping
		if (characterController.isGrounded && Input.GetButton ("Jump")) {
			verticalVelocity = jumpSpeed;
		}

		speed = transform.rotation * speed;

		characterController.Move( speed * Time.deltaTime );

	}
}