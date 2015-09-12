using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HeartRate : MonoBehaviour {
    const int NUM_SCARE_TYPES = 1;

    private float rate = 0;
    private int scaredByLights = 0;
    private float timeWhenEnds;
    private int[] scaredBy = new int[NUM_SCARE_TYPES];

    void Start() {
        InvokeRepeating("LowerRate", 1f, 1f);
    }

    void LowerRate() {
        rate -= 0.1f;
        if (rate < 0) {
            rate = 0;
        }
    }
    void Scared(int type, int magnitude) {
        StartCoroutine(Unscared(type));
        scaredBy[type]++;
        ChangeRate(type, magnitude);
    }

    IEnumerator Unscared(int type) {
        yield return new WaitForSeconds(2f);
        scaredBy[type]--;
    }

    void ChangeRate(int type, int magnitude) {
        scaredByLights++;
        float product = 1f;
        for (int i = 0; i < NUM_SCARE_TYPES; i++) {
            if (i == type) {
                product /= scaredBy[i];
            } else {
                product *= scaredBy[i];
            }
        }
        rate += magnitude * product;
        Debug.Log(rate);
    }

	void OnTriggerEnter(Collider other) {
        Scare s = other.gameObject.GetComponent<Scare>();
        if (s != null) {
            Scared(s.type, s.magnitude);
        }
    }
}
