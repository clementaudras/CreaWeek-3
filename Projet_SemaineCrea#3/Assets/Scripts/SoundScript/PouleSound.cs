using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PouleSound : MonoBehaviour {

    public AudioClip coursePoule;
    private float velToVol = .2f;


    AudioSource speakerPoule;
    Rigidbody2D rb;

    void Start() {
        speakerPoule = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        float runVol = velToVol * rb.velocity.magnitude;
        if (rb.velocity.magnitude > 0.9)
        {

            speakerPoule.Play();
            speakerPoule.clip = coursePoule;
            speakerPoule.loop = true;
        }

    }

    IEnumerator runSound()
        { 
            yield return null; }
}
