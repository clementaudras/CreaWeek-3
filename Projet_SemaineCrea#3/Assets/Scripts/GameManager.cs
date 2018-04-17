using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public int confirmation;
    public PlayerController player_1;
	public bool preparationPhase;
	public bool resolutionPhase;
	public GameObject prepScreen;
	public GameObject resolScreen;

    //public PlayerController player_2;

    // Use this for initialization
    void Start () {
		StartCoroutine(ScreenChanger());
		StartCoroutine(CheckObjectsHaveStopped());
	}
	
	// Update is called once per frame
	void Update () {
		//quit to menu
		if(Input.GetKeyDown(KeyCode.Escape)){
			//quit to menu
        SceneManager.LoadScene("Menu");
		}

	    if(confirmation == 1)
        {
            //move
            player_1.GetComponent<PlayerController>().move = true;

            //reset
            confirmation = 0;
            player_1.GetComponent<PlayerController>().confirmed = false;


        }

			//preparation phase
			if(preparationPhase){
				prepScreen.SetActive(true);
			} else if (!preparationPhase){
				prepScreen.SetActive(false);
			}

			//resolution phase
			if(resolutionPhase){
				resolScreen.SetActive(true);
			} else if (!resolutionPhase){
				resolScreen.SetActive(false);
			}
    }

	IEnumerator ScreenChanger()
    {
		preparationPhase = true;
        yield return new WaitForSecondsRealtime(2.5f);
        preparationPhase = false;
        yield return null;
    }

	 IEnumerator CheckObjectsHaveStopped()
 {
     print("checking... ");
     Rigidbody[] GOS = FindObjectsOfType(typeof(Rigidbody)) as Rigidbody[];
     bool allSleeping = false;
     
     while(!allSleeping)
     {
        allSleeping = true;
 
        foreach (Rigidbody GO in GOS) 
        {
           if(!GO.IsSleeping())
           {
              allSleeping = false;
              yield return null;
              break;
           }
        }
     
     }
     //Debug.Log("Everything is static.");
	 //Do something else
 
 }
}
