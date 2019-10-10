using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	
	public Sprite[] hitSprites;
	public AudioClip crack;
	public static int breakableCount = 0;
	
	private bool isBreakable;
	private int timesHit;
	private LevelManager levelManager;
	
	
	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable"); // keep track of breakable bricks...
		if (isBreakable){
			breakableCount++;
			print (breakableCount);
		}
		
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	void OnCollisionEnter2D(Collision2D collision){
		bool isBreakable = (this.tag == "Breakable");
		AudioSource.PlayClipAtPoint (crack, transform.position);
		if (isBreakable){
			HandleHits ();
		}
		
		//SimulateWin();
	}
	
	void HandleHits (){
			print ("Collision");
		//Application.LoadLevel("Win Screen");
		timesHit += 1;
		int maxHits = hitSprites.Length + 1;
		if (timesHit >= maxHits){
			
			breakableCount--;
			levelManager.BrickDestroyed();
			Destroy (gameObject);
		} else {
			LoadSprites();
		}		
	}
	
	void LoadSprites(){
		int spriteIndex = timesHit - 1; // default starts counting at zero.
		if (hitSprites[spriteIndex]){
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
	}
	
	// TODO Remove this method once we can actually Win
	void SimulateWin(){
		levelManager.LoadNextLevel();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
