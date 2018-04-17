using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugVelocity : MonoBehaviour {

	public Rigidbody2D rb;
	Vector3 veclocity;
	public Vector3 directionVelocity;
	public GameObject laucher;
	public PlayerController playerCtrl;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	if(playerCtrl.GetComponent<PlayerController>().confirmed)
	{
		laucher.transform.parent = null;
	}

	veclocity = rb.velocity.normalized;
	directionVelocity = veclocity + transform.position;
		Debug.DrawLine(transform.position, directionVelocity, Color.red);
	}
}
