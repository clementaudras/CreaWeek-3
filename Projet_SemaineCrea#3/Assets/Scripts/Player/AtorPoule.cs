using UnityEngine;

public class AtorPoule : MonoBehaviour {

    PlayerController playerMove;
    EggGen pondAct;
    Animator pouleAtor;
    ParticleSystem smokeMove;

	void Start () {
        smokeMove = this.transform.GetChild(0).GetComponent<ParticleSystem>();
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
            //Debug.Log("POND");
        }


        if (playerMove.rb.velocity.magnitude >0.9)
        {
            pouleAtor.SetBool("Run", true);
            pouleAtor.SetBool("Iddle", false);
            //Debug.Log("MOVE");
        }
        else
        {
            smokeMove.Play();
            pouleAtor.SetBool("Pond", false);
            pouleAtor.SetBool("Iddle", true);
            pouleAtor.SetBool("Run", false);
        }
	}
}
