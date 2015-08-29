using UnityEngine;
using System.Collections;

public class StageMaker : MonoBehaviour {

	public GameObject obstacle1;
	public GameObject obstacle2;
	public GameObject obstacle3;

	private void Start () {
		for (int i = 0; i < 150; i++){
			int random = Random.Range(0, 4);
			if (random <= 1){
				Vector3 randomPosition = new Vector3(Random.Range(-2500, 2500), obstacle1.transform.localScale.y/2, Random.Range(-100, 4900));
				Instantiate(obstacle1, randomPosition, Quaternion.identity);
			} else if (random <= 2){ 
				Vector3 randomPosition = new Vector3(Random.Range(-2500, 2500), obstacle2.transform.localScale.y/2, Random.Range(-100, 4900));
				Instantiate(obstacle2, randomPosition, Quaternion.identity);
			} else {
				Vector3 randomPosition = new Vector3(Random.Range(-2500, 2500), obstacle3.transform.localScale.y/2, Random.Range(-100, 4900));
				Instantiate(obstacle3, randomPosition, Quaternion.identity);
			}
		}
	}
}
