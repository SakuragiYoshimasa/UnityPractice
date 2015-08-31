using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerGUI : MonoBehaviour {

	public Player player;
	public GameObject energyGUIPoint;
	public GameObject energyImage;
	public Text scoreText;
	public Image image;

	// Use this for initialization
	void Start () {
	
		scoreText = GameObject.Find("score").GetComponent<Text>();
		image = energyImage.GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {

	/*	if(energyGUIPoint != null){
			energyGUIPoint.GetComponent<RectTransform>().position = Camera.main.WorldToScreenPoint(energyGUIPoint.transform.position);
		}*/

		image.rectTransform.localScale = new Vector3(3.0f * (float)player.energy / Player.maxEnergy,0.2f,1f);
	
	}

	public void OnGUI(){
		scoreText.text = ((int)player.score).ToString() + "m";
	}
}
