using UnityEngine;
using System.Collections;

public class Player2Events : MonoBehaviour {

    public Camera p2Cam;
    private Ray ray;
    private RaycastHit hit;
    public float reachDistance;

    ////   public delegate void P1EventHandler(GameObject item);
    ////   public static event P1EventHandler lookItem;
    ////   public static event P1EventHandler lookNothing;
    ////   public static event P1EventHandler actionButtonPressed;
    ////   public ScaryScript scaryValue;

    ////   public float sanityMeter;
    ////   public string lastName = "";

    ////// Use this for initialization
    void Start() {
        p2Cam = GetComponent<Camera>();
        //sanityMeter = 100f;
    }

    //// Update is called once per frame
    void Update() {
        ray = p2Cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        if (Physics.Raycast(ray, out hit, reachDistance)) {
            if (hit.transform.CompareTag("Interactable") && Input.GetButtonDown("Click_P2")) {
                Debug.Log("clicked interactable");
                GameObject light = hit.transform.GetChild(0).gameObject;
                light.SetActive(!light.activeSelf);
            }

            //if (hit.transform.GetComponent<ScaryScript>() != null)
            //{
            //    scaryValue = hit.transform.GetComponent<ScaryScript>();
            //    if (scaryValue.Value > 0)
            //    {
            //        sanityMeter -= scaryValue.Value;
            //        //Remove comment to see value decrease. Does not end game when 0 is reached yet
            //        //Debug.Log("New sanity value is " + sanityMeter);
            //    }
            //}

        } else {
            Debug.Log("Raycast not hitting anything");
            //lastName = "";
            //LookingNothing();
        }
    }

    //   public bool CheckSameItem(string name)
    //   {
    //       return name.Equals(lastName);
    //   }

    //   public static void LookingItem(GameObject item){
    //       if(lookItem != null){
    //           lookItem(item);
    //       }
    //   }

    //   public static void LookingNothing() {
    //       if (lookNothing != null) {
    //           lookNothing(null);
    //       }
    //   }

}
