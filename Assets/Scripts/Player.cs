using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	/*[SerializeField]
	private Vector3 position;*/
	[SerializeField]
	private Quaternion rotation;
	[SerializeField]
	private Rigidbody rigidBody;
	[SerializeField]
	private Vector3 velocity;
	[SerializeField]
	private Transform transform;

	[SerializeField]
	private float energy;
	private bool boost;
	private TurnModes mode;

	private const float accelarate = 5.0f;
	private const float boostAccelarate = 30.0f;
	private const float FrontFrictionEffect = 0.99f;
	private const float HorizontalFrictionEffect = 0.85f;
	private const float turnSpeed = 1.0f;
	private const float gravity = 3.0f;

	private const float maxX = 200.0f;
	private const float boostMaxX = 1000.0f;
	private const float maxZ = 20.0f;
	


	void Start () {

		//---------------------------------------------------------------------
		//Initialize Property
		//---------------------------------------------------------------------
		transform = this.gameObject.transform;
		//position = this.gameObject.transform.position;
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
			if(energy > 0){
				boost = true;
				energy --;
			}
		}
	}


	//---------------------------------------------------------------------
	//Update Physics and calulate
	//---------------------------------------------------------------------
	private void FixedUpdate(){

		AdjustVelocity();

		if(transform.position.y < 0){
			transform.position = new Vector3(transform.position.x,0f,transform.position.z);
		}
	}


	//---------------------------------------------------------------------
	//EnergyCharge For BoostMode
	//---------------------------------------------------------------------
	public void EnergyCharge(float charge){

		energy += charge;
		//Debug.Log(energy.ToString());
	}

	//---------------------------------------------------------------------
	//When collide with obstacle, decrease velocity and AddForce with hilizontal power opposite to vector which player to obstacle 
	//---------------------------------------------------------------------
	public void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "obstacle"){
			Debug.Log("Hit obstacle");
			rigidBody.velocity = new Vector3(rigidBody.velocity.x - 10,rigidBody.velocity.y,-20f * rigidBody.velocity.z );
		}
	}

	//---------------------------------------------------------------------
	//Adjust the  velocity
	//---------------------------------------------------------------------
	private void AdjustVelocity(){

		velocity = rigidBody.velocity;

		//---------------------------------------------------------------------
		//Front
		//---------------------------------------------------------------------
		if(!boost){

			if(velocity.x < maxX){

				velocity.x += accelarate;
		
			}else{
				if(velocity.x > maxX + 50f){
					velocity.x *= FrontFrictionEffect;
				}else{
					velocity.x = maxX;
				}
			}

		}else{
			if(velocity.x < boostMaxX){
				
				velocity.x += boostAccelarate;
				
			}else{

				velocity.x = boostMaxX;
			
			}
		}
		/*if(velocity.x < maxX){

			velocity.x += accelarate;
		
		}else{
			 if(!boost){
				velocity.x *= FrontFrictionEffect;
			}else{
				velocity.x += boostAccelarate;
			}
		}*/

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

		if(transform.position.y > 0){
			velocity.y -= gravity;
		}else{
			velocity.y = 0;
		}

		rotation = Quaternion.Euler(velocity.z / maxZ * 15f,0,0);
		transform.rotation = rotation;
		rigidBody.velocity = velocity;
	}
}
