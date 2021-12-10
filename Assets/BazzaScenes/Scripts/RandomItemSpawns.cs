using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class RandomItemSpawns : MonoBehaviour
{
    public GameObject[] spawness;//How many spawns in a arry
    public Transform spawnPos;

    int randomInt;

    private void Start() 
    {
        
    }

    public void SpawnRandom()
    {
        randomInt = Random.Range(0,spawness.Length);
        Instantiate(spawness[randomInt],spawnPos.position,spawnPos.rotation);

    }
}
