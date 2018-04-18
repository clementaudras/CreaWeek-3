using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {

    public bool _isPlayer1;
    public GameObject adversairePlayerHealthScript;
    public PlayerHealth playerHSCript;
    public int thisPlayerHeatlh;

    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {
        if (_isPlayer1)
        {
            adversairePlayerHealthScript = GameObject.FindGameObjectWithTag("Player2");
            thisPlayerHeatlh = adversairePlayerHealthScript.GetComponent<PlayerHealth>().playerHealth;
        }
        else if (!_isPlayer1)
        {
            adversairePlayerHealthScript = GameObject.FindGameObjectWithTag("Player1");
            thisPlayerHeatlh = adversairePlayerHealthScript.GetComponent<PlayerHealth>().playerHealth;
        }
        Debug.Log(thisPlayerHeatlh);
        thisPlayerHeatlh -= 1;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1") || other.CompareTag("HeadP1")
            || other.CompareTag("Player2") || other.CompareTag("HeadP2"))
        {
            Debug.Log("PLAYER IS DEAD");
            //thisPlayerHeatlh -= 100;
            playerHSCript.playerHealth = 0;
        }

    }
}
