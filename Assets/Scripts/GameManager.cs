using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public Player player;
	public PlayerGUI gui;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey("s")){
			GameStart();
		}
	}

	private void GameStart(){
		player.GameStart();
	}

	private void GameEnd(){
		//Load result scene
	}
}
