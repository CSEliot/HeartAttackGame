﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class HeartRate : MonoBehaviour {
    const int NUM_SCARE_TYPES = 2;

    private float hRScale = 0f;
    private float heartRate;
    private float calmRate = -0.1f;
    private float timeWhenEnds;
    private bool scaredRecently;
    private Slider hrBar;

    void Start() {
        hrBar = GameObject.Find("Slider").GetComponent<Slider>();
        InvokeRepeating("LowerHR", 10f, 10f);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Tab)) {
            ChangeHR(1);
        }

        hrBar.value = Mathf.Lerp(hrBar.value, (heartRate - 70f) / (140f), Time.deltaTime);
    }

    void LowerHR() {
        ChangeHR(calmRate);
    }

    void Scared(float magnitude) {
        ChangeHR(magnitude);
    }
    

    void ChangeHR(float magnitude) {
        hRScale += magnitude;
        if (hRScale < 0) {
            hRScale = 0;
        }
        heartRate = Mathf.Sqrt(hRScale) * 70f + 70f;
    }

	void OnTriggerEnter(Collider other) {
        Scare s = other.gameObject.GetComponent<Scare>();
        if (s != null && s.canTrigger) {
            Scared(s.magnitude);
            s.canTrigger = false;
            s.Invoke("CanTrigger", 30f);
        }
    }
}
