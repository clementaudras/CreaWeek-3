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

    public int p1_eggCount = 0;
    public int p1_antiEggCount = 0;
    public bool p1_canLayEgg = true;
    public bool p1_canExplodeEgg;

    public int p2_eggCount = 0;

    bool _isEverthingStatic = true;

    //public PlayerController player_2;

    // Use this for initialization
    void Start () {
		StartCoroutine(ScreenChanger());
		StartCoroutine(CheckObjectsHaveStopped());
	}
	
	// Update is called once per frame
	void Update () {

        Debug.Log(p1_eggCount);
        if (player_1 == null)
            player_1 = GameObject.FindGameObjectWithTag("Player1");

        if (player_2 == null)
            player_2 = GameObject.FindGameObjectWithTag("Player2");

        //Debug.Log(player_1.GetComponent<EggGen>()._layEgg);

        /*
        if (!_isEverthingStatic)
        {
            annoucerText.text = "Winner Winner chiken dinner!";
        }
        else
        {
            annoucerText.text = "Waiting for players...";
        }
        */

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

        if (confirmation == 1)
        {
            //annoucerText.text = "Winner Winner chicken dinner!";
            //move
            if (player_1.GetComponent<PlayerController>().dirConfirmed == true)
            {
                player_1.GetComponent<PlayerController>().move = true;
				player_1.GetComponent<PlayerController>().StartCoroutine("WaitToReParent");
				player_1.GetComponent<PlayerController>().p1_canSelectDir = true;
                p1_eggCount = 0;
                p1_antiEggCount += 1;
            }

            if (player_2.GetComponent<PlayerController>().dirConfirmed == true)
            {
                player_2.GetComponent<PlayerController>().move = true;
				player_2.GetComponent<PlayerController>().StartCoroutine("WaitToReParent");
				player_2.GetComponent<PlayerController>().p2_canSelectDir = true;
            }

            //Lay egg
            if (player_1.GetComponent<EggGen>().eggConfirmed == true)
            {
                p1_eggCount += 1;
                if(p1_eggCount >= 2) //explode egg
                {
                    StartCoroutine(WaitReset_P1EggCount());
                    player_1.GetComponent<EggGen>().p1_canSelectEgg = true;
                }
                else if(p1_eggCount < 2) //lay egg
                {
                    player_1.GetComponent<EggGen>()._layEgg = true;
                    player_1.GetComponent<EggGen>().p1_canSelectEgg = true;
					player_1.GetComponent<Rigidbody2D>().AddForce(Vector3.right * 50f);
					player_1.GetComponent<Rigidbody2D>().velocity = player_1.GetComponent<Rigidbody2D>().velocity * 0.9f;
                }
            }

            if (player_2.GetComponent<EggGen>().eggConfirmed == true)
            {
                p2_eggCount += 1;
                if (p2_eggCount >= 2) //explode egg
                {
                    StartCoroutine(WaitReset_P2EggCount());
                    player_2.GetComponent<EggGen>().p2_canSelectEgg = true;
                }
                else if (p2_eggCount < 2) //lay egg
                {
                    player_2.GetComponent<EggGen>()._layEgg = true;
                    player_2.GetComponent<EggGen>().p2_canSelectEgg = true;
                }
            }


            //player_2.GetComponent<PlayerController>().move = true;

            //reset
            confirmation = 0;
            //StartCoroutine(Reset());
            player_1.GetComponent<PlayerController>().dirConfirmed = false;
            player_2.GetComponent<PlayerController>().dirConfirmed = false;

            player_1.GetComponent<EggGen>().eggConfirmed = false;
            player_2.GetComponent<EggGen>().eggConfirmed = false;

        }

        //preparation phase
        /*
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
            */
    }

	IEnumerator ScreenChanger()
    {
		preparationPhase = true;
        yield return new WaitForSecondsRealtime(2.5f);
        preparationPhase = false;
        yield return null;
    }



    IEnumerator WaitReset_P1EggCount()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        p1_eggCount = 0;
        yield return null;
    }

    IEnumerator WaitReset_P2EggCount()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        p2_eggCount = 0;
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
     //print("checking... ");
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
