using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Components")]
    [SerializeField]
    private List<GameObject> buttons;

    [Header("GameData")]
    [SerializeField]
    public List<Animal> animals;
    public List<GameObject> animalsTwo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
