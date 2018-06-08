using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlaqueFxLifeTime : MonoBehaviour {
    public float lifeTime;

	// Use this for initialization
	void Start () {
        StartCoroutine(FxLife());
	}

    public IEnumerator FxLife()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(this.gameObject);
        yield return null;
    }
}
