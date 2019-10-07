using UnityEngine;
using System.Collections;

public class LoseColider : MonoBehaviour {

	public LevelManager levelManager; // this exposes the LevelManager component, and allows us to access it in the LoseCollider
	
	void OnTriggerEnter2D(Collider2D collider){ // no auto correct for Collider2D, just have to know the name...
		print ("Trigger");
		levelManager.LoadLevel("Lose Screen");
	}
	
	void OnCollisionEnter2D(Collision2D collision){
		print ("Collision");
		//Application.LoadLevel("Win Screen");
	}

	// Use this for initialization
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
