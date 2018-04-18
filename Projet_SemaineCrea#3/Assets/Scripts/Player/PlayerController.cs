using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class PlayerController : MonoBehaviour {
    public bool player_1 = true;
	public AnimationCurve varCurve;
    public Transform arrow;
		public Transform target;
        public Transform targetPos;

        private float horizontalSpeed = 100.0f;
	    public Rigidbody2D rb;
		public float forcePower = 100f;
	bool slow = false;
    public bool reflect = false;
    public GameManager GM;
    public bool move;

	private Quaternion _lookRotation;

	Vector3 velocityNormilze;
    Quaternion angle;
    Transform spriteTrans;

    public GameObject egg;
    public GameObject fakeEgg;

	//Debug Velocity Direction
	public Vector3 velocityVector;
	public Vector3 directionVel;

	//

    //Vector3 currDir;
    public bool dirConfirmed;


    public GameObject OK;
    public GameObject A;
    public GameObject B;


    public EggGen eggGenScript;

	public Animator animatorUI;
	bool p1_hasConfirmed;
	bool p2_hasConfirmed;
	bool p1_canCancel;
	bool p2_canCancel;
	public bool p1_canSelectDir = true;
	public bool p2_canSelectDir = true;

    void Start()
    {

        spriteTrans = transform.GetChild(0);
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {

        //rebond aligner
        Debug.DrawLine(transform.position, directionVel, Color.magenta);
        velocityVector = rb.velocity.normalized;
        directionVel = velocityVector + transform.position;
        spriteTrans.LookAt(directionVel);

        //Controller input
        if (player_1)
        {
            //with keys
            if (Input.GetKey(KeyCode.Q))
                arrow.Rotate(Vector3.forward * horizontalSpeed * Time.deltaTime);

            if (Input.GetKey(KeyCode.D))
                arrow.Rotate(-Vector3.forward * horizontalSpeed * Time.deltaTime);

            //with josticks
            float aim_angle = 0.0f;
            float x = XCI.GetAxis(XboxAxis.LeftStickX, XboxController.First);
            float y = XCI.GetAxis(XboxAxis.LeftStickY, XboxController.First);
            //float x = Input.GetAxis("p1_Horizontal");
            //float y = Input.GetAxis("p1_Vertical");

            // CANCEL ALL INPUT BELOW THIS FLOAT
            float R_analog_threshold = 0.10f;

            if (Mathf.Abs(x) < R_analog_threshold) { x = 0.0f; }

            if (Mathf.Abs(y) < R_analog_threshold) { y = 0.0f; }

            // CALCULATE ANGLE AND ROTATE
            if (x != 0.0f || y != 0.0f)
            {

                aim_angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;

                // ANGLE ARROW
                arrow.transform.rotation = Quaternion.AngleAxis(aim_angle, Vector3.forward);
            }
        } else if (!player_1) {
            //with keys
            if (Input.GetKey(KeyCode.LeftArrow))
                arrow.Rotate(Vector3.forward * horizontalSpeed * Time.deltaTime);

            if (Input.GetKey(KeyCode.RightArrow))
                arrow.Rotate(-Vector3.forward * horizontalSpeed * Time.deltaTime);

            //with josticks
            float aim_angle = 0.0f;
                float x = XCI.GetAxis(XboxAxis.LeftStickX, XboxController.Second);
                float y = XCI.GetAxis(XboxAxis.LeftStickY, XboxController.Second);
                //float x = Input.GetAxis("p1_Horizontal");
                //float y = Input.GetAxis("p1_Vertical");

                // CANCEL ALL INPUT BELOW THIS FLOAT
                float R_analog_threshold = 0.10f;

                if (Mathf.Abs(x) < R_analog_threshold) { x = 0.0f; }

                if (Mathf.Abs(y) < R_analog_threshold) { y = 0.0f; }

                // CALCULATE ANGLE AND ROTATE
                if (x != 0.0f || y != 0.0f)
                {

                    aim_angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;

                    // ANGLE ARROW
                    arrow.transform.rotation = Quaternion.AngleAxis(aim_angle, Vector3.forward);
                }
        }




        //Direction confirmation
        if(eggGenScript.GetComponent<EggGen>().eggConfirmed == false)
        {
		//new
		if(player_1){
			if (XCI.GetButtonDown(XboxButton.LeftStick, XboxController.First) || Input.GetKeyDown(KeyCode.A))
                    {
						if(p1_canSelectDir){
							animatorUI.SetBool("Press_B", false);
							animatorUI.SetBool("Press_A", false);
							animatorUI.SetBool("Start", true);
							p1_hasConfirmed = true;
							target.transform.parent = null;
						}
                    }
					
					if(p1_hasConfirmed){
						if (XCI.GetButtonDown(XboxButton.A, XboxController.First)) {
							animatorUI.SetBool("Press_B", false);
							animatorUI.SetBool("Press_A", true);
							animatorUI.SetBool("Start", false);
							this.dirConfirmed = true;
							GM.GetComponent<GameManager>().confirmation += 1;
							//Debug.Log("p1 Added 1");
							p1_hasConfirmed = false;
							p1_canCancel = true;
							p1_canSelectDir = false;
						}

							if (XCI.GetButtonDown(XboxButton.B, XboxController.First)) {
								animatorUI.SetBool("Press_B", true);
								animatorUI.SetBool("Press_A", false);
								animatorUI.SetBool("Start", false);
								this.dirConfirmed = false;
								StartCoroutine(WaitToReParent());
								//GM.GetComponent<GameManager>().confirmation -= 1;
								//Debug.Log("p1 Removed 1");
								p1_hasConfirmed = false;
								p1_canCancel = false;
								p1_canSelectDir = true;
							}


							}
							if(p1_canCancel){
								if (XCI.GetButtonDown(XboxButton.B, XboxController.First)) {
								animatorUI.SetBool("Press_B", true);
								animatorUI.SetBool("Press_A", false);
								animatorUI.SetBool("Start", false);
								this.dirConfirmed = false;
								StartCoroutine(WaitToReParent());
								GM.GetComponent<GameManager>().confirmation -= 1;
								//Debug.Log("p1 Removed 1");
								p1_hasConfirmed = false;
								p1_canCancel = false;
								p1_canSelectDir = true;
							}
					}
		}else if (!player_1){
				if (XCI.GetButtonDown(XboxButton.LeftStick, XboxController.Second) || Input.GetKeyDown(KeyCode.P))
                    {
						if(p2_canSelectDir){
							animatorUI.SetBool("Press_B", false);
							animatorUI.SetBool("Press_A", false);
							animatorUI.SetBool("Start", true);
							p2_hasConfirmed = true;
							target.transform.parent = null;
						}
                    }
					
					if(p2_hasConfirmed){
						if (XCI.GetButtonDown(XboxButton.A, XboxController.Second)) {
							animatorUI.SetBool("Press_B", false);
							animatorUI.SetBool("Press_A", true);
							animatorUI.SetBool("Start", false);
							this.dirConfirmed = true;
							GM.GetComponent<GameManager>().confirmation += 1;
							//Debug.Log("p1 Added 1");
							p2_hasConfirmed = false;
							p2_canCancel = true;
							p2_canSelectDir = false;
						}

							if (XCI.GetButtonDown(XboxButton.B, XboxController.Second)) {
								animatorUI.SetBool("Press_B", true);
								animatorUI.SetBool("Press_A", false);
								animatorUI.SetBool("Start", false);
								this.dirConfirmed = false;
								StartCoroutine(WaitToReParent());
								//GM.GetComponent<GameManager>().confirmation -= 1;
								//Debug.Log("p1 Removed 1");
								p2_hasConfirmed = false;
								p2_canCancel = false;
								p2_canSelectDir = true;
							}


							}
							if(p2_canCancel){
								if (XCI.GetButtonDown(XboxButton.B, XboxController.Second)) {
								animatorUI.SetBool("Press_B", true);
								animatorUI.SetBool("Press_A", false);
								animatorUI.SetBool("Start", false);
								this.dirConfirmed = false;
								StartCoroutine(WaitToReParent());
								GM.GetComponent<GameManager>().confirmation -= 1;
								//Debug.Log("p1 Removed 1");
								p2_hasConfirmed = false;
								p2_canCancel = false;
								p2_canSelectDir = true;
							}
		}
		}
		///old
		/*
            if (dirConfirmed)
            {
                A.SetActive(false);
                B.SetActive(true);
                //target.transform.parent = null;
                if (player_1)
                {
                    if (XCI.GetButtonDown(XboxButton.B, XboxController.First) || Input.GetKeyDown(KeyCode.E))
                    {
                        _hasConfirmed = true;
						StartCoroutine(WaitToReParent());
                    }

					if(_hasConfirmed){
						if (XCI.GetButtonDown(XboxButton.B, XboxController.First)) {
							animatorUI.SetBool("Press_B", true);
							animatorUI.SetBool("Press_A", false);
							animatorUI.SetBool("Start", false);
							this.dirConfirmed = false;
							GM.GetComponent<GameManager>().confirmation -= 1;
							Debug.Log("p1 Removed 1");
							}
					}
                }
                else if (!player_1)
                {
                    if (XCI.GetButtonDown(XboxButton.B, XboxController.Second) || Input.GetKeyDown(KeyCode.M))
                    {
                        this.dirConfirmed = false;
                        GM.GetComponent<GameManager>().confirmation -= 1;
                        Debug.Log("p2 Removed 1");
                    }
                }
            }
            else if (!dirConfirmed)
            {
                A.SetActive(true);
                B.SetActive(false);

                //StartCoroutine(WaitToReParent());
                //target.position = targetPos.position;
                //target.rotation = targetPos.rotation;

                if (player_1)
                {
                    if (XCI.GetButtonDown(XboxButton.LeftStick, XboxController.First) || Input.GetKeyDown(KeyCode.A))
                    {
							animatorUI.SetBool("Press_B", false);
							animatorUI.SetBool("Press_A", false);
							animatorUI.SetBool("Start", true);
                        _hasConfirmed = true;
                        target.transform.parent = null;
                    }
					
					if(_hasConfirmed){
						if (XCI.GetButtonDown(XboxButton.A, XboxController.First)) {
							animatorUI.SetBool("Press_B", false);
							animatorUI.SetBool("Press_A", true);
							animatorUI.SetBool("Start", true);
							this.dirConfirmed = true;
							GM.GetComponent<GameManager>().confirmation += 1;
							Debug.Log("p1 Added 1");
							}

						if (XCI.GetButtonDown(XboxButton.B, XboxController.First)) {
							animatorUI.SetBool("Press_B", true);
							animatorUI.SetBool("Press_A", false);
							animatorUI.SetBool("Start", false);
							this.dirConfirmed = false;
							GM.GetComponent<GameManager>().confirmation -= 1;
							Debug.Log("p1 Removed 1");
							}
					}
                }
                else if (!player_1)
                {
                    if (XCI.GetButtonDown(XboxButton.LeftStick, XboxController.Second) || Input.GetKeyDown(KeyCode.L))
                    {
						animatorUI.SetBool("Start", true);

                        this.dirConfirmed = true;
                        GM.GetComponent<GameManager>().confirmation += 1;
                        Debug.Log("p2 Added 1");
                    }
                }
            }
			*/
        }

        if(rb.velocity.magnitude < 0.1)
        {
            StopCoroutine(SlowDown());
        }

        //slower over time
        if (slow){
		    rb.velocity = rb.velocity * 0.9f;
		}

        Debug.DrawLine(transform.position, (target.transform.position - transform.position).normalized * 100f, Color.yellow);

        //if all player have confirmed -> Move chicken
        if (move)
        {
                fakeEgg.SetActive(false);
                slow = false;
                //rb.AddRelativeForce((target.transform.position - transform.position).normalized * 100f);
                
                StartCoroutine("SlowDown");
                move = false;
        }
    }

    IEnumerator SlowDown()
    {
        rb.AddForce((target.transform.position - transform.position).normalized * 100f);
        yield return new WaitForSecondsRealtime(2.5f);
        slow = true;
        yield return null;
    }

    private IEnumerator WaitToReParent()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        target.transform.parent = targetPos.transform;
        target.position = targetPos.position;
        yield return null;
    }
}
