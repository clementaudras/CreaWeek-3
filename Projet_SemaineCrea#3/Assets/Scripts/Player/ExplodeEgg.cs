using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeEgg : MonoBehaviour {

    public bool _explode;
    public Egg eggScript;
    public Rigidbody2D rb_Egg;
    public GameObject mainCamera;
    GameManager Gm;
    public GameObject player;
    public bool _isPlayer1;
    int oldVar;

    // Use this for initialization
    void Start () {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        Gm = mainCamera.GetComponent<GameManager>();
        oldVar = Gm.p1_antiEggCount;
    }
	
	// Update is called once per frame
	void Update () {

        if(Gm.p1_antiEggCount > oldVar)
        {
            this.enabled = false;
        }

        if (_isPlayer1)
        {
            if (Gm.p1_eggCount >= 2)
            {
                _explode = true;
            }
        } else if (!_isPlayer1)
        {
            if (Gm.p2_eggCount >= 2)
            {
                _explode = true;
            }
        }


        if (_explode)
        {
            rb_Egg.simulated = false;
            eggScript.GetComponent<Egg>().eggHealthPoint = 0;
        }
	}
}
