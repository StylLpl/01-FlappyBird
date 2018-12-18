using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour {

	public float speed = 5f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		PipeMoverment();
        _StopPipe();
	}

	void PipeMoverment() {
        Vector3 temp = transform.position;
        temp.x -= speed * Time.deltaTime;
        transform.position = temp;
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "Destroy") {
			Destroy(gameObject);
		}
	}

	void _StopPipe() {
		if (BirdController.instance != null) {
            if (BirdController.instance.isDead)
            {
                Destroy(GetComponent<PipeController>());
            }
        }
		
	}

}
