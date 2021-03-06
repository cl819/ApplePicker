﻿using UnityEngine;
using System.Collections;

public class Basket : MonoBehaviour {

	public GUIText scoreGT;


	// Use this for initialization
	void Start () {	
		//find a reference to the Score Counter game object
		GameObject scoreGO= GameObject.Find ("ScoreCounter");

		//get the GUIText component of that Game object
		scoreGT = scoreGO.GetComponent<GUIText> ();

		//Set the starting number of points to 0
		scoreGT.text = "0";
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 mousePos2D = Input.mousePosition;

		mousePos2D.z = -Camera.main.transform.position.z;

		Vector3 mousePos3D = Camera.main.ScreenToWorldPoint (mousePos2D);

		Vector3 pos = this.transform.position;
		pos.x = mousePos3D.x;
		this.transform.position = pos;
	
	}

	void OnCollisionEnter (Collision coll){
		GameObject collidedWith = coll.gameObject;
		if (collidedWith.tag == "Apple") {
			Destroy (collidedWith);
		}
		int score = int.Parse (scoreGT.text);

		score += 100;
		scoreGT.text = score.ToString ();

		// track high score
		if (score > HighScore.score) {
			HighScore.score = score;
		}
	}
}
