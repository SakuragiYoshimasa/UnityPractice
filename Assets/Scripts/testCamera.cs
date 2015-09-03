using UnityEngine;
using System.Collections;

public class testCamera : MonoBehaviour {
	
	public Transform transform;
	//private Transform playersTransform;

	// Use this for initialization
	void Start () {
		//playersTransform = player.transform;
	
	}
	
	// Update is called once per frame
	void Update () {
	
		gameObject.transform.position = new Vector3(transform.position.x - 20,transform.position.y + 10,transform.position.z);
		//Debug.Log(transform.position.x.ToString());
	}
}
