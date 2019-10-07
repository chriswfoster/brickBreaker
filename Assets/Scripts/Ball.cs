using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public Paddle paddle; // grant access of paddle to ball
	public bool hastStarted = false;
	private Vector3 paddleToBallVector;
	
	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
		print (paddleToBallVector);
	}
	
	// Update is called once per frame
	void Update () {
		if(!hastStarted) {
			this.transform.position = paddle.transform.position + paddleToBallVector; // locks ball to pedal, waiting for mouse press for launch
			if (Input.GetMouseButtonDown(0)){ // reminder: control and apostrophe to get the info on this method
				hastStarted = true;
				print("Button clicked");
				this.rigidbody2D.velocity = new Vector2(2f, 10f);
			}
		}
		

	}
}
