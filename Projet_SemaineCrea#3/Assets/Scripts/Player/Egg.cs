using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour {
		public int eggHealthPoint = 3;
		public GameObject flaque;
		public Flaque flaqueScript;
		public bool eggSlow = true;
		public Rigidbody2D rb;
        public bool _isPlayer1Egg;
        public float rotInd;
		public Collider2D col;

        Animator eggState;
        Transform eggSprite;
    ParticleSystem eggExplod;
    bool eggEpl;


    // Use this for initialization
    void Start () {
        eggState = this.transform.GetChild(0).GetComponent<Animator>();
        eggSprite = this.transform.GetChild(0);
        eggExplod = this.transform.parent.GetChild(2).GetComponent<ParticleSystem>();
		StartCoroutine(Born());

    }
		
	IEnumerator SlowDown()
    {
        yield return new WaitForSecondsRealtime(2.5f);
        eggSlow = true;
        yield return null;
    }

		IEnumerator Die()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        Destroy(gameObject);
        //gameObject.SetActive(false);
        yield return null;
    }

	IEnumerator Born()
    {
        col.enabled = false;
		yield return new WaitForSecondsRealtime(0.1f);
        col.enabled = true;
        yield return null;
    }

		// Update is called once per frame
		void Update () {
            flaque.transform.position = transform.position;
        eggState.SetFloat("bkState", eggHealthPoint);
        if (rb.velocity.magnitude > 0.9)
        {
            transform.Rotate(0,0,1*rb.velocity.magnitude* rotInd);
        }
        //eggSlow
		if (eggSlow){
		    rb.velocity = rb.velocity * 0.9f;
			//eggSlow = false;
		}
			
			//egg death -> flaque
		if(eggHealthPoint <= 0){
            if (!eggEpl)
            {
                eggExplod.Play();
                eggEpl = true;
                flaque.transform.rotation = Quaternion.Euler(0,0,Random.Range(0,360));
            }
            flaque.SetActive(true);

			StartCoroutine("Die");
			}	
		}

		void OnTriggerEnter2D(Collider2D other){
            //rb.AddRelativeForce(Vector3.right.normalized * 10f);
            StartCoroutine("SlowDown");
    }

		void OnCollisionEnter2D(Collision2D collision) {
            //if (collision.relativeVelocity.magnitude > 0f)
                eggHealthPoint -= 1;
                //eggHealthPoint -= 10f * collision.relativeVelocity.magnitude;
    }
}
