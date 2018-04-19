using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceOnCollision : MonoBehaviour {

	public Rigidbody2D rbEgg;
	public float eggForce;

	void OnCollisionEnter2D(Collision2D other){
		rbEgg.AddForce(Vector3.right * eggForce);
	}
}
