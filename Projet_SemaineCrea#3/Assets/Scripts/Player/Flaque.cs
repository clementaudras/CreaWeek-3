using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flaque : MonoBehaviour {

	public bool _isPlayer1;
    public PlayerHealth playerHealthScript;
	public GameObject player_1;
    public GameObject player_2;
	public int forceBoost = 1;

    // Use this for initialization
    void Start () {
		if (player_1 == null)
            player_1 = GameObject.FindGameObjectWithTag("Player1");

        if (player_2 == null)
            player_2 = GameObject.FindGameObjectWithTag("Player2");
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
        if(!_isPlayer1 && other.CompareTag("P1Egg")){
				Destroy(other.gameObject);
			}

		if(_isPlayer1 && other.CompareTag("P2Egg")){
			Destroy(other.gameObject);
		}

		if (!_isPlayer1 && other.CompareTag("Player2"))
        {
			
			player_1.GetComponent<Rigidbody2D>().velocity *= forceBoost;
			player_2.GetComponent<Rigidbody2D>().velocity *= forceBoost;
        }

		if( _isPlayer1 && other.CompareTag("Player1")){

			player_2.GetComponent<Rigidbody2D>().velocity *= forceBoost;
			player_1.GetComponent<Rigidbody2D>().velocity *= forceBoost;
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
