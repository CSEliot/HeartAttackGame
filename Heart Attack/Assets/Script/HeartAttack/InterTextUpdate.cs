using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InterTextUpdate : MonoBehaviour {

    public Text itemText;
    public Animator crossAnim;
    public Animator textAnim;

	// Use this for initialization
	void Start () {
        itemText = GetComponent<Text>();
        itemText.text = "";
        Player1Events.lookItem += ItemTextUpdate;
        Player1Events.lookNothing += ItemTextClear;
	}

    private void ItemTextUpdate(GameObject item)
    {
        crossAnim.SetBool("ChangeCrossHairAnim", true);
        itemText.text = "Pick up " + item.transform.name;
        textAnim.SetBool("TextAlphaTrigger", true);
    }

    private void ItemTextClear(GameObject item)
    {
        crossAnim.SetBool("ChangeCrossHairAnim", false);
        textAnim.SetBool("TextAlphaTrigger", false);
        itemText.text = "";
    }
}
