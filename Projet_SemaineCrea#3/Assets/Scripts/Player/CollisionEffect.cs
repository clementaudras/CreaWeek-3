using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEffect : MonoBehaviour {

    public GameObject collisionFX;
    public AudioSource speakerPoule;
    public List<AudioClip> chocSound;
    public bool _canPlayEffect = true;
    public CameraShake camShake;

    // Use this for initialization
    void Start () {
        //collisionFX = transform.GetChild(0).gameObject;
        speakerPoule = GetComponent<AudioSource>();
        camShake = GameObject.Find("Main Camera").GetComponent<CameraShake>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _canPlayEffect = true;
        if (_canPlayEffect)
        {
            speakerPoule.PlayOneShot(chocSound[Random.Range(0, chocSound.Count)], 1F);
            ContactPoint2D contact = collision.contacts[0];
            collisionFX.transform.position = contact.point;
            collisionFX.GetComponent<ParticleSystem>().Play();
            camShake._activateScreenShake = true;
            camShake.shakeDuration += 0.1f;
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        _canPlayEffect = false;
    }

    void OnCollisionExit2D(Collision2D other)
    {
        _canPlayEffect = false;
    }
}
