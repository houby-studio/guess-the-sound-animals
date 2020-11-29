using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>Holds Button components accessed via GameManager.
/// </summary>
public class QuizButton
{
    public QuizButton(ButtonLogic buttonComponent, Image imageComponent, TextMeshProUGUI nameComponent)
    {
        button = buttonComponent;
        image = imageComponent;
        name = nameComponent;
    }

    public ButtonLogic button;
    public Image image;
    public TextMeshProUGUI name;
}

/// <summary>Holds Item properties accessed via GameManager.
/// </summary>
public class QuizItem
{
    public QuizItem(Animal animal)
    {
        image = animal.getAnimalImage();
        backgroundImage = animal.getAnimalBackground();
        audio = animal.getAnimalSound();
    }

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

    [Header("GameData")]
    [SerializeField]
    private List<GameObject> items;

    public static GameManager instance;

    private List<QuizButton> quizButtons = new List<QuizButton>();
    private List<QuizItem> quizItems = new List<QuizItem>();
    private Image quizBackground;
    private int correctAnswerIndex = 0;

    void Awake()
    {
        // Set instance to this, so this whole script gets set to instance of the object we created above
        instance = this;
    }

    // Start is called before the first frame update
    private void Start()
    {
        // Obtain components from Button GameObjects
        for (var i = 0; i < buttons.Count; i++)
        {
            quizButtons.Add(new QuizButton(buttons[i].GetComponent<ButtonLogic>(), buttons[i].GetComponentInChildren<Image>(), buttons[i].GetComponentInChildren<TextMeshProUGUI>()));
            //Debug.Log("Created item:");
            //Debug.Log("Name: " + quizButtons[i].name);
            //Debug.Log("Test: " + quizButtons[i].button.test);
            //Debug.Log("Sprite: " + quizButtons[i].image.sprite);
        }
        // Obtain properties from Item GameObjects
        for (var i = 0; i < items.Count; i++)
        {
            quizItems.Add(new QuizItem(items[i].GetComponent<Animal>()));
            //Debug.Log("Created item:");
            //Debug.Log("Image: " + quizItems[i].image.name);
            //Debug.Log("Background Image: " + quizItems[i].backgroundImage.name);
            //Debug.Log("Audio: " + quizItems[i].audio.name);
        }
        // Obtain Background Image component from backgroundPanel GameObject
        quizBackground = backgroundPanel.GetComponent<Image>();
        NewQuiz();
    }

    public void NewQuiz()
    {
        System.Random rnd = new System.Random();

        // For each button obtain new Quiz item for next Quiz
        QuizItem[] newItems = quizItems.OrderBy(x => rnd.Next()).Take(buttons.Count).ToArray();
        // Set image and text for each button
        for (var i = 0; i < newItems.Length; i++)
        {
            quizButtons[i].name.text = newItems[i].image.name;
            quizButtons[i].image.sprite = newItems[i].image;
            Debug.Log(newItems[i].image.name);
        }
        // Select correct answer
        correctAnswerIndex = rnd.Next(buttons.Count);
        // Set background for correct answer
        quizBackground.sprite = newItems[correctAnswerIndex].backgroundImage;
    }
}
