using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animal : MonoBehaviour
{
    [Header("Animal Properties")]
    [SerializeField]
    private string animalName;
    [SerializeField]
    private Sprite animalImage;
    [SerializeField]
    private AudioClip animalSound;
    [SerializeField]
    private Sprite animalBackground;

    public string GetAnimalName()
    {
        return animalName;
    }

    public Sprite GetAnimalImage()
    {
        return animalImage;
    }

    public AudioClip GetAnimalSound()
    {
        return animalSound;
    }

    public Sprite GetAnimalBackground()
    {
        return animalBackground;
    }
}
