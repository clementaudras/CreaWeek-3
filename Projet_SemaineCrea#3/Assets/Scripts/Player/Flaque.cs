using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flaque : MonoBehaviour {

	public bool _isPlayer1;
    public PlayerHealth playerHealthScript;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
			if(_isPlayer1){
			//kill player 2
		} else if (!_isPlayer1){
			//kill player 1
		}
	}

	void OnTriggerEnter2D(Collider2D other){
        if (!_isPlayer1 && other.CompareTag("Player2") || _isPlayer1 && other.CompareTag("Player1"))
        {
            //other.GetComponent<PlayerHealth>().playerHealth = 0;
			//other.GetComponent<PlayerController>().directionVel.normalized *= 0.9;
        }

        /*
        if (!setup){
		if(other.CompareTag("Player1")){
		_isPlayer1 = true;
		setup = true;
	} else if (other.CompareTag("Player2")){
		_isPlayer1 = false;
		setup = true;
	}
}



        
		if(_isPlayer1){
			//kill player 2
			if(other.CompareTag("Player2")){
				other.gameObject.SetActive(false);
			}
		} else if (!_isPlayer1){
			//kill player 1
				if(other.CompareTag("Player1")){
				other.gameObject.SetActive(false);
			}
		}
        */
    }
}
