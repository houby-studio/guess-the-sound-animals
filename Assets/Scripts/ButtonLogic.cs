using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonLogic : MonoBehaviour
{
    public int buttonIndex;

    private Animator buttonAnimator;

    private void Start()
    {
        buttonAnimator = GetComponent<Animator>();
    }

    public void ButtonClick()
    {
        // If input is enabled, disable it and start coroutine for button press
        if (GameManager.instance.inputEnabled)
        {
            GameManager.instance.inputEnabled = false;
            StartCoroutine(GameManager.instance.PressButton(buttonIndex, buttonAnimator));
        }
    }

    // Play button animation, which triggers ChangeButton
    public void PlaySpin()
    {
        buttonAnimator.SetTrigger("Spin");
    }

    // Changes text and image to next Quiz item
    public void ChangeButton()
    {
        GameManager.instance.ChangeButton(buttonIndex);
    }
}
