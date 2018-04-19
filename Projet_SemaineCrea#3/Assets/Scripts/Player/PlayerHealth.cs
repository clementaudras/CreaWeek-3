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
    public GameObject _player1;
    public GameObject _player2;

    GameObject dontDestroyon;
    bool _isDead;
    bool _canAddScore = true;

    ParticleSystem my_deadExplosion;
    GameObject my_liveSprite;
    ParticleSystem his_deadExplosion;
    GameObject his_liveSprite;
	int pouleExplosion = 0;

    // Use this for initialization
    void Start() {
        if (_isPlayer1)
        {

            my_liveSprite = _player1.transform.parent.parent.GetChild(2).GetChild(1).gameObject;
            his_deadExplosion = _player2.transform.parent.parent.GetChild(2).GetChild(0).GetComponent<ParticleSystem>();

        }
        if (!_isPlayer1)
        {

            my_liveSprite = _player2.transform.parent.parent.GetChild(2).GetChild(1).gameObject;
            his_deadExplosion = _player1.transform.parent.parent.GetChild(2).GetChild(0).GetComponent<ParticleSystem>();

        }
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

			StartCoroutine(playerSkin());

            _player1.SetActive(false);
            _player2.SetActive(false);

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

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (_isPlayer1)
        {
            if (other.CompareTag("P2Egg"))
            {
                Destroy(other.transform.parent.gameObject);
                playerHealth = 0;
            }
        } else if (!_isPlayer1)
        {
            if (other.CompareTag("P1Egg"))
            {
                Destroy(other.transform.parent.gameObject);
                playerHealth = 0;
            }
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

	IEnumerator playerSkin()
	{
		if (pouleExplosion ==0){
            my_liveSprite.SetActive(true);
            his_deadExplosion.Play();
		}

			pouleExplosion+=1;
			yield return null;

	}
}
