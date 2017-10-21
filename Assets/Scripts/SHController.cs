using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Author and last modified by: Jerome Aleck Emlan
//Last modified: 2071-10-20
//Program function: same with sharks for but only for position
//Source code: based on lab class and lab videos

public class SHController : MonoBehaviour {

	// Use this for initialization
	[SerializeField]
	private float speed = 5f;
	[SerializeField]
	private float startX;
	[SerializeField]
	private float endX;
	[SerializeField]
	private float startY = 200;
	[SerializeField]
	private float endY = -200;


	private Transform _transform;
	private Vector2 _currentPos;

	void Start () {
		_transform = gameObject.GetComponent<Transform> ();
		_currentPos = _transform.position;
		Reset ();
	
		
	}
	
	// Update is called once per frame
	void Update () {
		_currentPos = _transform.position;
		_currentPos -= new Vector2 (speed, 0);
		// calls the reset function when seahorse goes beyond the camera
		if (_currentPos.x < endX) {
			Reset ();
		}



		_transform.position = _currentPos;
	}


	private void Reset(){
		//spawn the seahorse in random positions coming from the positive side of the x-axis
		float dx = Random.Range (0, 100);
		float dy = Random.Range (startY, endY);
		_currentPos = new Vector2 ( startX + dx, dy);
	}




}


