using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Author and last modified by: Jerome Aleck Emlan
//Last modified: 2071-10-20
//Program function: for moving the diver and restricting the position it can move into
//Source code: based on lab class and lab videos
public class DiverController : MonoBehaviour {

	[SerializeField]
	private float speed = 7f;
	[SerializeField]
	private float leftX;
	[SerializeField]
	private float rightX;
	[SerializeField]
	private float upY;
	[SerializeField]
	private float downY;

	private Transform _transform;
	private Vector2 _currentPos;



	// Use this for initialization
	void Start () {
		_transform = gameObject.GetComponent<Transform> ();
		_currentPos = _transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		// controls for the diver
		_currentPos = _transform.position;

		if (Input.GetKey (KeyCode.RightArrow)) {
			_currentPos += new Vector2 (speed, 0);
		}

		if (Input.GetKey (KeyCode.LeftArrow)) {
			_currentPos -= new Vector2 (speed, 0);
		}

		if (Input.GetKey (KeyCode.UpArrow)) {
			_currentPos += new Vector2 (0, speed);
		}

		if (Input.GetKey (KeyCode.DownArrow)) {
			_currentPos -= new Vector2 (0, speed);
		}


		 CheckBounds ();
		_transform.position = _currentPos;
	}

	private void CheckBounds(){
	
		//maximum position for the diver
		if (_currentPos.x < leftX) {
			_currentPos.x = leftX;
		}

		if (_currentPos.x > rightX) {
			_currentPos.x = rightX;
		}

		if (_currentPos.y < downY) {
			_currentPos.y = downY;
		}

		if (_currentPos.y > upY) {
			_currentPos.y = upY;
		}



	
	}




}
