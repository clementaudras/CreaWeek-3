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
        yield return new WaitForSecondsRealtime(5f);
        SceneManager.LoadScene("Menu");
        Destroy(dontDestroyon);
    }

    IEnumerator NextPhase()
    {
        if (_canAddScore)
            AddScore();

        yield return new WaitForSecondsRealtime(2.5f);
        //SceneManager.LoadScene("Menu");

        if (scoreScript.scoreRed != 3 && scoreScript.scoreBlue != 3)
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
        /*
        else if(scoreScript.scoreRed == 3 || scoreScript.scoreBlue != 3)
        {
            Debug.Log("RED WIN");
            redWinScreen.SetActive(true);
            yield return new WaitForSecondsRealtime(2.5f);
            SceneManager.LoadScene("Menu");
        }
        else if (scoreScript.scoreRed != 3 || scoreScript.scoreBlue == 3)
        {
            Debug.Log("BLUE WIN");
            blueWinScreen.SetActive(true);
            yield return new WaitForSecondsRealtime(2.5f);
            SceneManager.LoadScene("Menu");
        }
        
        if (scoreScript.scoreRed == 3)
        {
            redWinScreen.SetActive(true);
            yield return new WaitForSecondsRealtime(2.5f);
            SceneManager.LoadScene("Menu");
        }

        if(scoreScript.scoreBlue == 3)
        {
            blueWinScreen.SetActive(true);
            yield return new WaitForSecondsRealtime(2.5f);
            SceneManager.LoadScene("Menu");
        }
        */
        yield return null;
    }
}
