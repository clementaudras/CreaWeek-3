using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public int playerHealth = 100;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(playerHealth <= 0)
        {
            Debug.Log("Player is dead.");
            //StartCotourtine();
        }
	}

    IEnumerator NextPhase()
    {
        yield return new WaitForSecondsRealtime(2.5f);
        yield return null;
    }
}
