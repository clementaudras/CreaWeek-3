using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public int confirmation;
    public GameObject player_1;
    public GameObject player_2;

    public bool preparationPhase;
	public bool resolutionPhase;
	public GameObject prepScreen;
	public GameObject resolScreen;
    public Text annoucerText;

    bool _isEverthingStatic = true;

    //public PlayerController player_2;

    // Use this for initialization
    void Start () {
		StartCoroutine(ScreenChanger());
		StartCoroutine(CheckObjectsHaveStopped());
	}
	
	// Update is called once per frame
	void Update () {

        if (player_1 == null)
            player_1 = GameObject.FindGameObjectWithTag("Player1");

        if (player_2 == null)
            player_2 = GameObject.FindGameObjectWithTag("Player2");

        if (!_isEverthingStatic)
        {
            annoucerText.text = "Winner Winner chiken dinner!";
        }
        else
        {
            annoucerText.text = "Waiting for players...";
        }

        //quit to menu
        if (Input.GetKeyDown(KeyCode.Escape)){
			//quit to menu
        SceneManager.LoadScene("Menu");
		}

        if(confirmation == 0)
        {
            //annoucerText.text = "Waiting for players...";
        }

        if (confirmation <= 0)
        {
            confirmation = 0;
        }

        if (confirmation == 2)
        {
            //annoucerText.text = "Winner Winner chiken dinner!";
            //move
            player_1.GetComponent<PlayerController>().move = true;
            player_2.GetComponent<PlayerController>().move = true;

            //reset
            confirmation = 0;
            //StartCoroutine(Reset());
            player_1.GetComponent<PlayerController>().confirmed = false;
            player_2.GetComponent<PlayerController>().confirmed = false;

        }

        //preparation phase
        if (preparationPhase){
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


    IEnumerator PlayerDeathTransition()
    {
        yield return new WaitForSecondsRealtime(2.5f);
        preparationPhase = true;
        yield return new WaitForSecondsRealtime(2.5f);
        preparationPhase = false;
        yield return null;
    }

    IEnumerator Reset()
    {
        yield return new WaitForSecondsRealtime(2.5f);
            confirmation = 0;
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
        _isEverthingStatic = true;
 }
}
