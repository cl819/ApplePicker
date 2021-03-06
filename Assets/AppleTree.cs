﻿using UnityEngine;
using System.Collections;

public class AppleTree : MonoBehaviour {
	public GameObject applePrefab;
	public float speed = 1f;
	public float leftAndRightEdge = 10f;
	public float chanceToChangeDirections = 0.1f;
	public float secondsBetweenAppleDrops =1f;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("DropApple", 2f, secondsBetweenAppleDrops);
	}

	void DropApple (){
		GameObject apple = Instantiate (applePrefab) as GameObject;
		apple.transform.position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;
		pos.x += speed * Time.deltaTime;
		transform.position = pos;

		//changing direction
		if (pos.x < -leftAndRightEdge) {
			speed = Mathf.Abs (speed); //move right
		} else if (pos.x > leftAndRightEdge) {
			speed = -Mathf.Abs (speed); //move left
		}
	
	}

	void FixedUpdate(){
		//Changing direction Randomly

		if (Random.value < chanceToChangeDirections) {
			speed *= -1; //Change direction
		}
	}

}
