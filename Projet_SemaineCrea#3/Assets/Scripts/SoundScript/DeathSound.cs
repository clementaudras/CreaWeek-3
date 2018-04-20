using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSound : MonoBehaviour {

    AudioSource speakerPoule;
    public List<AudioClip> deathSound;
    PlayerHealth player;
    bool dead;

    void Start () {
        speakerPoule = GetComponent<AudioSource>();

        player = transform.parent.GetComponent<PlayerHealth>();

    }
	
	// Update is called once per frame
	void Update() {
        if (player.playerHealth <= 0 && dead == false)
        {
            speakerPoule.PlayOneShot(deathSound[Random.Range(0, deathSound.Count)], 1F);
            dead = true;
        }

	}
}
