using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEffect : MonoBehaviour {

    GameObject collisionFX;
    // Use this for initialization
    void Start () {
        collisionFX = transform.GetChild(0).gameObject;
    }
	

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        collisionFX.transform.position = contact.point;
        collisionFX.GetComponent<ParticleSystem>().Play();
    }
}
