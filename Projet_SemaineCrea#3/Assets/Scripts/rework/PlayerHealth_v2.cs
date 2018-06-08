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

    [HideInInspector]
    public GameObject _winSprite;

    GameObject _player1;
    GameObject _player2;
    GameObject _player3;
    GameObject _player4;

    GameObject winScreens_go;

    GameObject dontdestroyonload;
    public int nombreManches = 3;
    public string nextSceneName = "LD";
    bool _isDead;
    bool _canAddScore = true;

    public Transition transitionScript;
    bool pouleExplosion;
    public bool endManche;
    public bool endMatch;

    [HideInInspector]
    public ParticleSystem _deadExplosion;

    [HideInInspector]
    public GameObject _col;

    [HideInInspector]
    public GameObject _trig;

    GameObject my_liveSprite;
    ParticleSystem his_deadExplosion;
    GameObject his_liveSprite;

    ScoreFeedback p1Sc;
    ScoreFeedback p2Sc;
    ScoreFeedback p3Sc;
    ScoreFeedback p4Sc;
    
    void Awake()
    {

        winScreens_go = GameObject.Find("WinScreens");

        p1Sc = GameObject.Find("TextScore_P1").GetComponent<ScoreFeedback>();
        p2Sc = GameObject.Find("TextScore_P2").GetComponent<ScoreFeedback>();
        p3Sc = GameObject.Find("TextScore_P3").GetComponent<ScoreFeedback>();
        p4Sc = GameObject.Find("TextScore_P4").GetComponent<ScoreFeedback>();

        _player1 = GameObject.Find("Player_1");
        _player2 = GameObject.Find("Player_2");
        _player3 = GameObject.Find("Player_3");
        _player4 = GameObject.Find("Player_4");

        scoreScript = GameObject.Find("Score_ddol").GetComponent<Score_v2>();
    }
    // Use this for initialization
    void Start () {
        foreach (Transform t in transform)
        {
            if (t.name == "WinSprite")
            {
                _winSprite = t.gameObject;
                _deadExplosion = t.gameObject.transform.GetChild(0).GetComponent<ParticleSystem>();
            }
        }

        is_playerNum = playerCtrl.GetComponent<PlayerController_v2>().playerNum;

        if(is_playerNum == 1)
        {
            _col = GameObject.Find("A_head_col");
            _trig = GameObject.Find("A_head_trigger");
        }

        if (is_playerNum == 2)
        {
            _col = GameObject.Find("B_head_col");
            _trig = GameObject.Find("B_head_trigger");
        }

        if (is_playerNum == 3)
        {
            _col = GameObject.Find("C_head_col");
            _trig = GameObject.Find("C_head_trigger");
        }

        if (is_playerNum == 4)
        {
            _col = GameObject.Find("D_head_col");
            _trig = GameObject.Find("D_head_trigger");
        }

    }

    //add score points
    public void AddScore()
    {
        _isDead = false;
        //_canAddScore = false;
        //Debug.Log("Player " + is_playerNum + " +1");

        if (_canAddScore)
        {
            if (is_playerNum == 1)
            {
                scoreScript.score_p1 += 1;
                _canAddScore = false;
                p1Sc._feedback = true;
            }

            if (is_playerNum == 2)
            {
                scoreScript.score_p2 += 1;
                _canAddScore = false;
                p2Sc._feedback = true;
            }

            if (is_playerNum == 3)
            {
                scoreScript.score_p3 += 1;
                _canAddScore = false;
                p3Sc._feedback = true;
            }

            if (is_playerNum == 4)
            {
                scoreScript.score_p4 += 1;
                _canAddScore = false;
                p4Sc._feedback = true;
            }
        }
    }

    // Update is called once per frame
    void Update () {
        if (dontdestroyonload == null)
            dontdestroyonload = GameObject.Find("DontDestroyOnLoad");

        if (playerHealth <= 0)
        {
            _winSprite.transform.parent = null;
            this.gameObject.layer = 18;
            _col.gameObject.layer = 18;
            _trig.gameObject.layer = 18;
            this.gameObject.GetComponent<Rigidbody2D>().velocity *= 0;
            StartCoroutine(playerSkin());
            _isDead = true;
            StartCoroutine(WaitDeath());
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
        if (scoreScript.score_p1 == nombreManches && scoreScript.score_p2 != nombreManches 
            && scoreScript.score_p3 != nombreManches && scoreScript.score_p4 != nombreManches)
        {
            endMatch = true;
            winScreens_go.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            StartCoroutine(WaitLoad());
        } else if (scoreScript.score_p1 != nombreManches && scoreScript.score_p2 == nombreManches
            && scoreScript.score_p3 != nombreManches && scoreScript.score_p4 != nombreManches)
        {
            endMatch = true;
            winScreens_go.gameObject.transform.GetChild(1).gameObject.SetActive(true);
            StartCoroutine(WaitLoad());
        }
        else if (scoreScript.score_p1 != nombreManches && scoreScript.score_p2 != nombreManches
            && scoreScript.score_p3 == nombreManches && scoreScript.score_p4 != nombreManches)
        {
            endMatch = true;
            winScreens_go.gameObject.transform.GetChild(2).gameObject.SetActive(true);
            StartCoroutine(WaitLoad());
        }
        else if (scoreScript.score_p1 != nombreManches && scoreScript.score_p2 != nombreManches
            && scoreScript.score_p3 != nombreManches && scoreScript.score_p4 == nombreManches)
        {
            endMatch = true;
            winScreens_go.gameObject.transform.GetChild(3).gameObject.SetActive(true);
            StartCoroutine(WaitLoad());
        }
    }

    IEnumerator WaitDeath()
    {
        this.gameObject.SetActive(false); //disable all colliders
        yield return new WaitForSecondsRealtime(10f);

        
        

    }


    IEnumerator WaitLoad()
    {
        yield return new WaitForSecondsRealtime(2.5f);
        SceneManager.LoadScene("Menu");
        Destroy(dontdestroyonload);
        /*
        transitionScript.GetComponent<Transition>().transition = true;
        if (transitionScript.GetComponent<Transition>()._transitionFinished == true)
        {
            SceneManager.LoadScene(nextSceneName);
            Destroy(dontdestroyonload);
        }
        */
    }

    IEnumerator playerSkin()
    {
        if (!pouleExplosion)
        {
            //my_liveSprite.SetActive(true);
            _deadExplosion.Play();
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
