using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour {

    public PlayerHealth playerHealthScript;
    public int damage = 1;
    public bool _isPlayer1;

    void OnTriggerEnter2D (Collider2D other)
    {
        if (_isPlayer1)
        {
            if (other.CompareTag("HeadP2"))
            {
                playerHealthScript.playerHealth -= damage;
            }
        } else if (!_isPlayer1) {
            if (other.CompareTag("HeadP1"))
            {
                playerHealthScript.playerHealth -= damage;
            }
        }
    }
}
