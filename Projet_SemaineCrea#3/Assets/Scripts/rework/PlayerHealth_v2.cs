using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth_v2 : MonoBehaviour {
    [Range(2, 4)]
    public int totalPlayers = 2;
    public PlayerController_v2 playerCtrl;
    public Score_v2 scoreScript;
    public int playerHealth = 100;
    int is_playerNum;

    GameObject _player1;
    GameObject _player2;
    GameObject _player3;
    GameObject _player4;

    GameObject player1_WinScreen;
    GameObject player2_WinScreen;
    GameObject player3_WinScreen;
    GameObject player4_WinScreen;

    GameObject dontdestroyonload;
    public int nombreManches = 3;
    public string nextSceneName = "LD";
    bool _isDead;
    bool _canAddScore = true;

    public Transition transitionScript;
    bool pouleExplosion;
    public bool endManche;
    public bool endMatch;

    ParticleSystem my_deadExplosion;
    GameObject my_liveSprite;
    ParticleSystem his_deadExplosion;
    GameObject his_liveSprite;

    
    void Awake()
    {
        player1_WinScreen = GameObject.Find("player1_WinScreen");
        player2_WinScreen = GameObject.Find("player2_WinScreen");
        player3_WinScreen = GameObject.Find("player3_WinScreen");
        player4_WinScreen = GameObject.Find("player4_WinScreen");

        _player1 = GameObject.Find("Player_1");
        _player2 = GameObject.Find("Player_2");
        _player3 = GameObject.Find("Player_3");
        _player4 = GameObject.Find("Player_4");
    }
    // Use this for initialization
    void Start () {
        is_playerNum = playerCtrl.GetComponent<PlayerController_v2>().playerNum;

        if(is_playerNum == 1)
        {
            my_liveSprite = _player2.transform.parent.parent.GetChild(2).GetChild(1).gameObject;
            his_deadExplosion = _player1.transform.parent.parent.GetChild(2).GetChild(0).GetComponent<ParticleSystem>();
        }

        if (is_playerNum == 2)
        {
            my_liveSprite = _player1.transform.parent.parent.GetChild(2).GetChild(1).gameObject;
            his_deadExplosion = _player2.transform.parent.parent.GetChild(2).GetChild(0).GetComponent<ParticleSystem>();
        }

        if (is_playerNum == 3)
        {

        }

        if (is_playerNum == 4)
        {

        }

    }

    //add score points
    public void AddScore()
    {
        _isDead = false;
        _canAddScore = false;
        Debug.Log("Player " + is_playerNum + " is dead.");

        if (is_playerNum == 1)
        {
            scoreScript.score_p1 += 1;
        }

        if (is_playerNum == 2)
        {
            scoreScript.score_p2 += 1;
        }

        if (is_playerNum == 3)
        {
            scoreScript.score_p3 += 1;
        }

        if (is_playerNum == 4)
        {
            scoreScript.score_p4 += 1;
        }
    }

    // Update is called once per frame
    void Update () {
        if (dontdestroyonload == null)
            dontdestroyonload = GameObject.Find("DontDestroyOnLoad");

        if (playerHealth <= 0)
        {
            _isDead = true;
        }

        /*
        if (is_playerNum == 1)
        {
            scoreScript.score_p1 += 1;
        }

        if (is_playerNum == 2)
        {
            scoreScript.score_p2 += 1;
        }

        if (is_playerNum == 3)
        {
            scoreScript.score_p3 += 1;
        }

        if (is_playerNum == 4)
        {
            scoreScript.score_p4 += 1;
        }
        */

        //FINAL POINT
        if (scoreScript.score_p1 == nombreManches)
        {
            endMatch = true;
            Debug.Log(is_playerNum + " WIN");
            //player1_WinScreen.SetActive(true);
            StartCoroutine(WaitLoad());
        }

        if (scoreScript.score_p2 == nombreManches)
        {
            endMatch = true;
            Debug.Log(is_playerNum + " WIN");
            //player2_WinScreen.SetActive(true);
            StartCoroutine(WaitLoad());
        }

        if (scoreScript.score_p3 == nombreManches)
        {
            endMatch = true;
            Debug.Log(is_playerNum + " WIN");
            //player3_WinScreen.SetActive(true);
            StartCoroutine(WaitLoad());
        }

        if (scoreScript.score_p4 == nombreManches)
        {
            endMatch = true;
            Debug.Log(is_playerNum + " WIN");
            //player4_WinScreen.SetActive(true);
            StartCoroutine(WaitLoad());
        }
    }

    IEnumerator WaitLoad()
    {
        yield return new WaitForSecondsRealtime(1f);
        transitionScript.GetComponent<Transition>().transition = true;
        if (transitionScript.GetComponent<Transition>()._transitionFinished == true)
        {
            SceneManager.LoadScene(nextSceneName);
            Destroy(dontdestroyonload);
        }
    }

    IEnumerator playerSkin()
    {
        if (!pouleExplosion)
        {
            my_liveSprite.SetActive(true);
            his_deadExplosion.Play();
            pouleExplosion = true;
        }
        yield return null;
    }

    IEnumerator NextPhase()
    {

        if (_canAddScore)
            AddScore();

        yield return new WaitForSecondsRealtime(2.5f);

        if (scoreScript.score_p1 != nombreManches && scoreScript.score_p2 != nombreManches)
        {
            endManche = true;
            transitionScript.GetComponent<Transition>().transition = true;
            if (transitionScript.GetComponent<Transition>()._transitionFinished == true)
            {
                Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.name);
            }
        }
        yield return null;
    }
}
