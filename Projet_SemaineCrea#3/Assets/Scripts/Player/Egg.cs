using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour {
		public float eggHealthPoint = 100;

		public bool slow = true;
		public Rigidbody2D rb;

		// Use this for initialization
		void Start () {
		
		}
		
	IEnumerator SlowDown()
    {
        yield return new WaitForSecondsRealtime(2.5f);
        slow = true;
        yield return null;
    }

		// Update is called once per frame
		void Update () {
		//slow
		if (slow){
		    rb.velocity = rb.velocity * 0.9f;
		}
			
			//egg death -> flaque
		if(eggHealthPoint <= 0f){
			gameObject.SetActive(false);
			}	
		}

		void OnTriggerEnter2D(Collider2D other){
			if(other.CompareTag("Player")){
				StartCoroutine("SlowDown");
				//rb.AddRelativeForce(Vector3.right.normalized * 10f);
			}
		}


		void OnCollisionEnter2D(Collision2D collision) {
			if (collision.relativeVelocity.magnitude > 0f)
				eggHealthPoint -= 10f * collision.relativeVelocity.magnitude;
			}
		}
