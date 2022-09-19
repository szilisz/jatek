using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPlus : MonoBehaviour
{
    public GameObject[] prefabs;


    void Start()
    {
        InvokeRepeating("SpawnMonstersPlus", 1.5f, 1.5f);

    }

    void SpawnMonstersPlus()
    {
        int idx = Random.Range(0, prefabs.Length);
        Instantiate(prefabs[idx], new Vector3(Random.Range(-8f, 8f), 0, 25), prefabs[idx].transform.rotation);
    }
}
