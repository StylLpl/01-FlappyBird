using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour {

    public float speed = 3f;

	private bool isFly;
	public bool isDead;

    private Animator anim;

    private Rigidbody2D myBody;
	// Use this for initialization

	[SerializeField] private AudioSource audioSource;

	[SerializeField] private AudioClip fly, die, hit;


	public static BirdController instance;
	public GameObject spawner;

	private int score = 0;
	void Start () {
		anim = GetComponent<Animator>();
        myBody = GetComponent<Rigidbody2D>();
        _MakeInstance();
	}
	
	public void _MakeInstance() {
		if (instance == null) {
			instance = this;
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		_Fly();
	}

	public void _Fly() {

		if (!isDead) {
			if(isFly) {
				isFly = false;
                myBody.velocity = new Vector2(myBody.velocity.x, speed);
				audioSource.PlayOneShot(fly);
			}
        
		}

		if (myBody.velocity.y > 0) {
			float angel = 0;
			angel = Mathf.Lerp(0, 90, myBody.velocity.y / 7);
			transform.rotation = Quaternion.Euler(0, 0, angel);
		}
		else if (myBody.velocity.y < 0)
        {
            float angel = 0;
            angel = Mathf.Lerp(0, -90, -myBody.velocity.y / 7);
            transform.rotation = Quaternion.Euler(0, 0, angel);
        }
		else {
            transform.rotation = Quaternion.Euler(0, 0, 0);
		}
		
	}

	public void _TapFly() {
		isFly = true;
		Debug.Log(myBody.velocity);
	}


	private void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.tag == "Ground" || other.gameObject.tag == "Pipe") {
			if (!isDead) {
                audioSource.PlayOneShot(die);
                anim.SetTrigger("Died");
                this.isDead = true;

                spawner = GameObject.Find("SpawnerPipe");
                Destroy(spawner);

			}

			if (GameplayController.instance != null) {
				GameplayController.instance._ShowGameoverPanel(score);
			}
			
		}
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "PlaceHolder") {
			audioSource.PlayOneShot(hit);
			score++;
			if (GameplayController.instance != null) {
                GameplayController.instance._SetScore(score);
			}
		}
	}
}
