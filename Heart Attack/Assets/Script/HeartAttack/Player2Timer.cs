using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player2Timer : MonoBehaviour {

    public float timeRemaining = 180f;
    private int minutes;
    private int seconds;
    public Text p1TimerText;

	
    void Start() {
        GameObject canvas = GameObject.Find("P2Canvas");
        canvas.GetComponent<Canvas>().worldCamera = gameObject.GetComponent<Camera>();
    }
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
        } else {
            gameObject.GetComponent<Player2Movement>().enabled = true;
            gameObject.GetComponent<Player2Input>().enabled = true;
            gameObject.GetComponent<Player2FreeRoamInput>().enabled = false;
            gameObject.GetComponent<Player2FreeRoamMovement>().enabled = false;
            enabled = false;
            gameObject.GetComponent<Player2Movement>().cameras[0].SetActive(true);
            gameObject.GetComponentInChildren<Camera>().enabled = false;
        }

    }
}
