using UnityEngine;
using System.Collections;

public class Scare : MonoBehaviour {
    public int type;
    public float magnitude;
    public bool canTrigger = true;

    public void Trigger() {
        transform.GetChild(0).gameObject.SetActive(!transform.GetChild(0).gameObject.activeSelf);
    }

    public void CanTrigger() {
        canTrigger = !canTrigger;
    }
}
