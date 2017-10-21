using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Author and last modified by: Jerome Aleck Emlan
//Last modified: 2071-10-20
//Program function: when diver hits an object
//Source code: based on lab class and lab videos

public class DiverCollision : MonoBehaviour {
	//reference for gameController.cs
	[SerializeField]
	GameController gameController;

	//reference for explosion.cs
	[SerializeField]
	GameObject explosion;


	private AudioSource _islandSound;

	// Use this for initialization
	void Start () {
		_islandSound = gameObject.GetComponent<AudioSource> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//function for effects when collision is triggered
	public void OnTriggerEnter2D(Collider2D other){

		//executes the codes when it hits a seahorse
		if (other.gameObject.tag.Equals ("seahorse")) {

			Debug.Log ("Collision seahorse\n");
			if (_islandSound != null) {
				_islandSound.Play ();
			}
			Player.Instance.Score += 100;
		}
		//executes the codes when it hits a shark/enemy
		else if(other.gameObject.tag.Equals("enemy")){
			Debug.Log ("Collision enemy\n");

			Instantiate (explosion).GetComponent<Transform> ().position = other.gameObject.GetComponent<Transform> ().position;

			other.gameObject.GetComponent<SharkController> ().Reset ();
			Player.Instance.Life-=1;


			StartCoroutine("Blink");
		}
	}

	//function for blinking when the diver hits a shark
	private IEnumerator Blink(){

		Color c;
		Renderer renderer = gameObject.GetComponent<Renderer> ();
		for (int i = 0; i < 3; i++) {
			for (float f = 1f; f >= 0; f -= 0.1f) {
				c = renderer.material.color;
				c.a = f;
				renderer.material.color = c;
				// allows you to get back to the loop
				yield return new WaitForSeconds (.1f);
			}

			for (float f = 0f; f <= 1; f += 0.1f) {
				c = renderer.material.color;
				c.a = f;
				renderer.material.color = c;
				// allows you to get back to the loop
				yield return new WaitForSeconds (.1f);
			}
		}



	}
}
