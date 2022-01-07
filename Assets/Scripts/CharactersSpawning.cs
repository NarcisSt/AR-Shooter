using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharactersSpawning : MonoBehaviour
{
    public GameObject[] hiddenObjects;
    public GameObject[] objectsToHide;
    public int charactersNumber;
    public Text message;
    bool done = false;
    private int totalCharactersNumber;

    // Start is called before the first frame update
    void Start()
    {
        totalCharactersNumber = charactersNumber;
    }

    // Update is called once per frame
    void Update()
    {
        if (charactersNumber == 0)
        {
            done = true;
            foreach (GameObject gameObject in hiddenObjects)
            {
                gameObject.SetActive(true);
            }
            foreach (GameObject gameObject in objectsToHide)
            {
                gameObject.SetActive(false);
            }
            message.enabled = false;
            this.enabled = false;
        }
        else if(!done)
        {
            var spawnedCharacters = GameObject.FindGameObjectsWithTag("Enemy");
            charactersNumber = totalCharactersNumber - spawnedCharacters.Length;
            message.text = "Spawn " + charactersNumber + " enemies in the room";
        }
    }
}
