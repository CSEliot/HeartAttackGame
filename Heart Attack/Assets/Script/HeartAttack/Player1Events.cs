﻿using UnityEngine;
using System.Collections;

public class Player1Events : MonoBehaviour {

    public Camera p1Cam;
    private Ray ray;
    private RaycastHit hit;
    public float reachDistance;

    public delegate void P1EventHandler(GameObject item);
    public static event P1EventHandler lookItem;
    public static event P1EventHandler lookNothing;
    public static event P1EventHandler actionButtonPressed;

    public string lastName = "";

	// Use this for initialization
	void Start () {
        p1Cam = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
	    ray = p1Cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        if(Physics.Raycast(ray, out hit, reachDistance)){
            if (!CheckSameItem(hit.transform.name)){
                if (hit.transform.CompareTag("ItemPickup") || hit.transform.CompareTag("ItemGrab")){
                    //Debug.Log("Updating item text");
                    lastName = hit.transform.name;
                    LookingItem(hit.transform.gameObject);
                }else{
                    //Debug.Log("Item does not have correct tag");
                    lastName = hit.transform.name;
                    LookingNothing();
                }
            }

        }else{
            //Debug.Log("Raycast not hitting anything");
            lastName = "";
            LookingNothing();
        }
    }

    public bool CheckSameItem(string name)
    {
        return name.Equals(lastName);
    }

    public static void LookingItem(GameObject item){
        if(lookItem != null){
            lookItem(item);
        }
    }

    public static void LookingNothing(){
        if(lookNothing != null){
            lookNothing(null);
        }
    }

}