using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PouleSound : MonoBehaviour
{

    public AudioClip coursePoule;
    public AudioClip ValidAct;
    public AudioClip AnnulAct;
    public AudioClip EggPop;

    private float velToVol = .2f;

    PlayerController playerAct;
    EggGen playerAct2;
    AudioSource speakerPoule;
    Rigidbody2D rb;
    bool run;
    bool dontrun;

    
    void Start()
    {
        speakerPoule = GetComponent<AudioSource>();
        playerAct = GetComponent<PlayerController>();
        playerAct2 = GetComponent<EggGen>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float runVol = velToVol * rb.velocity.magnitude;


        if (playerAct.cancelAct == true || playerAct2.cancelAct == true)
        {

            speakerPoule.clip = AnnulAct;
            speakerPoule.Play();
            playerAct.cancelAct = false;
            playerAct2.cancelAct = false;
        }
        
        if (playerAct.validAct == true || playerAct2.validAct == true)
        {
            speakerPoule.clip = ValidAct;
            speakerPoule.Play();
            playerAct.validAct = false;
            playerAct2.validAct = false;

        }
        
        if (playerAct2.pond)
        {
            speakerPoule.clip = EggPop;
            speakerPoule.Play();

        }
        else if (rb.velocity.magnitude > 0.9)
        {
            dontrun = true;
            if (dontrun == true)
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
        }else { dontrun = false; }

    }
}
