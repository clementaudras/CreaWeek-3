using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class EggGen : MonoBehaviour {
	
	public GameObject player;
	public GameObject eggPrefab;
	public float eggForcePower = 100f;
    public bool pond;
    public bool _isPlayer1;
    public bool slow = false;
    public bool _canLayEgg = false;
    public GameManager GM;
    public bool eggConfirmed;
    public GameObject Y;
    public GameObject B;
    public bool _layEgg;

    public Rigidbody2D rb;
    public PlayerController playerCtrlScript;

    Transform target;
	Transform targetPos;

	// Use this for initialization
	void Awake () {
		rb = player.GetComponent<Rigidbody2D>();
		target = player.GetComponent<PlayerController>().target;
		targetPos = player.GetComponent<PlayerController>().targetPos;
	}

    void LayEgg()
    {
        pond = true;
        Instantiate(eggPrefab, transform.position, Quaternion.identity);
        rb.AddRelativeForce((target.transform.position - transform.position).normalized * eggForcePower);
        slow = false;
        StartCoroutine("SlowDown");
        _layEgg = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        //slower over time
        if (slow)
        {
            rb.velocity = rb.velocity * 0.9f;
        }

        if (_layEgg)
        {
            LayEgg();
        }

        //instantiate egg with a button confirmation
        if(playerCtrlScript.GetComponent<PlayerController>().dirConfirmed == false)
        {
            if (eggConfirmed)
            {
                Y.SetActive(false);
                B.SetActive(true);
                Debug.Log(eggConfirmed);
                if (_isPlayer1)
                {
                    if (XCI.GetButtonDown(XboxButton.B, XboxController.First) || Input.GetKeyDown(KeyCode.E))
                    {
                        this.eggConfirmed = false;
                        GM.GetComponent<GameManager>().confirmation -= 1;
                        Debug.Log("p1 Removed 1");
                    }
                }
                else if (!_isPlayer1)
                {
                    if (XCI.GetButtonDown(XboxButton.B, XboxController.Second) || Input.GetKeyDown(KeyCode.E))
                    {
                        this.eggConfirmed = false;
                        GM.GetComponent<GameManager>().confirmation -= 1;
                        Debug.Log("p2 Removed 1");
                    }
                }
            }
            else if (!eggConfirmed)
            {
                Y.SetActive(true);
                B.SetActive(false);
                Debug.Log(eggConfirmed);
                if (_isPlayer1)
                {
                    if (XCI.GetButtonDown(XboxButton.Y, XboxController.First) || Input.GetKeyDown(KeyCode.R))
                    {
                        this.eggConfirmed = true;
                        GM.GetComponent<GameManager>().confirmation += 1;
                        Debug.Log("p1 Added 1");
                    }
                }
                else if (!_isPlayer1)
                {
                    if (XCI.GetButtonDown(XboxButton.Y, XboxController.Second) || Input.GetKeyDown(KeyCode.K))
                    {
                        this.eggConfirmed = true;
                        GM.GetComponent<GameManager>().confirmation += 1;
                        Debug.Log("p2 Added 1");
                    }
                }
            }
        }
    }

    IEnumerator SlowDown()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        slow = true;
        yield return null;
    }
}


