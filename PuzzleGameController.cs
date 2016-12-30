/* PuzzleGameController.cs
*  Team: Nuka Cola - MaryAnn Hrynko, Sylke Lopez, Hannah Nye, Joe Wileman
*  Spring 2016 - EME6614
*  Falcon 14 Demo
* 
*  The following script builds the 2D memory puzzle. The player choses three puzzle pieces out of twelve.
*  If the three pieces form one of four physics formulas (E=mc2, Q=lt, p=m/v, F=kx) the pieces disappear.
*  When the player forms all four formulas he/she win the game. The objective is to win the game with the
*  fewest amount of guesses. The goal of the game is to teacher players basic physic formulas and what
*  they mean.
*/

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PuzzleGameController : MonoBehaviour {

	[SerializeField]
	private Sprite bgimage;

	public Sprite[] puzzles;

	public List<Sprite> gamePuzzles = new List<Sprite> ();

	public List<Button> btns = new List<Button>();

	private bool firstGuess, secondGuess, thirdGuess;

	private int countGuesses;
	private int countCorrectGuesses;
	private int gameGuesses;
	private int firstGuessIndex, secondGuessIndex, thirdGuessIndex;

	private string firstGuessPuzzle, secondGuessPuzzle, thirdGuessPuzzle;

	public GUIText scoreText;
	public GUIText defText;
	public GUIText endText;

	void Awake(){

		puzzles = Resources.LoadAll<Sprite> ("Sprites/PuzzlePieces");

	}

	void Start () {

		GetButtons ();
		AddListeners ();
		AddGamePuzzles ();
		Shuffle (gamePuzzles);
		gameGuesses = gamePuzzles.Count / 3;
	}

	//Loads the sprites for each puzzle piece when the game loads.
	void GetButtons(){

		GameObject[] objects = GameObject.FindGameObjectsWithTag("PuzzleButton");

		for(int i = 0; i < objects.Length; i++){

			btns.Add (objects [i].GetComponent<Button> ());
			btns [i].image.sprite = bgimage;
		}
	}

	//Loads the puzzle when the game loads.
	void AddGamePuzzles(){

		int looper = btns.Count;

		for (int i = 0; i < looper; i++) {

			gamePuzzles.Add (puzzles [i]);
		}
	}

	//Waits for the player to pick a puzzle piece.
	void AddListeners(){
	
		foreach (Button btn in btns) {
		
			btn.onClick.AddListener(() => PickAPuzzle());
		}
	}

	//Pick three pieces.
	public void PickAPuzzle(){
		
		string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
		//Debug.Log ("Clicking " + name);

		if (!firstGuess) {

			firstGuess = true;
			firstGuessIndex = int.Parse (UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
			firstGuessPuzzle = gamePuzzles [firstGuessIndex].name;
			btns [firstGuessIndex].image.sprite = gamePuzzles [firstGuessIndex];
			btns [firstGuessIndex].interactable = false;
		} 
		else if (!secondGuess) {

			secondGuess = true;
			secondGuessIndex = int.Parse (UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
			secondGuessPuzzle = gamePuzzles [secondGuessIndex].name;
			btns [secondGuessIndex].image.sprite = gamePuzzles [secondGuessIndex];
			btns [secondGuessIndex].interactable = false;
		} 
		else if (!thirdGuess) {
		
			thirdGuess = true;
			thirdGuessIndex = int.Parse (UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
			thirdGuessPuzzle = gamePuzzles [thirdGuessIndex].name;
			countGuesses++;
			UpdateScore ();
			btns [thirdGuessIndex].image.sprite = gamePuzzles [thirdGuessIndex];
			StartCoroutine (CheckIfThePuzzlesMatch());
			btns [firstGuessIndex].interactable = true;
			btns [secondGuessIndex].interactable = true;
		}
	}

	//Checks if the chosen pieces match. If they do make the pieces non-interactable and disappear.
	IEnumerator CheckIfThePuzzlesMatch(){
	
		yield return new WaitForSeconds (1f);

		if (firstGuessPuzzle[0] == secondGuessPuzzle[0] && firstGuessPuzzle[0] == thirdGuessPuzzle[0]) {
		
			yield return new WaitForSeconds (.5f);
			btns [firstGuessIndex].interactable = false;
			btns [secondGuessIndex].interactable = false;
			btns [thirdGuessIndex].interactable = false;

			btns [firstGuessIndex].image.color = new Color (0, 0, 0, 0);
			btns [secondGuessIndex].image.color = new Color (0, 0, 0, 0);
			btns [thirdGuessIndex].image.color = new Color (0, 0, 0, 0);

			countCorrectGuesses++;
			UpdateDef ();
			CheckIfTheGameIsFinished ();
		}
		else {

			yield return new WaitForSeconds (.5f);

			btns [firstGuessIndex].image.sprite = bgimage;
			btns [secondGuessIndex].image.sprite = bgimage;
			btns [thirdGuessIndex].image.sprite = bgimage;
		}

		firstGuess = secondGuess = thirdGuess = false;
	}

	//Checks if the last match was chosen and if so display final score.
	void CheckIfTheGameIsFinished (){

		if(countCorrectGuesses == gameGuesses){

			//Debug.Log ("It took you " + countGuesses + " guesses to solve the puzzle.");
			if (thirdGuessPuzzle [0] == 'E') {
				
				//Debug.Log ("Final score was displayed");
				endText.text = "<color=blue>" + "Congratulations!\nYou finished the puzzle in\n" + countGuesses + "\nguesses!" + "</color>";
			}
			if (thirdGuessPuzzle [0] == 'Q') {

				//Debug.Log ("Final score was displayed");
				endText.text = "<color=yellow>" + "Congratulations!\nYou finished the puzzle in\n" + countGuesses + "\nguesses!" + "</color>"; 
			}
			if (thirdGuessPuzzle [0] == 'p') {

				//Debug.Log ("Final score was displayed");
				endText.text = "<color=red>" + "Congratulations!\nYou finished the puzzle in\n" + countGuesses + "\nguesses!" + "</color>"; 
			}
			if (thirdGuessPuzzle [0] == 'F') {

				//Debug.Log ("Final score was displayed");
				endText.text = "<color=green>" + "Congratulations!\nYou finished the puzzle in\n" + countGuesses + "\nguesses!" + "</color>";
			}
		}
	}

	//Public function assigned to exit button onClick(). Loads the 0th level in the game build, in our demos case the home screen.
	public void GoToBeginning(){

		//Debug.Log ("Going to the beginning...");
		Application.LoadLevel (0);
	}

	//Shuffles the puzzle pieces once they're loaded.
	void Shuffle(List<Sprite> list){

		for (int i = 0; i < list.Count; i++) {
		
			Sprite temp = list [i];
			int randomIndex = Random.Range (0, list.Count);
			list [i] = list [randomIndex];
			list [randomIndex] = temp;
		}
	}

	//Updates the score. The score is a GUIText and can be edited as the game runs.
	void UpdateScore(){
	
		scoreText.text = "Score: " + countGuesses;
	}

	//Displays the definition of the equation that the player matched.
	void UpdateDef(){

		if (firstGuessPuzzle[0] == 'E') {

			//Debug.Log ("def was updated");
			defText.text = "<color=blue>" + "E = mc2\nEnergy(E) equals\nmass(m) times\nthe speed of \nlight(c2). That is,\nwe can calculate\nhow much energy\nis in matter." + "</color>";
		}

		if (firstGuessPuzzle[0] == 'Q') {

			//Debug.Log ("def was updated");
			defText.text = "<color=yellow>" + "Q = lt\nCharge(Q) equals\ncurrent(l) times\ntime(t). That is,\nwe can calculate how\ncharged an object is\nby the amount of current\nin it over a period\nof time." + "</color>";
		}

		if (firstGuessPuzzle[0] == 'p') {

			//Debug.Log ("def was updated");
			defText.text = "<color=red>" + "p = m/v\nDensity(p) equals\nmass(m) divided by\nvolume(v). That is,\nwe can determine\nan items density\nby its mass\nand how much volume\nit takes up." + "</color>";
		}

		if (firstGuessPuzzle[0] == 'F') {

			//Debug.Log ("def was updated");
			defText.text = "<color=green>" + "F = kx\nForce(F) equals the\nspring constant(k)\ntimes its movement in\nthe (x) direction.\nThat is, we can calculate\nthe force exerted on\na spring when pulled\nx length." + "</color>";
		}
	}
}