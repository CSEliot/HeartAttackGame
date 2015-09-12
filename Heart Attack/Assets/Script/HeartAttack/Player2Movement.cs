using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Player2Movement : MonoBehaviour {

    public GameObject[] cameras;
    public int currentCamera = 0;
    public GameObject canvas;

    private Rigidbody rb;
    public float thrust = 2.0f;
    private Vector3 directionVector = Vector3.zero;
    private float directionLength;
    public float distToGround;

    public Collider p1Collider;

    private Vector2 horizontalRotationLimit = new Vector2(-45.0f, 45.0f);
    private Vector2 verticalRotationLimit = new Vector2(-10f, 10f);
    private Vector4 rotationLimit;
    public float deadzone = 0.1f;

    void Awake(){
        rb = GetComponent<Rigidbody>();
    }

    void Start(){
        canvas = GameObject.Find("Canvas (1)");
        cameras = GameObject.FindGameObjectsWithTag("Statue");
        for (int i = 1; i < cameras.Length; i++) {
            cameras[i].SetActive(false);
        }
    }

    public void MoveInput(float horizontal)
    {
        if (horizontal != 0) {
            cameras[currentCamera].SetActive(false);
            currentCamera += (int)horizontal;
            if (currentCamera >= cameras.Length) {
                currentCamera = 0;
            } else if (currentCamera < 0) {
                currentCamera = cameras.Length - 1;
            }
            cameras[currentCamera].SetActive(true);
            canvas.GetComponent<Canvas>().worldCamera = cameras[currentCamera].GetComponent<Camera>();
        }
    }

    public bool IsGrounded(){
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.2f);
    }

    // Update is called once per frame
    void Update()
    {

        if (directionVector != Vector3.zero)
        {
            // Get the length of the directon vector and then normalize it
            // Dividing by the length is cheaper than normalizing when we already have the length anyway
            directionLength = directionVector.magnitude;
            directionVector = directionVector / directionLength;

            // Make sure the length is no bigger than 1
            directionLength = Mathf.Min(1.0f, directionLength);

            // Make the input vector more sensitive towards the extremes and less sensitive in the middle
            // This makes it easier to control slow speeds when using analog sticks
            directionLength = directionLength * directionLength;

            // Multiply the normalized direction vector by the modified length
            directionVector = directionVector * directionLength;

            if (directionVector.magnitude < deadzone)
            {
                directionVector = Vector2.zero;
            }
            else
            {
                directionVector = directionVector.normalized * ((directionVector.magnitude - deadzone) / (1 - deadzone));
            }

        }

    }

    void FixedUpdate()
    {
        if (IsGrounded())
        {
            rb.velocity = transform.rotation * directionVector * thrust;
            //Debug.Log(rb.velocity);
        }
    }
}
