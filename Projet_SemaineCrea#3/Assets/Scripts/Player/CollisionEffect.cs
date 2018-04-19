using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEffect : MonoBehaviour {

    GameObject collisionFX;
    // Use this for initialization
    void Start () {
        collisionFX = this.transform.parent.parent.parent.GetChild(4).gameObject;
    }
	

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        collisionFX.transform.position = contact.point;
        collisionFX.GetComponent<ParticleSystem>().Play();
    }
}
