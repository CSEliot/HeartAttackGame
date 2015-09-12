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

    public int dpadNumber;

    public enum DpadInputs { Up, Down, Left, Right };

    public delegate void P1DpadHandler(DpadInputs input);
    public static event P1DpadHandler dpadPressed;

    void Awake()
    {
        p1Movement = GetComponent<Player1Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        //horizontal = Input.GetAxis("Horizontal_P1");  //360 Controller
        //vertical = Input.GetAxis("Vertical_P1");
        horizontal = Input.GetAxis("Horizontal_P1");
        vertical = Input.GetAxis("Vertical_P1");
        //horizontalRight = Input.GetAxis("HorizontalRight_P1");
        //verticalRight = Input.GetAxis("VerticalRight_P1");
        horizontalRight = -Input.GetAxis("HorizontalRight_P1");
        verticalRight = Input.GetAxis("VerticalRight_P1");

        p1Movement.MoveInput(horizontal, vertical);
        p1Look.LookInput(horizontalRight, verticalRight);

        Debug.Log(Input.GetAxis("DpadHorizontal_P1"));

        if (Input.GetAxisRaw("DpadHorizontal_P1") == -1){
            //Debug.Log("Dpad horizontal -1");
            DpadCall(DpadInputs.Left);
        }else if (Input.GetAxisRaw("DpadHorizontal_P1") ==  1){
            //Debug.Log("Dpad horizontal 1");
            DpadCall(DpadInputs.Right);
        }
        else if (Input.GetAxisRaw("DpadVertical_P1") == 1){
           // Debug.Log("Dpad vertical 1");
            DpadCall(DpadInputs.Up);
        }
        else if (Input.GetAxisRaw("DpadVertical_P1") == -1){
            //Debug.Log("Dpad vertical -1");
            DpadCall(DpadInputs.Down);
        }
    }

    public static void DpadCall(DpadInputs dpadVal)
    {
        if (dpadPressed != null)
        {
            dpadPressed(dpadVal);
        }
    }

}