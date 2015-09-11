using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Require a character controller to be attached to the same game object
[RequireComponent(typeof(Player1Movement))]
[AddComponentMenu("Character/FPS Input Controller")]

public class Player1Input : MonoBehaviour
{

    public Player1Movement p1Movement;
    public SimpleSmoothMouseLook p1Look;
    public float horizontal;
    public float vertical;
    public float horizontalRight;
    public float verticalRight;

    void Awake()
    {
        p1Movement = GetComponent<Player1Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        //horizontal = Input.GetAxis("Horizontal_P1");  //360 Controller
        //vertical = Input.GetAxis("Vertical_P1");
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        //horizontalRight = Input.GetAxis("HorizontalRight_P1");
        //verticalRight = Input.GetAxis("VerticalRight_P1");
        horizontalRight = -Input.GetAxis("Mouse X");
        verticalRight = Input.GetAxis("Mouse Y");

        p1Movement.MoveInput(horizontal, vertical);
        p1Look.LookInput(horizontalRight, verticalRight);
    }
}