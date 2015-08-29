using UnityEngine;
using System.Collections;

public class EnergyChargeArea : MonoBehaviour {

	public Player player;
	private const float chargeRate = 1.0f;
	

	void OnTriggerStay(Collider other){
		if(player.gameStarted){
			Debug.Log("charge");
			if(other.gameObject.tag == "obstacle"){
				Debug.Log("charge");
				player.EnergyCharge(chargeRate);

				if(other.gameObject.transform.position.z > player.gameObject.transform.position.z){
					player.leftLight.SetActive(true);
				}else{
					player.rightLight.SetActive(true);
				}
			}
		}
	}

	void OnTriggerExit(Collider other){
		player.leftLight.SetActive(false);
		player.rightLight.SetActive(false);
	}
}
