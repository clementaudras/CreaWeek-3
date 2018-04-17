using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

    public int playerHealth = 100;
    public bool _isPlayer1;
    public Score scoreScript;
    bool _isDead;
    bool _canAddScore = true;

    // Use this for initialization
    void Start () {
		
	}
	
    public void AddScore()
    {
        scoreScript = (Score)FindObjectOfType(typeof(Score));
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
		if(playerHealth <= 0)
        {
            _isDead = true;

            

            StartCoroutine(NextPhase());
        }
	}

    IEnumerator NextPhase()
    {
        if (_canAddScore)
            AddScore();

        yield return new WaitForSecondsRealtime(2.5f);
        //SceneManager.LoadScene("Menu");
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        yield return null;
    }
}
