using UnityEngine;
using System.Collections;

public class Scare : MonoBehaviour {
    public int type;
    public float magnitude;
    public bool canTrigger = false;
    private AudioSource audio;

    void Start() {
        audio = GetComponent<AudioSource>();
    }
    public void Trigger() {
        if (audio != null) {
            audio.Play();
        }
        gameObject.GetComponent<SphereCollider>().enabled = true;
        canTrigger = true;
        transform.GetChild(0).gameObject.SetActive(!transform.GetChild(0).gameObject.activeSelf);
        Invoke("TurnOff", 1f);
    }

    void TurnOff() {
        gameObject.GetComponent<SphereCollider>().enabled = false;
    }
    //public void CanTrigger() {
    //    canTrigger = !canTrigger;
    //}
}
