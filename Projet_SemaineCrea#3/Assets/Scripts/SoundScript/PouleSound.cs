using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PouleSound : MonoBehaviour
{


    public AudioClip ValidAct;
    public AudioClip AnnulAct;

    private float velToVol = .2f;

    PlayerController_v2 playerAct;
    //EggGen playerAct2;
    AudioSource speakerPoule;
    Rigidbody2D rb;
    bool run;
    bool dontrun;

    
    void Start()
    {
        speakerPoule = GetComponent<AudioSource>();
        playerAct = GetComponent<PlayerController_v2>();
        //playerAct2 = GetComponent<EggGen>();
        rb = GetComponent<Rigidbody2D>();
    }

    /*
    // Update is called once per frame
    void Update()
    {

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
        

  
       

    }
      */
}
