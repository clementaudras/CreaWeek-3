using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using XboxCtrlrInput;

public class MenuBack : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(XCI.GetButtonDown(XboxButton.Back, XboxController.First) || XCI.GetButtonDown(XboxButton.Back, XboxController.Second) || Input.GetKey(KeyCode.Space)){
            Debug.Log("Menu");
            SceneManager.LoadScene("Menu");
		}
	}
}
