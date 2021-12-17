using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class RandomItemSpawns : MonoBehaviour
{
    public GameObject[] spawnables;//How many spawns in a arry
    public Transform[] spawnPoints;
    private void Start()
    {
        CheckSpawnPoints();
    }
    
    int Randomise()
    {
        int randomInt = Random.Range(0,spawnables.Length);
        return randomInt;
    }
    public void CheckSpawnPoints()
    {
        for(int i = 0;i < spawnPoints.Length;i++)
        {
            if(spawnPoints[i].childCount <= 0)
            {
                SpawnPipe(spawnables[Randomise()], spawnPoints[i]);
            }
            else
            {
                Debug.Log(spawnPoints[i].name + " Already has a pipe placed");
            }
        }
    }
    public void SpawnPipe(GameObject spawn, Transform spawnPosition)
    {
        Quaternion rotation = spawn.transform.rotation;
        GameObject parental = Instantiate(spawn, spawnPosition.position,rotation);
        parental.transform.parent = spawnPosition.transform;
    }

    //Fuction : Is button is pressed delete old instantiated prefabs
}
