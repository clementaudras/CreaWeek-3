using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggGen : MonoBehaviour {
	
	public GameObject player;
	public GameObject eggPrefab;
	public float eggForcePower = 100f;
    public bool pond;


	Rigidbody2D rb;	
	Transform target;
	Transform targetPos;

	// Use this for initialization
	void Awake () {
		rb = player.GetComponent<Rigidbody2D>();
		target = player.GetComponent<PlayerController>().target;
		targetPos = player.GetComponent<PlayerController>().targetPos;
	}

    // Update is called once per frame
    void Update()
    {

        //instantiate egg with a button
        if (Input.GetKeyDown(KeyCode.G) || Input.GetButtonDown("p1_RightBumper") || Input.GetButtonDown("p2_RightBumper"))
        {
            pond = true;
            Instantiate(eggPrefab, transform.position, Quaternion.identity);
            //Debug.Log("Instantiate Egg and move player.");
            rb.AddRelativeForce((target.transform.position - transform.position).normalized * eggForcePower);
        }
    }
}
