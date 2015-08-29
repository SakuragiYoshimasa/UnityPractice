using UnityEngine;
using System.Collections;

public class CameraPosition : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		// キー入力で移動
		if (Input.GetKey(KeyCode.RightArrow)){
			this.transform.position += new Vector3(10f, 0f, 0f);
		}
		if (Input.GetKey(KeyCode.LeftArrow)){
			this.transform.position += new Vector3(-10f, 0f, 0f);
		}
		if (Input.GetKey(KeyCode.UpArrow)){
			this.transform.position += new Vector3(0f, 0f, 10f);
		}
		if (Input.GetKey(KeyCode.DownArrow)){
			this.transform.position += new Vector3(0f, 0f, -10f);
		}
	}
}
