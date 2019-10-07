using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	// Use this for initialization
	static MusicPlayer instance = null;
	
	// Games are called in order: Awake > Start > Update.
	
	void Awake() {
		Debug.Log("Music player Awake " + GetInstanceID());
		if(instance != null){
			Destroy (gameObject);
		} else {
			instance = this; // 
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}
	
	void Start () {
		Debug.Log("Music player Start " + GetInstanceID());

		
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	

}
