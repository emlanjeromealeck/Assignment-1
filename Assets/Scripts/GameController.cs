using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Author and last modified by: Jerome Aleck Emlan
//Last modified: 2071-10-20
//Program function: for games UI's
//Source code: based on lab class and lab videos
public class GameController : MonoBehaviour {

	[SerializeField]
	GameObject shark;

	[SerializeField]
	Text lifeLabel;
	[SerializeField]
	Text scoreLabel;
	[SerializeField]
	Text gameOverLabel;
	[SerializeField]
	Text highScoreLabel;
	[SerializeField]
	Button resetBtn;




	//sets the 3 UI's to invisible and two UI's to visible at the start of the game
	private void initialize(){
		
		Player.Instance.Score = 0;
		Player.Instance.Life= 3;

		gameOverLabel.gameObject.SetActive (false);
		highScoreLabel.gameObject.SetActive (false);
		resetBtn.gameObject.SetActive (false);

		lifeLabel.gameObject.SetActive (true);
		scoreLabel.gameObject.SetActive (true);

		StartCoroutine ("AddEnemy");
	}

	//sets the 3 UI's to visible and two UI's to invisible when the game ends
	public void gameOver(){
		
		gameOverLabel.gameObject.SetActive (true);
		highScoreLabel.gameObject.SetActive (true);
		resetBtn.gameObject.SetActive (true);

		lifeLabel.gameObject.SetActive (false);
		scoreLabel.gameObject.SetActive (false);
	}

	//updates the UI's score and life when it catches a seahorse or hits a shark
	public void updateUI(){
		scoreLabel.text = "Score: " + Player.Instance.Score;
		lifeLabel.text = "Life: " + Player.Instance.Life;
	}



	// Use this for initialization
	void Start () {
		Player.Instance.gCtrl = this;
		initialize ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//this function is used to reset the game when its over by clicking the button
	public void ResetBtnClick(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	//function for adding more sharks
	private IEnumerator AddEnemy(){

		int time = Random.Range (1, 10);
		yield return new WaitForSeconds ((float) time);
		Instantiate (shark);
		//this function calls it self so there will be more than shark in the game
		StartCoroutine ("AddEnemy");
	}

}
