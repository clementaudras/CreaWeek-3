using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class EggGen : MonoBehaviour {
	
	public GameObject player;
	public GameObject eggPrefab;
	public float eggForcePower = 10f;
    public bool pond;
    public bool _isPlayer1;
    bool slow = false;
    public bool _canLayEgg = false;
    public GameManager GM;
    public bool eggConfirmed;
    public GameObject Y;
    public GameObject B;
    public bool _layEgg;
    public bool _explodeEgg;
    
    public Rigidbody2D rb;
    public PlayerController playerCtrlScript;

    Transform target;
	Transform targetPos;

    GameObject fakeEgg;

    public Animator animatorUI;
    bool p1_hasConfirmedEgg;
    bool p2_hasConfirmedEgg;
    bool p1_canCancelEgg;
    bool p2_canCancelEgg;
    public bool p1_canSelectEgg = true;
    public bool p2_canSelectEgg = true;

    public bool cancelAct;
    public bool validAct;



    // Use this for initialization
    void Awake () {
		rb = player.GetComponent<Rigidbody2D>();
		target = player.GetComponent<PlayerController>().target;
		targetPos = player.GetComponent<PlayerController>().targetPos;
        fakeEgg = this.transform.GetChild(3).gameObject;
	}

    void ExplodeEgg()
    {
        _explodeEgg = false;
    }

    void LayEgg()
    {
        fakeEgg.SetActive(false);
        pond = true;
        Instantiate(eggPrefab, transform.position, Quaternion.identity);
        //rb.AddRelativeForce((target.transform.position - transform.position).normalized * eggForcePower);
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
            slow = false;
        }

        if (_explodeEgg)
        {
            ExplodeEgg();
        }


        if (_layEgg)
        {
            LayEgg();
        }

        //new
        if (playerCtrlScript.GetComponent<PlayerController>().dirConfirmed == false)
        {
            if (_isPlayer1)
            {
                if (XCI.GetButtonDown(XboxButton.Y, XboxController.First) || Input.GetKeyDown(KeyCode.E))
                {
                    if (p1_canSelectEgg)
                    {
                        animatorUI.SetBool("Press_B", false);
                        animatorUI.SetBool("Press_A", false);
                        animatorUI.SetBool("Start", true);
                        p1_hasConfirmedEgg = true;
                        validAct = true;
                    }
                }

                if (p1_hasConfirmedEgg)
                {
                    if (XCI.GetButtonDown(XboxButton.A, XboxController.First))
                    {
                        animatorUI.SetBool("Press_B", false);
                        animatorUI.SetBool("Press_A", true);
                        animatorUI.SetBool("Start", false);
                        this.eggConfirmed = true;
                        GM.GetComponent<GameManager>().confirmation += 1;
                        //Debug.Log("p1 Added 1");
                        p1_hasConfirmedEgg = false;
                        p1_canCancelEgg = true;
                        p1_canSelectEgg = false;
                        validAct = true;
                    }

                    if(XCI.GetButtonDown(XboxButton.B, XboxController.First))
                    {
                        animatorUI.SetBool("Press_B", true);
                        animatorUI.SetBool("Press_A", false);
                        animatorUI.SetBool("Start", false);
                        this.eggConfirmed = false;
                        //GM.GetComponent<GameManager>().confirmation -= 1;
                        //Debug.Log("p1 Removed 1");
                        p1_hasConfirmedEgg = false;
                        p1_canCancelEgg = false;
                        p1_canSelectEgg = true;
                        cancelAct = true;
                    }
                }

                if (p1_canCancelEgg)
                {
                    if (XCI.GetButtonDown(XboxButton.B, XboxController.First))
                    {
                        animatorUI.SetBool("Press_B", true);
                        animatorUI.SetBool("Press_A", false);
                        animatorUI.SetBool("Start", false);
                        this.eggConfirmed = false;
                        GM.GetComponent<GameManager>().confirmation -= 1;
                        //Debug.Log("p1 Removed 1");
                        p1_hasConfirmedEgg = false;
                        p1_canCancelEgg = false;
                        p1_canSelectEgg = true;
                        cancelAct = true;
                    }
                }
            }
            else if (!_isPlayer1)
            {
                if (XCI.GetButtonDown(XboxButton.Y, XboxController.Second) || Input.GetKeyDown(KeyCode.E))
                {
                    if (p2_canSelectEgg)
                    {
                        animatorUI.SetBool("Press_B", false);
                        animatorUI.SetBool("Press_A", false);
                        animatorUI.SetBool("Start", true);
                        p2_hasConfirmedEgg = true;
                    }
                }

                if (p2_hasConfirmedEgg)
                {
                    if (XCI.GetButtonDown(XboxButton.A, XboxController.Second))
                    {
                        animatorUI.SetBool("Press_B", false);
                        animatorUI.SetBool("Press_A", true);
                        animatorUI.SetBool("Start", false);
                        this.eggConfirmed = true;
                        GM.GetComponent<GameManager>().confirmation += 1;
                        //Debug.Log("p2 Added 1");
                        p2_hasConfirmedEgg = false;
                        p2_canCancelEgg = true;
                        p2_canSelectEgg = false;
                    }

                    if (XCI.GetButtonDown(XboxButton.B, XboxController.Second))
                    {
                        animatorUI.SetBool("Press_B", true);
                        animatorUI.SetBool("Press_A", false);
                        animatorUI.SetBool("Start", false);
                        this.eggConfirmed = false;
                        //GM.GetComponent<GameManager>().confirmation -= 1;
                        //Debug.Log("p2 Removed 1");
                        p2_hasConfirmedEgg = false;
                        p2_canCancelEgg = false;
                        p2_canSelectEgg = true;
                    }
                }

                if (p2_canCancelEgg)
                {
                    if (XCI.GetButtonDown(XboxButton.B, XboxController.Second))
                    {
                        animatorUI.SetBool("Press_B", true);
                        animatorUI.SetBool("Press_A", false);
                        animatorUI.SetBool("Start", false);
                        this.eggConfirmed = false;
                        GM.GetComponent<GameManager>().confirmation -= 1;
                        //Debug.Log("p2 Removed 1");
                        p2_hasConfirmedEgg = false;
                        p2_canCancelEgg = false;
                        p2_canSelectEgg = true;
                    }
                }
            }
        }
            
        //old
        //instantiate egg with a button confirmation
        /*
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
        //
        */
    }

    IEnumerator SlowDown()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        slow = true;
        yield return null;
    }
}


