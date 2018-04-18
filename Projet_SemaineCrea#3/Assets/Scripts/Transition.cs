using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour {

    public Transform target;
    public float speed;
    public bool _player1Won;
    public bool transition;
    public bool _transitionFinished;

    void Update()
    {
        if (transition)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            if(transform.position == target.transform.position)
            {
                _transitionFinished = true;
            }
        }
    }
}
