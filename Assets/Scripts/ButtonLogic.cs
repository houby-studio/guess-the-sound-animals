using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonLogic : MonoBehaviour
{
    public string test;

    private TextMeshProUGUI text;
    private void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void ButtonClick()
    {
        GameManager.instance.NewQuiz();
        //text.text = gameManager.GetComponent<LockScreen>().StartLockScreen();
        //text.text += "C";
    }
}
