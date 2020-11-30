using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonLogic : MonoBehaviour
{
    private Animator buttonAnimator;

    private void Start()
    {
        buttonAnimator = GetComponent<Animator>();
    }

    public void ButtonClick()
    {
        GameManager.instance.NewQuiz();
        //buttonAnimator.Play("Wrong");
        buttonAnimator.SetTrigger("Wrong");
        //buttonAnimator.SetBool("Wrong", false);
    }
}
