using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject gameManager;
    private TextMeshProUGUI text;
    private void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void ButtonClick()
    {
        text.text += "a";
        //text.text = gameManager.GetComponent<LockScreen>().StartLockScreen();
        //text.text += "C";
    }
}
