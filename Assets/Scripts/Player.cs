using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Author and last modified by: Jerome Aleck Emlan
//Last modified: 2071-10-20
//Program function: players score and life
//Source code: based on lab class and lab videos
public class Player{

	static private Player _instance;
	static public Player Instance {
		get {
			if (_instance == null) {
				_instance = new Player ();
			}
			return _instance;
		}
	}



	private Player(){

	}

	public GameController gCtrl;


	private int _score = 0;
	private int _life = 3;
	// used to add score
	public int Score{
		get{ return _score; }
		set{
			_score = value;
			gCtrl.updateUI ();
		}

	}
	// used to checks life if its 0
	public int Life{
		get{ return _life; }
		set{
			_life = value;

			if (_life <= 0) {
				gCtrl.gameOver ();
			} else {
				gCtrl.updateUI ();
			}


		}



	}
}
