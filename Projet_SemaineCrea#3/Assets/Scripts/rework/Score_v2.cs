using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_v2 : MonoBehaviour {

    public int score_p1;
    public int score_p2;
    public int score_p3;
    public int score_p4;

    GameObject tx_p1;
    GameObject tx_p2;
    GameObject tx_p3;
    GameObject tx_p4;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        tx_p1 = GameObject.Find("TextScore_P1");
        tx_p2 = GameObject.Find("TextScore_P2");
        tx_p3 = GameObject.Find("TextScore_P3");
        tx_p4 = GameObject.Find("TextScore_P4");

        tx_p1.GetComponent<Text>().text = score_p1.ToString();
        tx_p2.GetComponent<Text>().text = score_p2.ToString();
        tx_p3.GetComponent<Text>().text = score_p3.ToString();
        tx_p4.GetComponent<Text>().text = score_p4.ToString();
    }
}
