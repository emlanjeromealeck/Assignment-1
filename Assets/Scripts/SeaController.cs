using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Author and last modified by: Jerome Aleck Emlan
//Last modified: 2071-10-20
//Program function: speed, resets, ect. for the sea
//Source code: based on lab class and lab videos
public class SeaController : MonoBehaviour {
	// this script is almost like the shark one it respawn/resets the position of the map/sea

	[SerializeField]
	private float speed  = 5f;
	[SerializeField]
	private float startX;
	[SerializeField]
	private float endX;





	private Transform _transform;
	private Vector2 _currentPos;

	// Use this for initialization
	void Start () {
		_transform = gameObject.GetComponent<Transform> ();
		_currentPos = _transform.position;

		Reset ();
	}
	
	// Update is called once per frame
	void Update () {
		_currentPos = _transform.position;
		_currentPos -= new Vector2 (speed, 0);

		if (_currentPos.x < endX) {
			Reset ();
		}

		_transform.position = _currentPos;

	}


	private void Reset(){
		_currentPos = new Vector2 (startX, 0);
	}





}
