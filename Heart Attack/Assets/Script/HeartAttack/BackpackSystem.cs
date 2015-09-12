using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BackpackSystem : MonoBehaviour {

    public Animator[] animators = new Animator[4];

    void Start()
    {
        Player1Input.dpadPressed += UpdateAnimators;
    }

    void UpdateAnimators(Player1Input.DpadInputs input)
    {
        for(int i = 0; i < 4; i++)
        {
            animators[i].SetBool("UIDpadAnim", i == (int)input);
        }
    }
}
