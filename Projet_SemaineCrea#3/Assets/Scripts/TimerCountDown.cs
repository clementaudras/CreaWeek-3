using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerCountDown : MonoBehaviour {
	public int timeLeft = 5;
	public Text timerText;
	public bool _startTimer;
	public bool _timesUp;
	void Update () {

		if(_startTimer){
			timerText.text = (timeLeft.ToString());
			//InvokeRepeating("AddValue", 1, 1);
			StartCoroutine(Timer());
		} else if (!_startTimer){
			timeLeft = 5;
				timerText.text = "";

		}
					if(timeLeft <= 0){
			timeLeft = 0;
				//StopCoroutine(Timer());
				_timesUp = true;
				_startTimer = false;
			}

	}


	void AddValue(){
		timeLeft --;
	}

	IEnumerator Timer(){
		while(true){
				yield return new WaitForSecondsRealtime(1f);
					timeLeft = 4;
									yield return new WaitForSecondsRealtime(1f);
					timeLeft = 3;
									yield return new WaitForSecondsRealtime(1f);
					timeLeft = 2;
									yield return new WaitForSecondsRealtime(1f);
					timeLeft = 1;
									yield return new WaitForSecondsRealtime(1f);
					timeLeft = 0;
		}
	}
}
