/* MenuScript.cs
*  Team: Nuka Cola - MaryAnn Hrynko, Sylke Lopez, Hannah Nye, Joe Wileman
*  Spring 2016 - EME6614
*  Falcon 14 Demo
* 
*  The following script builds the main menu.
*/

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScript : MonoBehaviour {

	public Canvas exitMenu;
	public Button startText;
	public Button exitText;

	void Start () {
	
		exitMenu = exitMenu.GetComponent<Canvas>();
		startText = startText.GetComponent<Button>();
		exitText = exitText.GetComponent<Button>();
		exitMenu.enabled = false;
	}

	public void ExitPress(){
	
		exitMenu.enabled = true;
		startText.enabled = false;
		exitText.enabled = false;
	}

	public void NoPress(){

		exitMenu.enabled = false;
		startText.enabled = true;
		exitText.enabled = true;
	}

	public void StartLevel(){
	
		Application.LoadLevel(1);
	}

	public void ExitGame(){
	
		Application.Quit();
	}
}