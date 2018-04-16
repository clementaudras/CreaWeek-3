using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
		public Transform arrow;
		public Transform target;

		public float horizontalSpeed = 100.0F;
	    public Rigidbody2D rb;
		public float forcePower = 50f;
		public bool slow = false;

		void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
		//debug
		        //Vector3 targetDir = target.position - transform.position;

		//Vector3 newDir = Vector3.RotateTowards(transform.right, targetDir, 0f, 0.0f);
        //Debug.DrawRay(transform.position, newDir, Color.red);

		if (Input.GetKey(KeyCode.Q))
			arrow.Rotate(Vector3.forward * horizontalSpeed * Time.deltaTime);
      
		if (Input.GetKey(KeyCode.D))
			arrow.Rotate(-Vector3.forward * horizontalSpeed * Time.deltaTime);



				//Debug.DrawLine(transform.position, newDir * 100f, Color.red);

		//Xbox 360 controller 1
					if(slow){
						rb.velocity = rb.velocity * 0.9f;
					}
					
					if(Input.GetKey(KeyCode.S)){
				Debug.Log(rb.velocity);
				//rb.velocity = Vector3.zero;
				rb.velocity = rb.velocity * 0.9f;
			}
		//Xbox 360 controller 2
		if(Input.GetKeyDown(KeyCode.T)){
			Debug.Log("T");
			//rb.AddRelativeForce(Vector3.forward * 100f);
			rb.AddRelativeForce((target.transform.position - transform.position).normalized * forcePower);
			slow = true;

			//rb.AddRelativeForce((target.transform.position - transform.position).normalized * -40);
				  /*
			Quaternion rotation = Quaternion.Euler(0, 0, 45);
			Vector3 direction = rotation * Vector3.forward;
			rb.AddForce(direction * 100f);
			rb.velocity = direction * 100f;
			
			//rb.AddRelativeForce(Vector3.forward * 100f);
			//rb.AddForce(transform.right * 10f);
			*/

			//reflectedObject.position = Vector3.Reflect(originalObject.position, Vector3.right);


			/*
						if(slow){
				rb.velocity.x = rb.velocity.x * -1f * Time.deltaTime;
								rb.velocity.y = rb.velocity.y * -1f * Time.deltaTime;
			if(rb.velocity <= 0){
				rb.velocity = 0f;
				}
			}
			*/
		}
	}
}
	 
	 
