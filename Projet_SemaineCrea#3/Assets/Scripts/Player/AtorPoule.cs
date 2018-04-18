using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtorPoule : MonoBehaviour {

    PlayerController playerMove;
    EggGen pondAct;
    Animator pouleAtor;
	void Start () {
        pouleAtor = this.GetComponent<Animator>();
        playerMove = this.transform.parent.parent.GetComponent<PlayerController>();
        pondAct = this.transform.parent.parent.GetComponent<EggGen>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (pondAct.pond == true)
        {
            pouleAtor.SetBool("Pond", true);
            pondAct.pond = false;
        }


        if (playerMove.rb.velocity.magnitude >0.9)
        {

            pouleAtor.SetBool("Run", true);
            pouleAtor.SetBool("Iddle", false);
        }
        else
        {
            pouleAtor.SetBool("Pond", false);
            pouleAtor.SetBool("Iddle", true);
            pouleAtor.SetBool("Run", false);
        }
	}
}
