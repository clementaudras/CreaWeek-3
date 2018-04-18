using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiSelect : MonoBehaviour {

    Animator uiSelect;
    PlayerController inputMove;
    EggGen inputEgg;


	void Start () {
        uiSelect = this.transform.GetChild(2).GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
