using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPipe : MonoBehaviour {

	[SerializeField] private GameObject Pipe;

	// Use this for initialization
	void Start () {
		//SatrtCoroutine_Auto()
		StartCoroutine(Spawner());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator Spawner() {
		yield return new WaitForSeconds(1);

		Vector3 temp = transform.position;
		temp.y = Random.Range(-1, 2);

		Instantiate(Pipe, temp, Quaternion.identity);
		StartCoroutine(Spawner());

	}

}
