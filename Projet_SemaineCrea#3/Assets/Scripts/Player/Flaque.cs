using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flaque : MonoBehaviour {

	public bool _isPlayer1;
	public bool setup;
	SpriteRenderer m_SpriteRenderer;

	// Use this for initialization
	void Start () {
		m_SpriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
			if(_isPlayer1){
			//kill player 2
        m_SpriteRenderer.color = Color.blue;		
		} else if (!_isPlayer1){
			//kill player 1
			m_SpriteRenderer.color = Color.red;		
		}
	}

	void OnTriggerEnter2D(Collider2D other){
	if(!setup){
		if(other.CompareTag("Player1")){
		_isPlayer1 = true;
		setup = true;
	} else if (other.CompareTag("Player2")){
		_isPlayer1 = false;
		setup = true;
	}
	}




		if(_isPlayer1){
			//kill player 2
			if(other.CompareTag("Player2")){
				other.gameObject.SetActive(false);
			}
		} else if (!_isPlayer1){
			//kill player 1
				if(other.CompareTag("Player1")){
				other.gameObject.SetActive(false);
			}
		}
	}
}
