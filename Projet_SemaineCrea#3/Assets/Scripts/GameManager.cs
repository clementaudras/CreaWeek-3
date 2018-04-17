using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public int confirmation;
    public PlayerController player_1;
    //public PlayerController player_2;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    if(confirmation == 1)
        {
            //move
            player_1.GetComponent<PlayerController>().move = true;

            //reset
            confirmation = 0;
            player_1.GetComponent<PlayerController>().confirmed = false;

        }
    }
}
