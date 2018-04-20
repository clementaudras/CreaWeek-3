using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunSOund : MonoBehaviour
{

    public AudioClip coursePoule;

    Rigidbody2D rb;
    private float velToVol = .2f;
    AudioSource speakerPoule;
    bool run;

    private void Start()
    {
        rb = transform.parent.GetComponent<Rigidbody2D>();
        speakerPoule = GetComponent<AudioSource>();
    }

    void Update()
    {
        float runVol = velToVol * rb.velocity.magnitude;
        if (rb.velocity.magnitude > 0.9)
        {

            speakerPoule.clip = coursePoule;
            speakerPoule.loop = true;
            speakerPoule.pitch = runVol;
            if (!run)
            {
                speakerPoule.Play();
                run = true;
            }


        }
        else
        {
            run = false;
            speakerPoule.loop = false;
            speakerPoule.Stop();
            speakerPoule.pitch = 1;
        }
    }
}
