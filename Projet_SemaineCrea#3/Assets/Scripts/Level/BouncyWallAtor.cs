using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyWallAtor : MonoBehaviour {

    Animator BouncyAtor;

	void Awake () {
        BouncyAtor = this.GetComponent<Animator>();
	}


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2") || collision.gameObject.CompareTag("HeadP1") || collision.gameObject.CompareTag("HeadP2") || collision.gameObject.CompareTag("P1Egg") || collision.gameObject.CompareTag("P2Egg"))
        {
            BouncyAtor.SetBool("Bounce", true);
        }

    }

	void OnCollisionExit2D(Collision2D collision){
		BouncyAtor.SetBool("Bounce", false);
	
	}

}
