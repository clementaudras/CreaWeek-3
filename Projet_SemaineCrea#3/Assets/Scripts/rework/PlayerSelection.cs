using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class PlayerSelection : MonoBehaviour {
    [HideInInspector] public int numOfCtrlrs;

    public GameObject spriteP1;
    public GameObject spriteP2;
    public GameObject spriteP3;
    public GameObject spriteP4;

    // Update is called once per frame
    void Update () {
        int numOfCtrlrs = XCI.GetNumPluggedCtrlrs();
        Debug.Log("There are " + numOfCtrlrs + " Xbox controllers plugged in.");

        //Debug
        if (Input.GetKeyDown(KeyCode.D))
        {
            numOfCtrlrs += 1;
        }

        if (numOfCtrlrs == 1)
        {
            spriteP1.SetActive(true);
        } else if (numOfCtrlrs == 2)
        {
            spriteP2.SetActive(true);
        } else if(numOfCtrlrs == 3)
        {
            spriteP3.SetActive(true);
        } else if(numOfCtrlrs == 4)
        {
            spriteP4.SetActive(true);
        }
    }
}
