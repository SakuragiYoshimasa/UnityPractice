using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	[SerializeField]
	private Vector3 position;
	[SerializeField]
	private Quaternion rotation;
	[SerializeField]
	private Rigidbody rigidBody;
	[SerializeField]
	private Vector3 velocity;

	private float energy;
	private bool boost;
	private TurnModes mode;

	private const float accelarate = 5.0f;
	private const float boostAccelarate = 50.0f;
	private const float FrontFrictionEffect = 0.99f;
	private const float HorizontalFrictionEffect = 0.85f;
	private const float turnSpeed = 1.0f;

	private const float maxX = 300.0f;
	private const float maxZ = 20.0f;
	


	void Start () {

		//---------------------------------------------------------------------
		//Initialize Property
		//---------------------------------------------------------------------
		position = this.gameObject.transform.position;
		rotation = this.gameObject.transform.rotation;
		rigidBody = this.gameObject.GetComponent<Rigidbody>();
		velocity = this.gameObject.GetComponent<Rigidbody>().velocity;

		energy = 0f;
		boost = false;
		mode = TurnModes.None;


	
	}


	//---------------------------------------------------------------------
	//Input and adjust velocity
	//---------------------------------------------------------------------
	private void Update () {

		mode = TurnModes.None;
		if(Input.GetKey("left")){
			mode = TurnModes.Left;
		}
		if(Input.GetKey("right")){
			mode = TurnModes.Right;
		}

		boost = false;
		if(Input.GetKey("space")){
			boost = true;
			energy --;
		}
	}


	//---------------------------------------------------------------------
	//Update Physics and calulate
	//---------------------------------------------------------------------
	private void FixedUpdate(){

		AdjustVelocity();
	}


	//---------------------------------------------------------------------
	//EnergyCharge For BoostMode
	//---------------------------------------------------------------------
	public void EnergyCharge(float charge){

		energy += charge;
		Debug.Log(energy.ToString());

	}


	//---------------------------------------------------------------------
	//When collide with obstacle, decrease velocity and AddForce with hilizontal power opposite to player velocity
	//---------------------------------------------------------------------
	public void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "obstacle"){

		}
	}

	//---------------------------------------------------------------------
	//Adjust the  velocity
	//---------------------------------------------------------------------
	private void AdjustVelocity(){


		//---------------------------------------------------------------------
		//Front
		//---------------------------------------------------------------------
		if(velocity.x < maxX){

			velocity.x += accelarate;
		
		}else{
			 if(!boost){
				velocity.x *= FrontFrictionEffect;
			}else{
				velocity.x += boostAccelarate;
			}
		}

		//---------------------------------------------------------------------
		//Horizontal
		//---------------------------------------------------------------------
		if(TurnMode.isTurning(mode)){

			if(Mathf.Abs(velocity.z) < maxZ){
				velocity.z += (float)TurnMode.GetDirection(mode) * turnSpeed;
			}
		}else{

			velocity.z *=  HorizontalFrictionEffect;

			if(Mathf.Abs(velocity.z) < 0.05f){
				
				velocity.z = 0f;
			}
		}


		rigidBody.velocity = velocity;
	}
}
