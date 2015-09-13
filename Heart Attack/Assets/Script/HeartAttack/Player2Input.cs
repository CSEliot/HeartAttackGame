using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Require a character controller to be attached to the same game object
[RequireComponent(typeof(Player2Movement))]
[AddComponentMenu("Character/FPS Input Controller")]

public class Player2Input : MonoBehaviour
{

    public Player2Movement p2Movement;
    public SimpleSmoothMouseLook p2Look;
    public float horizontal;
    public float vertical;
    public float horizontalRight;
    public float verticalRight;

    void Awake()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        p2Movement = GetComponent<Player2Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        p2Look = p2Movement.cameras[p2Movement.currentCamera].GetComponent<SimpleSmoothMouseLook>();
        //horizontal = Input.GetAxis("Horizontal_P1");  //360 Controller
        //vertical = Input.GetAxis("Vertical_P1");
        horizontal = (Input.GetButtonDown("Left_P2") ? -1 : 0) + (Input.GetButtonDown("Right_P2") ? 1 : 0);
        //horizontalRight = Input.GetAxis("HorizontalRight_P1");
        //verticalRight = Input.GetAxis("VerticalRight_P1");
        horizontalRight = -Input.GetAxis("Mouse X");
        verticalRight = Input.GetAxis("Mouse Y");

        p2Movement.MoveInput(horizontal);
        p2Look.LookInput(horizontalRight, verticalRight);
    }
}