using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Author and last modified by: Jerome Aleck Emlan
//Last modified: 2071-10-20
//Program function: shark respawn locations and speeds
//Source code: based on lab class and lab videos
public class SharkController : MonoBehaviour {


	[SerializeField]
	float minYspeed = 5f;
	[SerializeField]
	float maxYspeed = 10f;
	[SerializeField]
	float minXspeed = -2f;
	[SerializeField]
	float maxXspeed = 2f;


	private Transform _transform;
	private Vector2 _currentSpeed;
	private Vector2 _currentPosition;


	// Use this for initialization
	void Start () {
		_transform = gameObject.GetComponent<Transform> ();
		Reset ();
	}


	// Update is called once per frame
	void Update () {
		_currentPosition = _transform.position;
		_currentPosition -= _currentSpeed;
		_transform.position = _currentPosition;

		//if the shark goes beyon this value it reset/respawns it
		if (_currentPosition.x <= -580) {
			Reset ();
		}
	}

	// random speed for sharks
	public void Reset(){
		float xSpeed = Random.Range (minXspeed, maxXspeed);
		float ySpeed = Random.Range (minYspeed, maxYspeed);


		_currentSpeed = new Vector2 (ySpeed, xSpeed);


		float y = Random.Range (200, -180);
		_transform.position = new Vector2 (500 + Random.Range (0, 1000), y);
	}

}
