using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour {
    public bool player_1 = true;

    public Transform arrow;
		public Transform target;
        public Transform targetPos;

        private float horizontalSpeed = 100.0F;
	    public Rigidbody2D rb;
		public float forcePower = 50f;
		public bool slow = false;
    public bool reflect = false;
    public GameManager GM;
    public bool move;

	private Quaternion _lookRotation;

	Vector3 velocityNormilze;
    Quaternion angle;
    Transform arrowTrans;
    Transform spriteTrans;

    public GameObject egg;
    public GameObject fakeEgg;

	//Debug Velocity Direction
	public Vector3 velocityVector;
	public Vector3 directionVel;

	//

    //Vector3 currDir;
    public bool confirmed;

    void Start()
    {
        arrowTrans = transform.GetChild(1);
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
            //with josticks
            float aim_angle = 0.0f;
            float x = Input.GetAxis("p1_Horizontal");
            float y = Input.GetAxis("p1_Vertical");

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

                //with josticks
                float aim_angle = 0.0f;
                float x = Input.GetAxis("p2_Horizontal");
                float y = Input.GetAxis("p2_Vertical");

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

        //with keys
        if (Input.GetKey(KeyCode.Q))
			arrow.Rotate(Vector3.forward * horizontalSpeed * Time.deltaTime);
      
		if (Input.GetKey(KeyCode.D))
			arrow.Rotate(-Vector3.forward * horizontalSpeed * Time.deltaTime);


        //Direction confirmation
        if (confirmed)
        {
            target.transform.parent = null;
            if (Input.GetKeyDown(KeyCode.B) || Input.GetButtonDown("b_p1") || Input.GetButtonDown("b_p2"))
            {
                confirmed = false;
                GM.GetComponent<GameManager>().confirmation -= 1;
            }
        } else if (!confirmed) {
            target.transform.parent = targetPos.transform;
            target.position = targetPos.position;
            target.rotation = targetPos.rotation;
            if (Input.GetKeyDown(KeyCode.A) || Input.GetButtonDown("a_p1") || Input.GetButtonDown("a_p2"))
            {
                confirmed = true;
                GM.GetComponent<GameManager>().confirmation += 1;
            }
        }

        //slower over time
        if (slow){
		    rb.velocity = rb.velocity * 0.9f;
		}

        //if all player have confirmed -> Move chiken
        if (move)
        {
                fakeEgg.SetActive(false);
                slow = false;
                rb.AddRelativeForce((target.transform.position - transform.position).normalized * forcePower);
                StartCoroutine("SlowDown");
                move = false;
        }
    }

    IEnumerator SlowDown()
    {
        yield return new WaitForSecondsRealtime(2.5f);
        slow = true;
        yield return null;
    }
}
