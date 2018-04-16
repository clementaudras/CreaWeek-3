using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public Transform arrow;
	public Transform target;

	public float horizontalSpeed = 100.0F;
	    public Rigidbody2D rb;

		void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
		 transform.LookAt(target);

		//debug
		if (Input.GetKey(KeyCode.Q))
			transform.Rotate(Vector3.forward * horizontalSpeed * Time.deltaTime);
      
		if (Input.GetKey(KeyCode.D))
			transform.Rotate(-Vector3.forward * horizontalSpeed * Time.deltaTime);

		//Xbox 360 controller 1

		//Xbox 360 controller 2
		if(Input.GetKeyDown(KeyCode.T)){
			Debug.Log("T");
			rb.AddRelativeForce(Vector3.forward * 100f);
				  /*
			Quaternion rotation = Quaternion.Euler(0, 0, 45);
			Vector3 direction = rotation * Vector3.forward;
			rb.AddForce(direction * 100f);
			rb.velocity = direction * 100f;
			
			//rb.AddRelativeForce(Vector3.forward * 100f);
			//rb.AddForce(transform.right * 10f);
			*/
		}
				//Debug.DrawLine(transform.position, target * 100f, Color.red);
	}
}
	 
	 
