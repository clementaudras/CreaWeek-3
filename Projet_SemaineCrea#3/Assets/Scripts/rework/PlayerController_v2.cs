using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class PlayerController_v2 : MonoBehaviour {
    [Header("THE PLAYER")]
    //Integers and Floats
    [Range(1, 4)]
    public int playerNum;

    public float flaquePower = 10f;
    private float horizontalSpeed = 100.0f;

    //Scripts References
    //public EggGen eggGenScript;
    public GameManager_v2 GM;
    
    //GameObject References
    public GameObject ui_ready;
    public GameObject eggPrefab;

    //Bool
    [HideInInspector] public bool p1_hasConfirmed;
    bool p2_hasConfirmed;
    bool p3_hasConfirmed;
    bool p4_hasConfirmed;
    bool p1_canCancel;
    bool p2_canCancel;
    bool p3_canCancel;
    bool p4_canCancel;

    bool p1_hasConfirmedEgg;
    bool p2_hasConfirmedEgg;
    bool p3_hasConfirmedEgg;
    bool p4_hasConfirmedEgg;
    bool p1_canCancelEgg;
    bool p2_canCancelEgg;
    bool p3_canCancelEgg;
    bool p4_canCancelEgg;

    [HideInInspector] public bool p1_canSelectEgg = true;
    [HideInInspector] public bool p2_canSelectEgg = true;
    [HideInInspector] public bool p1_canSelectDir = true;
    [HideInInspector] public bool p2_canSelectDir = true;
    [HideInInspector] public bool p3_canSelectDir = true;
    [HideInInspector] public bool p4_canSelectDir = true;

    private bool _flaqueAct = false;
    private bool _destroyFlaque = false;
    
    //[HideInInspector] public bool cancelAct;
    //[HideInInspector] public bool validAct;
    [HideInInspector] public bool dirConfirmed;
    public bool eggConfirmed;
    public bool move;
    

    //Other
    public Transform target;
    public Transform targetPos;
    [HideInInspector] public Vector3 vectorDirPlayer;
    Transform spriteTrans;
    public Rigidbody2D rb;
    public Animator animatorUI;
    public Transform arrow;
    XboxController xboxCtrl;

    //Debug Velocity Direction
    [HideInInspector] public Vector3 velocityVector;
    [HideInInspector] public Vector3 directionVel;
    public bool _canCancel;

    //EGG GEN
    [Header("EGG GENERATION")]
    public float eggForcePower = 10f;
    public bool _explodeEgg;
    public GameObject fakeEgg;
    bool slow = false;
    public bool pond;
    public bool _layEgg;
    public bool egged;

    //FLAQUE
    [Header("FLAQUE")]
    public FlaqueNewDirection flaqueDirectionScript;
    public GameObject flaqueTarget;
    public GameObject flaqueFX_prefab;
    public bool _canInstantiate = true;
    void Awake()
    {
        p1_hasConfirmed = true;
        //fakeEgg = this.transform.GetChild(3).gameObject;
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
        slow = false;
        StartCoroutine("SlowDown");
        _layEgg = false;
    }

    // Use this for initialization
    void Start () {
        vectorDirPlayer = target.transform.position - transform.position;
        spriteTrans = transform.GetChild(0);
        rb = GetComponent<Rigidbody2D>();

        if (this.playerNum == 1)
            xboxCtrl = XboxController.First;

        if (this.playerNum == 2)
            xboxCtrl = XboxController.Second;

        if (this.playerNum == 3)
            xboxCtrl = XboxController.Third;

        if (this.playerNum == 4)
            xboxCtrl = XboxController.Fourth;
    }

    // Update is called once per frame
    void Update () {

        //egg
        /*
        if (slow)
        {
            rb.velocity = rb.velocity * 0.9f;
        }
        */

        if (_explodeEgg)
        {
            ExplodeEgg();
        }


        if (_layEgg)
        {
            LayEgg();
        }

        //Debug
        Debug.DrawLine(transform.position, (target.transform.position - transform.position).normalized * 100f, Color.yellow);
        Debug.DrawLine(transform.position, (flaqueTarget.transform.position - transform.position).normalized * 100f, Color.blue);

        //Align chicken with velocity
        Debug.DrawLine(transform.position, directionVel, Color.magenta);
        velocityVector = rb.velocity.normalized;
        directionVel = velocityVector + transform.position;
        spriteTrans.LookAt(directionVel);

        #region CONTROLLER INPUTS FOR ALL PLAYERS
        //CONTROLLER INPUTS FOR ALL PLAYERS

            //with josticks
            float aim_angle = 0.0f;
            float x = XCI.GetAxis(XboxAxis.LeftStickX, xboxCtrl);
            float y = XCI.GetAxis(XboxAxis.LeftStickY, xboxCtrl);

            // CANCEL ALL INPUT BELOW THIS FLOAT
            float R_analog_threshold = 0.0f;

            if (Mathf.Abs(x) < R_analog_threshold) { x = 0.0f; }

            if (Mathf.Abs(y) < R_analog_threshold) { y = 0.0f; }

            // CALCULATE ANGLE AND ROTATE
            if (x != 0.0f || y != 0.0f)
            {
                aim_angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
                
                // ANGLE ARROW
                arrow.transform.rotation = Quaternion.AngleAxis(aim_angle, Vector3.forward);
            }
        #endregion

        #region MECHANICS INPUTS FOR ALL PLAYERS

        //MECHANICS INPUTS FOR ALL PLAYERS
        if (XCI.GetButtonDown(XboxButton.LeftStick, xboxCtrl) || Input.GetKeyDown(KeyCode.A)) //choose a direction
        {
           // if (p1_canSelectDir)
           // {
                //animatorUI.SetBool("Press_B", false);
                //animatorUI.SetBool("Press_A", false);
                //animatorUI.SetBool("Start", true);
                //      p1_hasConfirmed = true;
                //validAct = true;
                //target.transform.parent = null;
           // }
        }

        if (p1_hasConfirmed)
        {
            if (XCI.GetButtonDown(XboxButton.A, xboxCtrl) || Input.GetKeyDown(KeyCode.Z)) //move in the choosed direction
            {
            target.transform.parent = null;
            _canCancel = true;
                GM.GetComponent<GameManager_v2>().confirmation += 1;
                //animatorUI.SetBool("Press_B", false);
                //animatorUI.SetBool("Press_A", true);
                //animatorUI.SetBool("Start", true);
                this.dirConfirmed = true;
                ui_ready.SetActive(true);
                p1_hasConfirmed = false;
                //validAct = true;
                //p1_canCancel = true;
                p1_canSelectDir = false;
                p1_canSelectEgg = false;
            }

            if (XCI.GetButtonDown(XboxButton.Y, xboxCtrl) || Input.GetKeyDown(KeyCode.Y)) //lay an egg, and move a little
            {
                if (p1_canSelectEgg)
                {
                target.transform.parent = null;
                _canCancel = true;
                    ui_ready.SetActive(true);
                    GM.GetComponent<GameManager_v2>().confirmation += 1;
                    //animatorUI.SetBool("Press_B", false);
                    //animatorUI.SetBool("Press_A", true);
                    //animatorUI.SetBool("Start", false);
                    p1_hasConfirmedEgg = true;
                    //validAct = true;
                    p1_hasConfirmed = false;
                    p1_canSelectDir = false;
                    this.eggConfirmed = true;
                }
            }

        }

        if (XCI.GetButtonDown(XboxButton.B, xboxCtrl)) //cancel action
        {
            if (_canCancel)
            {
                GM.GetComponent<GameManager_v2>().confirmation -= 1;
                _canCancel = false;
            }

            animatorUI.SetBool("Press_B", true);
            animatorUI.SetBool("Press_A", false);
            animatorUI.SetBool("Start", false);
            this.dirConfirmed = false;
            this.eggConfirmed = false;
            StartCoroutine(WaitToReParent());
            ui_ready.SetActive(false);
            p1_hasConfirmed = true;
            //p1_canCancel = false;
            p1_canSelectDir = true;
            //cancelAct = true;
            p1_hasConfirmedEgg = false;
            //p1_canCancelEgg = false;
            p1_canSelectEgg = true;
        }

        if (rb.velocity.magnitude < 0.1)
        {
            StopCoroutine(SlowDown());
        }

        //slower over time
        if (slow)
        {
            rb.velocity = rb.velocity * 0.9f;
            if (rb.velocity.magnitude <= 0.01f)
                slow = false;
        }

        Debug.DrawLine(transform.position, (target.transform.position - transform.position).normalized * 100f, Color.yellow);
        //if all player have confirmed -> Move chicken
        if (move)
        {
            fakeEgg.SetActive(false);
            slow = false;
            StartCoroutine(SlowDown());
            move = false;
            _canCancel = false;
        }

        //if all player have confirmed -> Move chicken
        if (egged)
        {
            fakeEgg.SetActive(false);
            slow = false;
            StartCoroutine(EggedSlowDown());
            egged = false;
            _canCancel = false;
        }
        Flaque();
    }
    #endregion

    void Flaque()
    {
        if (_flaqueAct)
        {
            StartCoroutine(Wait1());
            flaqueDirectionScript.newDirectionAngle += 25;

            StartCoroutine(FlaqueWait());
        }
    }

    //Flaque
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Flaque")) {
            _flaqueAct = true;
            other.transform.position = new Vector3(0f, 100f, 0f);
            //Destroy(other.gameObject);
            if (_destroyFlaque)
            {
                
                _destroyFlaque = false;
            }

            //StartCoroutine(FlaqueEffect());
        }
    }
    public IEnumerator Wait1()
    {
        

        yield return new WaitForSeconds(0.2f);
        rb.velocity = rb.velocity * 0f;
        Instantiate(flaqueFX_prefab, this.transform.position, Quaternion.identity);

        if (_canInstantiate)
        {
            _canInstantiate = false;
        }
        
        if (flaqueDirectionScript.newDirectionAngle >= 360)
            flaqueDirectionScript.newDirectionAngle = 0;

        Vector3 flakVect = (flaqueTarget.transform.position - transform.position).normalized + transform.position;
        spriteTrans.LookAt(flakVect);
        yield return new WaitForSeconds(1.5f);

        yield return null;
    }
    public IEnumerator FlaqueWait()
    {
        yield return new WaitForSeconds(1.5f);
        _flaqueAct = false;
        _destroyFlaque = true;
        rb.AddForce((flaqueTarget.transform.position - transform.position).normalized * 5f);
        slow = true;
        _canInstantiate = true;
        yield return null;
    }

    public IEnumerator SlowDown()
    {
        rb.AddForce((target.transform.position - transform.position).normalized * 100f);
        yield return new WaitForSeconds(2.5f);
        slow = true;
        yield return null;
    }

    public IEnumerator EggedSlowDown()
    {
        rb.AddForce((target.transform.position - transform.position).normalized * 10f);
        yield return new WaitForSeconds(0.01f);
        slow = true;
        yield return null;
    }

    public IEnumerator FlaqueDestroyWait()
    {
        yield return new WaitForSeconds(0.01f);

        yield return null;
    }

    public IEnumerator FlaqueEffect()
    {


        rb.velocity = rb.velocity * 0f;



        yield return new WaitForSeconds(0.01f);
        Vector3 flakVect = (flaqueTarget.transform.position - transform.position).normalized + transform.position;
        spriteTrans.LookAt(flakVect);


        flaqueDirectionScript.newDirectionAngle += 1;

        if (flaqueDirectionScript.newDirectionAngle >= 360)
            flaqueDirectionScript.newDirectionAngle = 0;
        
        /*
      flaqueDirectionScript.newDirectionAngle = Random.Range(0, 360);
        */


        yield return new WaitForSeconds(1.5f);
        flaqueDirectionScript.newDirectionAngle = Random.Range(0, 360);
        yield return new WaitForSeconds(0.01f);
        rb.AddForce((flaqueTarget.transform.position - transform.position).normalized * 100f);
        yield return new WaitForSeconds(1f);
        slow = true;
        yield return null;
    }

    public IEnumerator WaitToReParent()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        target.transform.parent = targetPos.transform;
        target.position = targetPos.position;
        yield return null;
    }
}
