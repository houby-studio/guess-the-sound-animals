using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animal : MonoBehaviour
{
    [Header("Animal Properties")]
    [SerializeField]
    private Image animalImage;
    [SerializeField]
    private AudioClip animalSound;
    [SerializeField]
    private Image animalBackground;

    public Image getAnimalImage()
    {
        return animalImage;
    }

    public AudioClip getAnimalSound()
    {
        return animalSound;
    }

    public Image getAnimalBackground()
    {
        return animalBackground;
    }
}
