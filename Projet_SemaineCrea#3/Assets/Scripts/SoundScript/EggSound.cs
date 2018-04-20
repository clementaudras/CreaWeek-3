using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggSound : MonoBehaviour {



    public AudioClip eggBreak;
    public AudioClip eggSpawn;

       AudioSource eggSound;

    Rigidbody2D rb;
    private float velToVol = .2f;

    bool run;

    private void Start()
    {

        eggSound = GetComponent<AudioSource>();
        eggSound.PlayOneShot(eggSpawn, 1F);
    }

    void Update()
    {

        if (transform.GetChild(1).GetComponent<Egg>().eggHealthPoint <= 0 &&run == false)
        {
            eggSound.PlayOneShot(eggBreak, 1F);
            run = true;
        }
    }
}
