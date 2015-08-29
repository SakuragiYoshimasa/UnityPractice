using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerGUI : MonoBehaviour {

	public Player player;


	public Text scoreText;

	// Use this for initialization
	void Start () {
	
		scoreText = GameObject.Find("score").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnGUI(){
		scoreText.text = ((int)player.score).ToString() + "m";
	}
}
