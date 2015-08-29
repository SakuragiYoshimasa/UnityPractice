using UnityEngine;
using System.Collections;

public class EnergyChargeArea : MonoBehaviour {

	public Player player;

	private void OnTriggerStay(Collider other){

		if(other.gameObject.tag == ""){
			player.EnergyCharge(1f);
		}
	}
}
