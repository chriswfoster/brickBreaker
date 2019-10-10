using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public Paddle paddle; // grant access of paddle to ball
	public bool hasStarted = false;
	private Vector3 paddleToBallVector;
	
	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
		print (paddleToBallVector);
		
	}
	
	void OnCollisionEnter2D(Collision2D collision){
		Vector2 tweak = new Vector2(Random.Range (-0.2f, 0.2f), Random.Range(0f, 0.2f));
		
		if(hasStarted){
			audio.Play();
			rigidbody2D.velocity += tweak; // lowercase r because it's an instance of the rigidbody
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(!hasStarted) {
			this.transform.position = paddle.transform.position + paddleToBallVector; // locks ball to pedal, waiting for mouse press for launch
			if (Input.GetMouseButtonDown(0)){ // reminder: control and apostrophe to get the info on this method
				hasStarted = true;
				print("Button clicked");
				this.rigidbody2D.velocity = new Vector2(Random.Range (-2.0f, 2.0f), 10f);
			}
		}
		

	}
}
