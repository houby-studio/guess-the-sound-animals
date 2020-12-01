using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;
using UnityEngine.UI;

/// <summary>Holds Button components accessed via GameManager.
/// </summary>
public class QuizButton
{
    public QuizButton(ButtonLogic buttonComponent, Image imageComponent, LocalizedString nameComponent)
    {
        button = buttonComponent;
        image = imageComponent;
        name = nameComponent;
    }

    public ButtonLogic button;
    public Image image;
    public LocalizedString name;
}

/// <summary>Holds Item properties accessed via GameManager.
/// </summary>
public class QuizItem
{
    public QuizItem(Animal animal)
    {
        itemName = animal.GetAnimalName();
        image = animal.GetAnimalImage();
        backgroundImage = animal.GetAnimalBackground();
        audio = animal.GetAnimalSound();
    }

    public string itemName;
    public Sprite image;
    public Sprite backgroundImage;
    public AudioClip audio;
}

/// <summary>Game Manager takes care of things like generating random quizes, displaying images and text, playing sound etc.
/// </summary>
public class GameManager : MonoBehaviour
{
    [Header("Components")]
    [SerializeField]
    private List<GameObject> buttons;
    [SerializeField]
    private GameObject backgroundPanel;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private TextMeshProUGUI correctItemName;

    [Header("GameData")]
    [SerializeField]
    private List<GameObject> items;

    public static GameManager instance;
    public bool inputEnabled = true;

    private List<QuizButton> quizButtons = new List<QuizButton>();
    private List<QuizItem> quizItems = new List<QuizItem>();
    private Image quizBackground;
    private int correctAnswerIndex = 0;
    private QuizItem correctAnswerItem;
    private QuizItem[] newItems;

    private void Awake()
    {
        // Set instance to this, so this whole script gets set to instance of the object we created above
        instance = this;
    }

    private void Start()
    {
        // Obtain components from Button GameObjects
        for (var i = 0; i < buttons.Count; i++)
        {
            quizButtons.Add(new QuizButton(buttons[i].GetComponent<ButtonLogic>(), buttons[i].GetComponentInChildren<Image>(), buttons[i].GetComponentInChildren<LocalizeStringEvent>().StringReference));
            quizButtons[i].button.buttonIndex = i;
        }
        // Obtain properties from Item GameObjects
        for (var i = 0; i < items.Count; i++)
        {
            quizItems.Add(new QuizItem(items[i].GetComponent<Animal>()));
        }
        // Obtain Background Image component from backgroundPanel GameObject
        quizBackground = backgroundPanel.GetComponent<Image>();
        NewQuiz(true);
#if UNITY_EDITOR
        correctItemName.enabled = true;
#endif
    }

    private void NewQuiz(bool firstRun = false)
    {
        System.Random rnd = new System.Random();

        // For each button obtain new Quiz item for next Quiz
        newItems = quizItems.OrderBy(x => rnd.Next()).Take(buttons.Count).ToArray();
        // Set image and text for each button
        for (var i = 0; i < newItems.Length; i++)
        {
            // Do not run spin animation on first run
            if (firstRun)
            {
                quizButtons[i].name.TableEntryReference = newItems[i].itemName;
                quizButtons[i].image.sprite = newItems[i].image;
            }
            else
            {
                // Spin button and switch image mid spin
                quizButtons[i].button.PlaySpin();
            }
        }
        // Select correct answer - not same item as before
        do
        {
            correctAnswerIndex = rnd.Next(buttons.Count);
        }
        while (correctAnswerItem == newItems[correctAnswerIndex]);
        // Correct answer item
        correctAnswerItem = newItems[correctAnswerIndex];
        // Set background for correct answer
        quizBackground.sprite = correctAnswerItem.backgroundImage;
        // Display name for correct item - Debug only
#if UNITY_EDITOR
        correctItemName.text = correctAnswerItem.itemName;
#endif
        // Play sound for correct answer
        PlaySound();
        // Enable input
        inputEnabled = true;
    }

    private void PlaySound()
    {
        audioSource.PlayOneShot(correctAnswerItem.audio);
    }

    public IEnumerator PressButton(int buttonIndex, Animator anim)
    {
        // Play button animation for correct or wrong answer
        if (buttonIndex == correctAnswerIndex)
            anim.SetTrigger("Right");
        else
            anim.SetTrigger("Wrong");

        // Wait until current animation finishes
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);

        // Generate new Quiz when answer was correct or enable input if answer was wrong
        if (buttonIndex == correctAnswerIndex)
            NewQuiz();
        else
            inputEnabled = true;

        //yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
    }

    public void ChangeButton(int index)
    {
        // Called from ButtonLogic on Animation Event
        quizButtons[index].name.TableEntryReference = newItems[index].itemName;
        quizButtons[index].image.sprite = newItems[index].image;
    }
}
