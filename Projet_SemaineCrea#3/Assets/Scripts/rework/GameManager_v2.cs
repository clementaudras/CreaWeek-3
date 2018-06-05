using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager_v2 : MonoBehaviour {
    [Range(2, 4)]
    public int totalPlayers = 2;

    public int confirmation = 0;

    private GameObject player_1;
    private GameObject player_2;
    private GameObject player_3;
    private GameObject player_4;

    public GameObject uiReadyp1;
    public GameObject uiReadyp2;
    public GameObject uiReadyp3;
    public GameObject uiReadyp4;

    public int totalPlayersAlive;

    //public int _eggCount = 0;
    //public int _antiEggCount = 0;
    bool _hasLayedEgg;

    // Use this for initialization
    void Start () {
        totalPlayersAlive = totalPlayers;
    }
	
	// Update is called once per frame
	void Update () {
        #region The game flow & references
        //Find Players
        if (player_1 == null)
            player_1 = GameObject.FindGameObjectWithTag("Player1");

        if (player_2 == null)
            player_2 = GameObject.FindGameObjectWithTag("Player2");

        if(totalPlayers == 3) {
            if (player_3 == null)
                player_3 = GameObject.FindGameObjectWithTag("Player3");
        }

        if (totalPlayers == 4) {
            if (player_4 == null)
                player_4 = GameObject.FindGameObjectWithTag("Player4");
        }

        //Quit to menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }

        #endregion

        #region Mechanics
        //If confirmation bug
        if (confirmation <= 0)
        {
            confirmation = 0;
        }
        Debug.Log(totalPlayersAlive);

        if (totalPlayersAlive < 1)
            totalPlayersAlive = 1;

        if(totalPlayersAlive == 0)
        {

        }

        //IF only 1 player is alive -> Transition to next scene, until someone is at 3/3 win -> Win screen -> Menu
        if (totalPlayersAlive == 1)
        {
            StartCoroutine(NewNextPhase());
        }

        if (totalPlayers == 2)
        {
            if (confirmation == 2)
            {
                //Confirmed Actions
                P1_Confirmed();
                P2_Confirmed();

                //Deactivate UI "READY!"
                uiReadyp1.SetActive(false);
                uiReadyp2.SetActive(false);

                Reset();
            }
        }

        if (totalPlayers == 3)
        {
            if (confirmation == 3)
            {
                //Confirmed Actions
                P1_Confirmed();
                P2_Confirmed();
                P3_Confirmed();

                //Deactivate UI "READY!"
                uiReadyp1.SetActive(false);
                uiReadyp2.SetActive(false);
                uiReadyp3.SetActive(false);

                Reset();
            }

            if (totalPlayersAlive == 2)
            {
                if (confirmation == 2)
                {
                    //Confirmed Actions
                    P1_Confirmed();
                    P2_Confirmed();
                    P3_Confirmed();

                    //Deactivate UI "READY!"
                    uiReadyp1.SetActive(false);
                    uiReadyp2.SetActive(false);
                    uiReadyp3.SetActive(false);

                    Reset();
                }
            }
        }
        #endregion
    }

    //RESET ALL BOOL
    void Reset()
    {
        confirmation = 0;
        player_1.GetComponent<PlayerController_v2>().dirConfirmed = false;
        player_2.GetComponent<PlayerController_v2>().dirConfirmed = false;
        player_3.GetComponent<PlayerController_v2>().dirConfirmed = false;
        //player_4.GetComponent<PlayerController_v2>().dirConfirmed = false;

        player_1.GetComponent<PlayerController_v2>().p1_hasConfirmed = true;
        player_2.GetComponent<PlayerController_v2>().p1_hasConfirmed = true;
        player_3.GetComponent<PlayerController_v2>().p1_hasConfirmed = true;
        //player_4.GetComponent<PlayerController_v2>().p1_hasConfirmed = true;

        player_1.GetComponent<PlayerController_v2>().eggConfirmed = false;
        player_2.GetComponent<PlayerController_v2>().eggConfirmed = false;
        player_3.GetComponent<PlayerController_v2>().eggConfirmed = false;
        //player_4.GetComponent<PlayerController_v2>().eggConfirmed = false;
    }


    //CONFIRM ACTION
    void P1_Confirmed()
    {
        //MOVE
        if (player_1.GetComponent<PlayerController_v2>().dirConfirmed == true)
        {
            player_1.GetComponent<PlayerController_v2>().move = true;
            player_1.GetComponent<PlayerController_v2>().StartCoroutine("WaitToReParent");
            player_1.GetComponent<PlayerController_v2>().p1_canSelectDir = true;
            _hasLayedEgg = false;
            Debug.Log("P1 MOVE");
        }

        //LAY EGG
        if (player_1.GetComponent<PlayerController_v2>().eggConfirmed == true)
        {
            player_1.GetComponent<PlayerController_v2>().egged = true;
            player_1.GetComponent<PlayerController_v2>()._layEgg = true;
            //player_1.GetComponent<PlayerController_v2>().p1_canSelectEgg = true;
            _hasLayedEgg = true;
            player_1.GetComponent<PlayerController_v2>().p1_canSelectDir = true;
            //player_1.GetComponent<Rigidbody2D>().AddForce(player_1.GetComponent<PlayerController_v2>().vectorDirPlayer * 5f);
            player_1.GetComponent<PlayerController_v2>().StartCoroutine("WaitToReParent");
            Debug.Log("P1 EGG");
        }
    }

    void P2_Confirmed()
    {
        //MOVE
        if (player_2.GetComponent<PlayerController_v2>().dirConfirmed == true)
        {
            player_2.GetComponent<PlayerController_v2>().move = true;
            player_2.GetComponent<PlayerController_v2>().StartCoroutine("WaitToReParent");
            player_2.GetComponent<PlayerController_v2>().p1_canSelectDir = true;
            _hasLayedEgg = false;
            Debug.Log("P2 MOVE");
        }

        //LAY EGG
        if (player_2.GetComponent<PlayerController_v2>().eggConfirmed == true)
        {
            player_1.GetComponent<PlayerController_v2>().egged = true;
            player_2.GetComponent<PlayerController_v2>()._layEgg = true;
            player_2.GetComponent<PlayerController_v2>().p2_canSelectEgg = true;
            player_2.GetComponent<PlayerController_v2>().p1_canSelectDir = true;
            player_2.GetComponent<Rigidbody2D>().AddForce(player_2.GetComponent<PlayerController_v2>().vectorDirPlayer * 5f);
            _hasLayedEgg = true;
            player_2.GetComponent<PlayerController_v2>().StartCoroutine("WaitToReParent");
            Debug.Log("P2 EGG");
        }

        /*
        //SLOW DOWN AFTER LAY EGG 
        if (_hasLayedEgg && player_2.GetComponent<Rigidbody2D>().velocity.magnitude > 0f)
        {
            player_2.GetComponent<Rigidbody2D>().velocity *= 0.9f;
            if (player_2.GetComponent<Rigidbody2D>().velocity.magnitude == 0f)
            {
                _hasLayedEgg = false;
            }
        }
        */
    }

    void P3_Confirmed()
    {
        //MOVE
        if (player_3.GetComponent<PlayerController_v2>().dirConfirmed == true)
        {
            player_3.GetComponent<PlayerController_v2>().move = true;
            player_3.GetComponent<PlayerController_v2>().StartCoroutine("WaitToReParent");
            player_3.GetComponent<PlayerController_v2>().p1_canSelectDir = true;
            _hasLayedEgg = false;
            Debug.Log("P3 MOVE");
        }

        //LAY EGG
        if (player_3.GetComponent<PlayerController_v2>().eggConfirmed == true)
        {
            player_3.GetComponent<PlayerController_v2>().egged = true;
            player_3.GetComponent<PlayerController_v2>()._layEgg = true;
            _hasLayedEgg = true;
            player_3.GetComponent<PlayerController_v2>().p1_canSelectDir = true;
            player_3.GetComponent<PlayerController_v2>().StartCoroutine("WaitToReParent");
            Debug.Log("P3 EGG");
        }
    }

    IEnumerator WaitReset_P1EggCount()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        //_eggCount = 0;
        yield return null;
    }

    IEnumerator WaitReset_P2EggCount()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        //_eggCount = 0;
        yield return null;
    }

    IEnumerator NewNextPhase()
    {
        yield return new WaitForSecondsRealtime(1f);
        if (player_1.activeInHierarchy == true)
        {
            player_1.GetComponent<PlayerHealth_v2>().AddScore();
            GameObject P1_Transition;
            P1_Transition = GameObject.Find("P1_Transition");
            P1_Transition.GetComponent<Transition>().transition = true;

        } else if (player_2.activeInHierarchy == true)
        {
            player_2.GetComponent<PlayerHealth_v2>().AddScore();
            GameObject P2_Transition;
            P2_Transition = GameObject.Find("P2_Transition");
            P2_Transition.GetComponent<Transition>().transition = true;
        } else if (player_3.activeInHierarchy == true)
        {
            player_3.GetComponent<PlayerHealth_v2>().AddScore();
            GameObject P3_Transition;
            P3_Transition = GameObject.Find("P3_Transition");
            P3_Transition.GetComponent<Transition>().transition = true;
        } else if (player_4.activeInHierarchy == true)
        {
            player_4.GetComponent<PlayerHealth_v2>().AddScore();
            GameObject P4_Transition;
            P4_Transition = GameObject.Find("P4_Transition");
            P4_Transition.GetComponent<Transition>().transition = true;
        }

        yield return new WaitForSecondsRealtime(2.5f);
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        yield return null;
    }

    IEnumerator Equality()
    {
        yield return new WaitForSecondsRealtime(1f);
        if (player_1.activeInHierarchy == false && player_2.activeInHierarchy == false
            && player_3.activeInHierarchy == false && player_4.activeInHierarchy == false)
        {
            Debug.Log("EQUALITY");
        }

        yield return new WaitForSecondsRealtime(2.5f);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        yield return null;
    }
}
