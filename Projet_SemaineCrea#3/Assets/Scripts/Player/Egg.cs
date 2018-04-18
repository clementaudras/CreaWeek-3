using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour {
		public float eggHealthPoint = 100f;
		public GameObject flaque;
		public Flaque flaqueScript;
		public bool slow = true;
		public Rigidbody2D rb;
        public bool _isPlayer1Egg;

		// Use this for initialization
		void Start () {
		
		}
		
	IEnumerator SlowDown()
    {
        yield return new WaitForSecondsRealtime(2.5f);
        slow = true;
        yield return null;
    }

		IEnumerator Die()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        Destroy(gameObject);
        //gameObject.SetActive(false);
        yield return null;
    }

		// Update is called once per frame
		void Update () {
            flaque.transform.position = transform.position;

        //slow
        if (slow){
		    rb.velocity = rb.velocity * 0.9f;
		}
			
			//egg death -> flaque
		if(eggHealthPoint <= 0f){
			flaque.SetActive(true);
			StartCoroutine("Die");
			}	
		}

		void OnTriggerEnter2D(Collider2D other){
            rb.AddRelativeForce(Vector3.right.normalized * 10f);
            StartCoroutine("SlowDown");
        /*
        if (_isPlayer1Egg)
        {
            flaqueScript._isPlayer1 = true;
        }
        else if (!_isPlayer1Egg)
        {
            flaqueScript._isPlayer1 = false;
        }
        */
    }

		void OnCollisionEnter2D(Collision2D collision) {
        if (collision.relativeVelocity.magnitude > 0f)
            eggHealthPoint -= 10f;
                //eggHealthPoint -= 10f * collision.relativeVelocity.magnitude;
    }
}




/*

        if(other.CompareTag("Player1")){
            if(eggHealthPoint <= 0f){
                flaqueScript._isPlayer1 = true;
            }

            StartCoroutine("SlowDown");
            rb.AddRelativeForce(Vector3.right.normalized * 10f);
        }

        if(other.CompareTag("Player2")){
            if(eggHealthPoint <= 0f){
                flaqueScript._isPlayer1 = false;
            }

            StartCoroutine("SlowDown");
            rb.AddRelativeForce(Vector3.right.normalized * 10f);
        }
*/
