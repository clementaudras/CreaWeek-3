using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSound : MonoBehaviour {

    AudioSource speakerPoule;
    public List<AudioClip> deathSound;
    PlayerHealth_v2 player;
    bool dead;

    void Start () {
        speakerPoule = GetComponent<AudioSource>();

        player = transform.parent.GetComponent<PlayerHealth_v2>();

    }
	
	// Update is called once per frame
	void Update() {


        if (player.playerHealth <= 0 && dead == false)
        {
            this.gameObject.transform.parent = null;
            speakerPoule.PlayOneShot(deathSound[Random.Range(0, deathSound.Count)], 1F);
            dead = true;
        }

	}
}
