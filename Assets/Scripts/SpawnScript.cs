using System.Collections;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] gameObjects;
    public GameObject[] startAnimations;
    private enum Character
    {
        Orc = 1,
        Zombie = 3,
        Alien = 0,
        Princess = 2
    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnCharacter(Character.Orc);
        SpawnCharacter(Character.Alien);
        SpawnCharacter(Character.Zombie);
        SpawnCharacter(Character.Princess);
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator WaitNSeconds(int n)
    {
        yield return new WaitForSeconds(n);
    }

    void SpawnCharacter(Character character, int delay=0)
    {
        if (delay > 0)
            StartCoroutine(WaitNSeconds(delay));

        var i = (int) character;
        var obj=Instantiate(gameObjects[i], spawnPoints[i].position, spawnPoints[i].rotation);

        // obj.GetComponent<Animation>().Play(startAnimations[i].name);
    }
}
