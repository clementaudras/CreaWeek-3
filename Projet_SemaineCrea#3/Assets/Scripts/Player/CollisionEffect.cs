using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEffect : MonoBehaviour {

    public GameObject collisionFX;
    public AudioSource speakerPoule;
    public List<AudioClip> chocSound;

    // Use this for initialization
    void Start () {
        //collisionFX = transform.GetChild(0).gameObject;
        speakerPoule = GetComponent<AudioSource>();
    }
	

    private void OnCollisionEnter2D(Collision2D collision)
    {
        speakerPoule.PlayOneShot(chocSound[Random.Range(0,chocSound.Count)], 1F);
        ContactPoint2D contact = collision.contacts[0];
        collisionFX.transform.position = contact.point;
        collisionFX.GetComponent<ParticleSystem>().Play();
    }
}
