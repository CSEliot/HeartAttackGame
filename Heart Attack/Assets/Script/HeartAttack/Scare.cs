using UnityEngine;
using System.Collections;

public class Scare : MonoBehaviour {
    public int type;
    public float magnitude;
    public bool canTrigger = true;

    public void CanTrigger() {
        canTrigger = !canTrigger;
    }
}
