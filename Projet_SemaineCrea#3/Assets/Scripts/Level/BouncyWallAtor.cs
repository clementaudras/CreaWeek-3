using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyWallAtor : MonoBehaviour {

    Animator BouncyAtor;

	void Awake () {
        BouncyAtor = this.GetComponent<Animator>();
	}


    private void OnCollisionEnter(Collision collision)
    {
        BouncyAtor.SetBool("Bounce",true);
    }

    private void OnCollisionExit(Collision collision)
    {
        BouncyAtor.SetBool("Bounce", false);
    }
}
