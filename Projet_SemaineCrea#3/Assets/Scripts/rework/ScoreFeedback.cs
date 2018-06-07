using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreFeedback : MonoBehaviour {
    RectTransform scoreTr;
    public bool _feedback = false;
    float _uniScale = 0.2f;

	// Use this for initialization
	void Start () {
        scoreTr = this.gameObject.GetComponent<RectTransform>();
        scoreTr.localScale = new Vector3(_uniScale, _uniScale, _uniScale);
    }
	
	// Update is called once per frame
	void Update () {
        scoreTr.localScale = new Vector3(_uniScale, _uniScale, _uniScale);

        if (_feedback)
        {
            _uniScale += 2.3f;
        }
        if (_uniScale >= 0.2f)
        {
            _feedback = false;
            _uniScale -= 0.1f;

            if (_uniScale <= 0.2f)
            {
                _uniScale = 0.2f;
            }
        }

    }
}
