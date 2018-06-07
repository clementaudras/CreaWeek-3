using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathChecker : MonoBehaviour {
    public bool p1_active;
    public bool p2_active;
    public bool p3_active;
    public bool p4_active;

    public GameManager_v2 GM;

    GameObject Player_1;
    GameObject Player_2;
    GameObject Player_3;
    GameObject Player_4;

    // Use this for initialization
    void Start () {
        Player_1 = GameObject.Find("Player_1");
        Player_2 = GameObject.Find("Player_2");
        Player_3 = GameObject.Find("Player_3");
        Player_4 = GameObject.Find("Player_4");

        CheckDead();
    }

    void CheckDead()
    {
        if (Player_1.activeInHierarchy)
        {
            p1_active = true;
        }
        else
        {
            p1_active = false;
        }

        if (Player_2.activeInHierarchy)
        {
            p2_active = true;
        }
        else
        {
            p2_active = false;
        }

        if (GM.totalPlayers == 3)
        {
            if (Player_3.activeInHierarchy)
            {
                p3_active = true;
            }
            else
            {
                p3_active = false;
            }
        }

        if (GM.totalPlayers == 4)
        {
            if (Player_3.activeInHierarchy)
            {
                p3_active = true;
            }
            else
            {
                p3_active = false;
            }

            if (Player_4.activeInHierarchy)
            {
                p4_active = true;
            }
            else
            {
                p4_active = false;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        CheckDead();
    }
}
