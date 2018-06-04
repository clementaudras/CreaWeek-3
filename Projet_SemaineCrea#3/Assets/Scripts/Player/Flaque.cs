using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flaque : MonoBehaviour {

	//bool _isPlayer1;
    // public PlayerHealth playerHealthScript;

    //int forceBoost = 1;
    //int is_playerNum;
    //PlayerController_v2 playerCtrl;
    
    // Use this for initialization
    void Start () {
        //is_playerNum = playerCtrl.GetComponent<PlayerController_v2>().playerNum;

    }
    
    // Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Player1") || other.CompareTag("Player2") 
            || other.CompareTag("Player3") || other.CompareTag("Player4")) {

            //other.GetComponent<PlayerController_v2>()._flaqueEffect = true;
        }

        //Destroy(this.gameObject);

        /*
        if (is_playerNum == 1 && other.CompareTag("P2Egg")) {
            Destroy(other.gameObject);
        }

        if (is_playerNum == 2 && other.CompareTag("P1Egg")) {
				Destroy(other.gameObject);
			}

		if (is_playerNum == 2 && other.CompareTag("Player2"))
        {
			
			player_1.GetComponent<Rigidbody2D>().velocity *= forceBoost;
			player_2.GetComponent<Rigidbody2D>().velocity *= forceBoost;
        }

		if(is_playerNum == 1 && other.CompareTag("Player1")){

			player_2.GetComponent<Rigidbody2D>().velocity *= forceBoost;
			player_1.GetComponent<Rigidbody2D>().velocity *= forceBoost;
		}
            */
    }
}
