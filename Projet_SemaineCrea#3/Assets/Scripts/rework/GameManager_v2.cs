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

                //IF only 1 player is alive -> Transition to next scene, until someone is at 3/3 win -> Win screen -> Menu
                if (totalPlayersAlive == 1)
                {
                    StartCoroutine(NewNextPhase());
                }
            }
        }
            #endregion
    }

    //RESET
    void Reset()
    {
        confirmation = 0;
        player_1.GetComponent<PlayerController_v2>().dirConfirmed = false;
        player_2.GetComponent<PlayerController_v2>().dirConfirmed = false;

        player_1.GetComponent<PlayerController_v2>().eggConfirmed = false;
        player_2.GetComponent<PlayerController_v2>().eggConfirmed = false;
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

        /*
        //SLOW DOWN AFTER LAY EGG 
        if (_hasLayedEgg && player_1.GetComponent<Rigidbody2D>().velocity.magnitude > 0f)
        {
            player_1.GetComponent<Rigidbody2D>().velocity *= 0.9f;
            if (player_1.GetComponent<Rigidbody2D>().velocity.magnitude == 0f)
            {
                _hasLayedEgg = false;
            }
        }
        */
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

    //LAY EGG 
    void P1_LayEgg()
    {
        if(player_1.GetComponent<PlayerController_v2>().eggConfirmed == true)
        {
            player_1.GetComponent<PlayerController_v2>()._layEgg = true;
            player_1.GetComponent<PlayerController_v2>().p1_canSelectEgg = true;
            _hasLayedEgg = true;
            player_1.GetComponent<PlayerController_v2>().p1_canSelectDir = true;
            player_1.GetComponent<Rigidbody2D>().AddForce(player_1.GetComponent<PlayerController_v2>().vectorDirPlayer * 5f);
            player_1.GetComponent<PlayerController_v2>().StartCoroutine("WaitToReParent");
        }
    }

    void P2_LayEgg()
    {
        if (player_2.GetComponent<PlayerController_v2>().eggConfirmed == true)
        {
            player_2.GetComponent<PlayerController_v2>()._layEgg = true;
            player_2.GetComponent<PlayerController_v2>().p2_canSelectEgg = true;
            player_2.GetComponent<PlayerController_v2>().p1_canSelectDir = true;
            player_2.GetComponent<Rigidbody2D>().AddForce(player_2.GetComponent<PlayerController_v2>().vectorDirPlayer * 5f);
            _hasLayedEgg = true;
            player_2.GetComponent<PlayerController_v2>().StartCoroutine("WaitToReParent");
        }
    }
    //SLOW DOWN AFTER LAY EGG 
    void P1_SlowDownAfterEgg()
    {
        if (_hasLayedEgg && player_1.GetComponent<Rigidbody2D>().velocity.magnitude > 0f)
        {
            player_1.GetComponent<Rigidbody2D>().velocity *= 0.9f;
            if (player_1.GetComponent<Rigidbody2D>().velocity.magnitude == 0f)
            {
                _hasLayedEgg = false;
            }
        }
    }
    
    void P2_SlowDownAfterEgg()
    {
        if (_hasLayedEgg && player_2.GetComponent<Rigidbody2D>().velocity.magnitude > 0f)
        {
            player_2.GetComponent<Rigidbody2D>().velocity *= 0.9f;
            if (player_2.GetComponent<Rigidbody2D>().velocity.magnitude == 0f)
            {
                _hasLayedEgg = false;
            }
        }
    }


    //CONFIRM MOVE
    void P1_ConfirmMove()
    {
        if (player_1.GetComponent<PlayerController_v2>().dirConfirmed == true)
        {
            player_1.GetComponent<PlayerController_v2>().move = true;
            player_1.GetComponent<PlayerController_v2>().StartCoroutine("WaitToReParent");
            player_1.GetComponent<PlayerController_v2>().p1_canSelectDir = true;
            _hasLayedEgg = false;
        }
    }

    void P2_ConfirmMove()
    {
        if (player_2.GetComponent<PlayerController_v2>().dirConfirmed == true)
        {
            player_2.GetComponent<PlayerController_v2>().move = true;
            player_2.GetComponent<PlayerController_v2>().StartCoroutine("WaitToReParent");
            player_2.GetComponent<PlayerController_v2>().p1_canSelectDir = true;
            _hasLayedEgg = false;
        }
    }

    void Player3_ConfirmMove()
    {
      
    }

    void Player4_ConfirmMove()
    {
       
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
        yield return new WaitForSecondsRealtime(2.5f);
                Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.name);
        yield return null;
    }
}
