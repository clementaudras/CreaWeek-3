using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {
    [Range(1, 4)]
    public int isPlayerNum;
    GameManager_v2 GM;
    GameObject player1;
    GameObject player2;
    GameObject player3;
    GameObject player4;

    // Use this for initialization
    void Start()
    {
        GM = GameObject.Find("Main Camera").GetComponent<GameManager_v2>();
        player1 = GameObject.Find("Player_1");
        player2 = GameObject.Find("Player_2");
        player3 = GameObject.Find("Player_3");
        player4 = GameObject.Find("Player_4");
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(isPlayerNum == 1)
        {
            if (other.CompareTag("Player2")|| other.CompareTag("Player3") || other.CompareTag("Player4"))
            {
                other.GetComponent<PlayerHealth_v2>().playerHealth -= 100;
                player1.GetComponent<PlayerHealth_v2>().AddScore();
                GM.GetComponent<GameManager_v2>().totalPlayersAlive -= 1;
            }

            if(other.CompareTag("HeadP2") || other.CompareTag("HeadP3") || other.CompareTag("HeadP4"))
            {
                other.transform.parent.parent.parent.GetComponent<PlayerHealth_v2>().playerHealth -= 100;
                player1.GetComponent<PlayerHealth_v2>().AddScore();
                GM.GetComponent<GameManager_v2>().totalPlayersAlive -= 1;
            }
        }

        if (isPlayerNum == 2)
        {
            if (other.CompareTag("Player1") || other.CompareTag("Player3") || other.CompareTag("Player4"))
            {
                other.GetComponent<PlayerHealth_v2>().playerHealth -= 100;
                player2.GetComponent<PlayerHealth_v2>().AddScore();
                GM.GetComponent<GameManager_v2>().totalPlayersAlive -= 1;
            }

            if (other.CompareTag("HeadP1") || other.CompareTag("HeadP3") || other.CompareTag("HeadP4"))
            {
                other.transform.parent.parent.parent.GetComponent<PlayerHealth_v2>().playerHealth -= 100;
                player2.GetComponent<PlayerHealth_v2>().AddScore();
                GM.GetComponent<GameManager_v2>().totalPlayersAlive -= 1;
            }
        }

        if (isPlayerNum == 3)
        {
            if (other.CompareTag("Player2") || other.CompareTag("Player1") || other.CompareTag("Player4"))
            {
                other.GetComponent<PlayerHealth_v2>().playerHealth = 0;
                player3.GetComponent<PlayerHealth_v2>().AddScore();
                GM.GetComponent<GameManager_v2>().totalPlayersAlive -= 1;
            }

            if(other.CompareTag("HeadP2") || other.CompareTag("HeadP1") || other.CompareTag("HeadP4"))
            {
                other.transform.parent.parent.parent.GetComponent<PlayerHealth_v2>().playerHealth -= 100;
                player3.GetComponent<PlayerHealth_v2>().AddScore();
                GM.GetComponent<GameManager_v2>().totalPlayersAlive -= 1;
            }
        }

        if (isPlayerNum == 4)
        {
            if (other.CompareTag("Player2") || other.CompareTag("Player3") || other.CompareTag("Player1"))
            {
                other.GetComponent<PlayerHealth_v2>().playerHealth -= 100;
                player4.GetComponent<PlayerHealth_v2>().AddScore();
                GM.GetComponent<GameManager_v2>().totalPlayersAlive -= 1;
            }

            if(other.CompareTag("HeadP2") || other.CompareTag("HeadP3") || other.CompareTag("HeadP1"))
            {
                other.transform.parent.parent.parent.GetComponent<PlayerHealth_v2>().playerHealth -= 100;
                player4.GetComponent<PlayerHealth_v2>().AddScore();
                GM.GetComponent<GameManager_v2>().totalPlayersAlive -= 1;
            }
        }
    }
}
