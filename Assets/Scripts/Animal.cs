using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animal : MonoBehaviour
{
    [Header("Animal Properties")]
    [SerializeField]
    private Sprite animalImage;
    [SerializeField]
    private AudioClip animalSound;
    [SerializeField]
    private Sprite animalBackground;

    public Sprite getAnimalImage()
    {
        return animalImage;
    }

    public AudioClip getAnimalSound()
    {
        return animalSound;
    }

    public Sprite getAnimalBackground()
    {
        return animalBackground;
    }
}
