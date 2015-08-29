using UnityEngine;
using System.Collections;

public class EnergyChargeArea : MonoBehaviour {

	public Player player;
	private const float chargeRate = 1.0f;
	

	void OnTriggerStay(Collider other){
		Debug.Log("charge");
		if(other.gameObject.tag == "obstacle"){
			Debug.Log("charge");
			player.EnergyCharge(chargeRate);
		}
	}
}
