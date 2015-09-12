﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BackpackSystem : MonoBehaviour {


    public Animator[] animators = new Animator[4];
    public Transform player;
    public GameObject properLookItem;
    private Ray ray;
    public Camera p1Cam;
    Rigidbody body;

    public Image[] uiImages = new Image [4];
    public GameObject[] backpackSlots = new GameObject[4];
    bool hasItemGrab = false;

    void Start() {
        player = GetComponent<Transform>();
        Player1Input.dpadPressed += UpdateAnimators;
        Player1Input.aButtonAndDpad += AddLookItem;
        Player1Events.lookItem += StoreLookItem;
    }

    void Update() {
        if (properLookItem != null) { Debug.Log(properLookItem.name); }
        if (hasItemGrab) {
            ray = p1Cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
            if (body != null) { body.transform.position = ray.GetPoint(2); }
        }
    }


    void UpdateAnimators(Player1Input.DpadInputs input) {
        for (int i = 0; i < 4; i++) {
            animators[i].SetBool("UIDpadAnim", i == (int)input);
        }
    }

    void StoreLookItem(GameObject item) {
        properLookItem = item;
    }

    void AddLookItem(Player1Input.DpadInputs input) {
        ray = p1Cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));

        if(properLookItem != null) {
            if (hasItemGrab) {
                Debug.Log("Has item");
                Debug.Log(properLookItem.name);
                properLookItem.transform.SetParent(null);
                body.useGravity = true;
                hasItemGrab = false;
            } else if (properLookItem.CompareTag("ItemGrab")) {
                if (properLookItem != null) {
                    properLookItem.transform.SetParent(player.transform);
                    body = properLookItem.GetComponent<Rigidbody>();
                    body.useGravity = false;
                    body.transform.position = ray.GetPoint(2);
                    hasItemGrab = true;
                }
            } else if (properLookItem.CompareTag("ItemPickup")) {//Add item to backpack
                    properLookItem.transform.SetParent(player);
                    body = properLookItem.GetComponent<Rigidbody>();
                    body.useGravity = false;
                    body.transform.gameObject.SetActive(false);
                    if (backpackSlots[(int)input] != null) {
                        backpackSlots[(int)input].SetActive(true);
                        backpackSlots[(int)input].transform.SetParent(null);
                        backpackSlots[(int)input] = properLookItem;
                    }
                    //Debug.Log(properLookItem.name);
                    backpackSlots[(int)input] = properLookItem;
                    uiImages[(int)input].sprite = properLookItem.GetComponent<Item>().spriteImage;
                    properLookItem = null;
            }
        }
      
    }
}
