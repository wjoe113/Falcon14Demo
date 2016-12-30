/* bookInteract.cs
*  Team: Nuka Cola - MaryAnn Hrynko, Sylke Lopez, Hannah Nye, Joe Wileman
*  Spring 2016 - EME6614
*  Falcon 14 Demo
* 
*  The following script makes the book in the lab scene interactable. If the player
*  hovers of the book it will change color. If the player clicks on the book he/she
*  will be transported to the 2D memory puzzle.
*/

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class bookInteract : MonoBehaviour {

	private Color defaultColor;
	private bool selectObject = false;

	void Start () {
		defaultColor = this.GetComponent<Renderer> ().material.color;
	}

	//When the mouse cursor is over the book.
	public void OnMouseEnter(){
		//Debug.Log ("Enter");
		this.GetComponent<Renderer>().material.color = Color.blue;
		selectObject = true;
	}

	//When the mouse cursor leaves the book.
	public void OnMouseExit(){
		//Debug.Log ("Exit");
		this.GetComponent<Renderer>().material.color = defaultColor;
		selectObject = false;
	}

	//When the player clicks on the book.
	public void OnMouseUp(){
		//Debug.Log ("Up");
		Screen.lockCursor = false;
		SceneManager.LoadScene (4);
	}

	//Changes the color of the book.
	void OnGUI(){
		if (selectObject == true) {
			GUI.Label (new Rect (40, 200, 350, 120), "<color=blue><size=30>Click to interact</size></color>");
		}
	}
}