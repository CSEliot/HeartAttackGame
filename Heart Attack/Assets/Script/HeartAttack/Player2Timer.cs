using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player2Timer : MonoBehaviour {

    public float timeRemaining = 180f;
    private int minutes;
    private int seconds;
    public Text p1TimerText;

	
	// Update is called once per frame
    void Update()
    {
        timeRemaining -= Time.deltaTime;
        minutes = (int)timeRemaining / 60;
        seconds = (int)timeRemaining % 60;

        if (timeRemaining >= 0)
        {
            p1TimerText.text = minutes.ToString() + ":" + (seconds < 10 ? ("0" + seconds.ToString()) : seconds.ToString());
            Debug.Log(minutes + ":" + (seconds < 10 ? ("0" + seconds.ToString()) : seconds.ToString()));
        }

    }
}
