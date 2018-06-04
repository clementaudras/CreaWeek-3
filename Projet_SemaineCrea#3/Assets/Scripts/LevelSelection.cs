using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class LevelSelection : MonoBehaviour {
    public int numOfCtrlrs;

    // Update is called once per frame
    void Update () {
        int numOfCtrlrs = XCI.GetNumPluggedCtrlrs(); // nombre de manette connectées

        //Instructions
        if (numOfCtrlrs < 2)
        {
            Debug.Log("Need at least two players to play.");
        }

        //Levels
        if (numOfCtrlrs == 2)
        {
            Debug.Log("2 players levels are loaded.");
        }

        if (numOfCtrlrs == 3)
        {
            Debug.Log("3 players levels are loaded.");
        }

        if (numOfCtrlrs == 4)
        {
            Debug.Log("4 players levels are loaded.");
        }
    }
}
