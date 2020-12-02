using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLogic : MonoBehaviour
{
    public int buttonIndex;
    public Image image;

    private Animator buttonAnimator;
    private TextMeshProUGUI text;

    private void Start()
    {
        buttonAnimator = GetComponent<Animator>();
        image = GetComponentInChildren<Image>();
        text = GetComponentInChildren<TextMeshProUGUI>();
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

    public void HideButton()
    {
        text.enabled = false;
        image.sprite = GameManager.instance.cardbackImage;
    }

    // Changes text and image to next Quiz item
    public void ChangeButton()
    {
        text.enabled = true;
        GameManager.instance.ChangeButton(buttonIndex);
    }
}
