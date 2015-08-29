using UnityEngine;
using System.Collections;

public class EnergyChargeArea : MonoBehaviour {

	public Player player;
	private const float chargeRate = 1.0f;

	private void OnTriggerStay(Collider other){

		if(other.gameObject.tag == "obstacle"){
			player.EnergyCharge(chargeRate);
		}
	}
}
