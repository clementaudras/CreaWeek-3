using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderIgnore : MonoBehaviour {

    [Header ("Player 1")]
    public Collider2D P1_TRIG;
    public Collider2D P1_COL;

    [Header("Player 2")]
    public Collider2D P2_TRIG;
    public Collider2D P2_COL;

    [Header("Player 3")]
    public Collider2D P3_TRIG;
    public Collider2D P3_COL;

    [Header("Player 4")]
    public Collider2D P4_TRIG;
    public Collider2D P4_COL;

    // Update is called once per frame
    void LateUpdate () {

        //PLAYER 1 & PLAYER 2
        //Trigger 1 ignore collider 2
        Physics2D.IgnoreCollision(P1_TRIG, P2_COL, true);

        //Trigger 2 ignore collider 1
        Physics2D.IgnoreCollision(P2_TRIG, P1_COL, true);


        //PLAYER 1 & PLAYER 3
        //Trigger 1 ignore collider 3
        Physics2D.IgnoreCollision(P1_TRIG, P3_COL, true);

        //Trigger 3 ignore collider 1
        Physics2D.IgnoreCollision(P3_TRIG, P1_COL, true);


        //PLAYER 1 & PLAYER 4
        //Trigger 1 ignore collider 4
        Physics2D.IgnoreCollision(P1_TRIG, P4_COL, true);

        //Trigger 4 ignore collider 1
        Physics2D.IgnoreCollision(P4_TRIG, P1_COL, true);


        //PLAYER 2 & PLAYER 3
        //Trigger 3 ignore collider 3
        Physics2D.IgnoreCollision(P2_TRIG, P3_COL, true);

        //Trigger 3 ignore collider 1
        Physics2D.IgnoreCollision(P3_TRIG, P2_COL, true);


        //PLAYER 2 & PLAYER 4
        //Trigger 2 ignore collider 4
        Physics2D.IgnoreCollision(P2_TRIG, P4_COL, true);

        //Trigger 4 ignore collider 2
        Physics2D.IgnoreCollision(P4_TRIG, P2_COL, true);


        //PLAYER 3 & PLAYER 4
        //Trigger 3 ignore collider 4
        Physics2D.IgnoreCollision(P3_TRIG, P4_COL, true);

        //Trigger 4 ignore collider 3
        Physics2D.IgnoreCollision(P4_TRIG, P3_COL, true);

    }
}
