using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggSound : MonoBehaviour {



    AudioClip eggBreak;
    AudioClip eggSpawn;

       AudioSource eggSound;

    Rigidbody2D rb;
    private float velToVol = .2f;

    bool run;

    private void Start()
    {
        rb = transform.parent.GetComponent<Rigidbody2D>();
        eggSound = GetComponent<AudioSource>();
        eggSound.PlayOneShot(eggSpawn, 1F);
    }

    void Update()
    {
        float runVol = velToVol * rb.velocity.magnitude;
        if (transform.GetChild(1).GetComponent<Egg>().eggHealthPoint <= 0 &&run == false)
        {
            eggSound.PlayOneShot(eggBreak, 1F);
            run = true;
        }
    }
}
