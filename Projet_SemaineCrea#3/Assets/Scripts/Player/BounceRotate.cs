using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceRotate : MonoBehaviour {
	
	Vector3 currDir;
	
	void FixedUpdate() {
         currDir = new Vector3(transform.position.x, transform.position.y, 0);
     }

	void OnCollisionEnter2D(Collision2D other) {
		Vector3 newDir = new Vector3(transform.position.x, transform.position.y, 0);
		float newDirValue = Mathf.Atan2(newDir.y - currDir.y, newDir.x - currDir.x);
		float newDirValueDeg = (180 / Mathf.PI) * newDirValue;
		transform.rotation = Quaternion.Euler(0, 0, newDirValueDeg);
	}
}
