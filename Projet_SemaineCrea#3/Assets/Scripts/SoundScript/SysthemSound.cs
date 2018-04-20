using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SysthemSound : MonoBehaviour {

	public AudioClip start;
	public AudioClip transition;
	public AudioClip victory;


	GameManager GM;
	PlayerHealth P1_Health;
	PlayerHealth P2_Health;
AudioSource SystemSpeaker;

	void Start () {
	SystemSpeaker = GetComponent<AudioSource>();
		GM = GetComponent<GameManager>();
		P1_Health = GameObject.FindGameObjectWithTag("Player1").transform.GetComponent<PlayerHealth>();
		P2_Health = GameObject.FindGameObjectWithTag("Player2").transform.GetComponent<PlayerHealth>();
	}
	
	// Update is called once per frame
	void Update () {
		if (GM.confirmation ==2){
			SystemSpeaker.PlayOneShot(start,1F);
		}

		if(P1_Health.endManche == true && P2_Health.endManche == true){
			
			SystemSpeaker.PlayOneShot(transition,1F);
			P1_Health.endManche =false;
			P2_Health.endManche =false;
		}
			
		if(P1_Health.endMatch == true && P2_Health.endMatch == true){
			
			SystemSpeaker.PlayOneShot(victory,1F);
			P1_Health.endMatch =false;
			P2_Health.endMatch =false;
		}
	}
}
