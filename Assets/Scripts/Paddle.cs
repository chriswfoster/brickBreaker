﻿using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {
	private Ball ball;
	float mousePosinBlocks;
	public bool autoPlay = false;
	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {

		if (!autoPlay){
			MoveWithMouse ();
		} else {
			AutoPlay ();
		}
	}
	
	void AutoPlay(){
		if (ball.hasStarted){
			Vector3 paddlePos = new Vector3(Mathf.Clamp(mousePosinBlocks, 0.5f, 15.5f), this.transform.position.y, 0f);// the f signifies float
			Vector3 ballPos = ball.transform.position;
			paddlePos.x = Mathf.Clamp (ballPos.x, 0.5f, 15.5f);
			this.transform.position = paddlePos;
		
		} else {
			//print (Input.mousePosition.x); // if you type the x, you'll see a red F for field
			//print(Input.mousePosition.x / Screen.width); // converts the whole x position to a basic 0-1 scale, no matter how big the width is.
			//print (Input.mousePosition.x / Screen.width * 16); // multiply it by 16, since that's how many game units wide we are, it'll give us that number. 
			
			mousePosinBlocks = Input.mousePosition.x / Screen.width * 16;
			Vector3 paddlePos = new Vector3(Mathf.Clamp(mousePosinBlocks, 0.5f, 15.5f), this.transform.position.y, 0f);// the f signifies float
			//this.transform.position = Vector3(mousePosinBlocks, 0.00, 0.00); // have to instantiate a NEW one
			
			// you can access paddlePos x, y, z, with paddlePos.x (for example)
			
			this.transform.position = paddlePos; // this keywoard is the instance of the component script. It is the paddle Script itself.
			// could probably use transform.position without this, and it should still work.
		}


	}
	
	void MoveWithMouse(){ // for automated testing!

		//print (Input.mousePosition.x); // if you type the x, you'll see a red F for field
		//print(Input.mousePosition.x / Screen.width); // converts the whole x position to a basic 0-1 scale, no matter how big the width is.
		//print (Input.mousePosition.x / Screen.width * 16); // multiply it by 16, since that's how many game units wide we are, it'll give us that number. 
		
		mousePosinBlocks = Input.mousePosition.x / Screen.width * 16;
		Vector3 paddlePos = new Vector3(Mathf.Clamp(mousePosinBlocks, 0.5f, 15.5f), this.transform.position.y, 0f);// the f signifies float
		//this.transform.position = Vector3(mousePosinBlocks, 0.00, 0.00); // have to instantiate a NEW one
		
		// you can access paddlePos x, y, z, with paddlePos.x (for example)
		
		this.transform.position = paddlePos; // this keywoard is the instance of the component script. It is the paddle Script itself.
		// could probably use transform.position without this, and it should still work.
	}
}
