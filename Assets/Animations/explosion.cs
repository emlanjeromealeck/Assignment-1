using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Author and last modified by: Jerome Aleck Emlan
//Last modified: 2071-10-20
//Program function:explosion animation
//Source code: based on lab class and lab videos
public class explosion : MonoBehaviour {
	//used in DiverCollision
	public void DestroyMe(){
		Destroy (gameObject);
	}
}
