using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public int scoreBlue;
    public int scoreRed;

    public GameObject tx_blue;
    public GameObject tx_red;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        tx_blue = GameObject.Find("TextScore_Blue");
        tx_red = GameObject.Find("TextScore_Red");

        tx_blue.GetComponent<Text>().text = scoreBlue.ToString();
        tx_red.GetComponent<Text>().text = scoreRed.ToString();
    }
}
