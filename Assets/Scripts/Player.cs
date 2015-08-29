using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {


	private Vector3 position;
	private Quaternion rotation;
	private Rigidbody rigidBody;
	private Vector3 velocity;

	private float energy;




	void Start () {

		//---------------------------------------------------------------------
		//Initialize Property
		//---------------------------------------------------------------------
		position = this.gameObject.transform.position;
		rotation = this.gameObject.transform.rotation;
		rigidBody = this.gameObject.GetComponent<Rigidbody>();
		velocity = this.gameObject.GetComponent<Rigidbody>().velocity;

		energy = 0f;
		//---------------------------------------------------------------------

	
	}


	// Update is called once per frame
	void Update () {
	
	}


	public void EnergyCharge(float charge){

		energy += charge;

	}

	public void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "obstacle"){

		}
	}


}
