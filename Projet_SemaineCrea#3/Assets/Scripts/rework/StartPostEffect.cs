using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class StartPostEffect : MonoBehaviour {
    public PostProcessingProfile poulusPostPross;

    // Use this for initialization
    void Start () {
        var dof = poulusPostPross.depthOfField.settings;

        dof.focusDistance = 0.05f;
        poulusPostPross.depthOfField.settings = dof;
    }
	
	// Update is called once per frame
	void Update () {

        var dof = poulusPostPross.depthOfField.settings;

        dof.focusDistance += 1f;

        if (dof.focusDistance >= 100f)
            dof.focusDistance = 100f;

        poulusPostPross.depthOfField.settings = dof;
    }
}
