using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour {
    public bool player_1 = true;

    public Transform arrow;
		public Transform target;
        public Transform targetPos;

    public float horizontalSpeed = 100.0F;
	    public Rigidbody2D rb;
		public float forcePower = 50f;
		public bool slow = false;
    public bool reflect = false;
    public GameManager GM;
    public bool move;

	Vector3 velocityNormilze;
    Quaternion angle;
    Transform arrowTrans;
    Transform spriteTrans;

    public GameObject egg;

    //Vector3 currDir;
    public bool confirmed;

    void Start()
    {
        arrowTrans = transform.GetChild(1);
        spriteTrans = transform.GetChild(0);
        rb = GetComponent<Rigidbody2D>();
    }

    /*
    void FixedUpdate()
    {
        currDir = new Vector3(transform.position.x, transform.position.y, 0);
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Enter2D");
        Vector2 newDir = new Vector2(transform.position.x, transform.position.y);
        float newDirValue = Mathf.Atan2(newDir.y - currDir.y, newDir.x - currDir.x);
        float newDirValueDeg = (90 / Mathf.PI) * newDirValue;
        transform.rotation = Quaternion.Euler(0, 0, newDirValueDeg);
    }
    */
    void Update() {
        //debug
        //Vector3 targetDir = target.position - transform.position;

        //Vector3 newDir = Vector3.RotateTowards(transform.right, targetDir, 0f, 0.0f);
        //Debug.DrawRay(transform.position, newDir, Color.red);

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

                // ANGLE GUN
                arrow.transform.rotation = Quaternion.AngleAxis(aim_angle, Vector3.forward);
            }
        }

		            //eggs
            if (Input.GetButtonDown("p1_RightBumper") || Input.GetButtonDown("p2_RightBumper"))
            {
                Debug.Log("Instantiate Egg and move player.");
            }

        /*
        if (x != 0.0f || y != 0.0f)
        {
            float angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
            // Do something with the angle here.
            arrow.rotation = angle;
        }
        */
        //with keys
        if (Input.GetKey(KeyCode.Q))
			arrow.Rotate(Vector3.forward * horizontalSpeed * Time.deltaTime);
      
		if (Input.GetKey(KeyCode.D))
			arrow.Rotate(-Vector3.forward * horizontalSpeed * Time.deltaTime);


        //Confirmation de la direction a prendre
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







        if (reflect)
        {

            /*
            RaycastHit hit;

            if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, 10f))
            {
                Vector2 incomingV = hit.normal - transform.position;
                //Vector3 reflectV = Vector3.Reflect(incomingV, hit.normal);
                //Debug.DrawRay(hit.point, reflectV, Color.green, 10f);
                Vector2.Reflect(incomingV, hit.normal);
                Vector2 outboundDirection = Vector2.Reflect(incomingV, hit.normal);
                //Transform hitBounce = PoolManager.Pools["AMMO"].Spawn("BoltReflected");
                //transform.position = hit.point;
                //transform.eulerAngles = reflectV;
            }
            */
        }

        //Debug.DrawLine(transform.position, newDir * 100f, Color.red);

        //Xbox 360 controller 1

        //Xbox 360 controller 2

        //Slow velocity over time
        if (slow){
		    rb.velocity = rb.velocity * 0.9f;
		}
        /*
        if(Input.GetKey(KeyCode.S)){
    Debug.Log(rb.velocity);
    //rb.velocity = Vector3.zero;
    rb.velocity = rb.velocity * 0.01f;
}
*/


        if (GM.GetComponent<GameManager>().confirmation != 0)
        {
            angle = arrowTrans.rotation;

        }
        else
        {

            spriteTrans.rotation = angle;
        }

        //Press button "A" to go fast
        if (move)
        {
                Debug.Log("move");
                slow = false;
                //rb.AddRelativeForce(Vector3.forward * 100f);
                rb.AddRelativeForce((target.transform.position - transform.position).normalized * forcePower);
                StartCoroutine("SlowDown");
                move = false;
				//transform.rotation = Quaternion.LookRotation(rb.velocity, Vector3.right);
        }
    }


    

    IEnumerator SlowDown()
    {
        yield return new WaitForSecondsRealtime(2.5f);
        slow = true;
        yield return null;
    }
}
	 
	 
