using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

    public int playerHealth = 100;
    public bool _isPlayer1;
    public Score scoreScript;
    public GameObject blueWinScreen;
    public GameObject redWinScreen;
    public Transition transitionScript;
    
    GameObject dontDestroyon;
    bool _isDead;
    bool _canAddScore = true;

    // Use this for initialization
    void Start () {
		
	}
	
    public void AddScore()
    {
        
        _isDead = false;
        _canAddScore = false;
        Debug.Log("Player is dead.");
        if (_isPlayer1)
        {
            scoreScript.scoreRed += 1;
        }
        else if (!_isPlayer1)
        {
            scoreScript.scoreBlue += 1;
        }
    }

	// Update is called once per frame
	void Update () {
        if (dontDestroyon == null)
            dontDestroyon = GameObject.Find("DontDestroyOnLoad");


        if (playerHealth <= 0)
        {
            _isDead = true;
            scoreScript = (Score)FindObjectOfType(typeof(Score));


            StartCoroutine(NextPhase());
        }

        if (scoreScript.scoreRed == 3)
        {
            Debug.Log("RED WIN");
            redWinScreen.SetActive(true);
            StartCoroutine(WaitLoad());
        }

        if (scoreScript.scoreBlue == 3)
        {
            Debug.Log("BLUE WIN");
            blueWinScreen.SetActive(true);
            StartCoroutine(WaitLoad());
        }
    }

    IEnumerator WaitLoad()
    {
        yield return new WaitForSecondsRealtime(1f);
        transitionScript.GetComponent<Transition>().transition = true;
        if (transitionScript.GetComponent<Transition>()._transitionFinished == true)
        {
            SceneManager.LoadScene("Menu");
            Destroy(dontDestroyon);
        }
    }

    IEnumerator NextPhase()
    {
        if (_canAddScore)
            AddScore();

        yield return new WaitForSecondsRealtime(2.5f);

        if (scoreScript.scoreRed != 3 && scoreScript.scoreBlue != 3)
        {
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
