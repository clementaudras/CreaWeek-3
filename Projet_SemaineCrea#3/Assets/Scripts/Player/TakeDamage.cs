﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour {
    public PlayerController_v2 playerCtrl;
    public PlayerHealth_v2 playerHealthScript;
    public GameManager_v2 GM;
    public int damage = 100;
    int is_playerNum;
    bool _canRetrieveAlivePlayer = true;

    void Start()
    {
        is_playerNum = playerCtrl.GetComponent<PlayerController_v2>().playerNum;
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (is_playerNum == 1)
        {
            if (other.CompareTag("HeadP2") || other.CompareTag("HeadP3") || other.CompareTag("HeadP4"))
            {
                playerHealthScript.playerHealth -= damage;
                StartCoroutine(RetrieveAlivePlayer());
                //other.transform.parent.parent.parent.GetComponent<PlayerHealth_v2>().AddScore();
            }
        }

        if (is_playerNum == 2) {
            if (other.CompareTag("HeadP1") || other.CompareTag("HeadP3") || other.CompareTag("HeadP4"))
            {
                playerHealthScript.playerHealth -= damage;
                StartCoroutine(RetrieveAlivePlayer());
                //GM.GetComponent<GameManager_v2>().totalPlayersAlive -= 1;
                //other.transform.parent.parent.parent.GetComponent<PlayerHealth_v2>().AddScore();
            }
        }

        if (is_playerNum == 3)
        {
            if (other.CompareTag("HeadP1") || other.CompareTag("HeadP2") || other.CompareTag("HeadP4"))
            {
                playerHealthScript.playerHealth -= damage;
                StartCoroutine(RetrieveAlivePlayer());
                //other.transform.parent.parent.parent.GetComponent<PlayerHealth_v2>().AddScore();
            }
        }

        if (is_playerNum == 4)
        {
            if (other.CompareTag("HeadP1") || other.CompareTag("HeadP2") || other.CompareTag("HeadP3"))
            {
                playerHealthScript.playerHealth -= damage;
                StartCoroutine(RetrieveAlivePlayer());
                //other.transform.parent.parent.parent.GetComponent<PlayerHealth_v2>().AddScore();
            }
        }
    }

    public IEnumerator RetrieveAlivePlayer()
    {
        if (_canRetrieveAlivePlayer)
        {
            GM.GetComponent<GameManager_v2>().totalPlayersAlive -= 1;
            _canRetrieveAlivePlayer = false;
        }
        yield return new WaitForSecondsRealtime(0.1f);
            _canRetrieveAlivePlayer = false;
        yield return null;
    }
}
