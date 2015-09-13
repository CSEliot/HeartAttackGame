using UnityEngine;
using System.Collections;

public class Player2FreeRoamInput : MonoBehaviour {

    private Vector3 movement;
    public float speed;
    public SimpleSmoothMouseLook p2FreeLook;
    public Camera p2Camera;
    public float horizontalRight;
    public float verticalRight;

	// Use this for initialization
	void Start () {

        speed = 5f;

	
	}
	
	// Update is called once per frame
	void Update () {

        movement = Vector3.zero;

        p2FreeLook = p2Camera.GetComponent<SimpleSmoothMouseLook>();
        horizontalRight = -Input.GetAxis("Mouse X");
        verticalRight = Input.GetAxis("Mouse Y");
        p2FreeLook.LookInput(horizontalRight, verticalRight);
        

        if (Input.GetKey(KeyCode.W))
        {

            movement.z += speed;

        }

        if (Input.GetKey(KeyCode.S))
        {

            movement.z -= speed;

        }

        if (Input.GetKey(KeyCode.A))
        {

            movement.x -= speed;
        
        }

        if (Input.GetKey(KeyCode.D))
        {

            movement.x += speed;
        
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {

            movement.y -= speed;
        
        }

        if (Input.GetKey(KeyCode.Space))
        {

            movement.y += speed;
        
        }

        transform.Translate(movement * Time.deltaTime);
	
	}
}
