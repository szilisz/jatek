using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject[] prefabs;
    public GameObject spawner;
    public GameObject spawner2;
    public GameObject player;
    public GameObject weapon;
    public GameObject loseScreen;


    void Start()
    {
        InvokeRepeating("SpawnMonsters", 2, 2);

    }

    void SpawnMonsters()
    {
        if (PlayerMovement.isGameOver)
            return;

        int idx = Random.Range(0, prefabs.Length);
        Instantiate(prefabs[idx], new Vector3(Random.Range(-8f, 8f), 0, 25), prefabs[idx].transform.rotation);

    }

    void Lose()
    {
        loseScreen.gameObject.SetActive(true);
    }

    void Update()
    {
        if (Weapon.score >= 10)
            spawner.SetActive(true);

        if (Weapon.score >= 20)
            spawner2.SetActive(true);

        if (PlayerMovement.isGameOver)
        {
            Weapon staff = weapon.GetComponent<Weapon>();
            PlayerMovement pm = player.GetComponent<PlayerMovement>();
            if (pm != null)
            {
                staff.enabled = false;
                pm.enabled = false;
                spawner.SetActive(false);
                spawner2.SetActive(false);
            }

            Invoke("Lose", 2);

        }

    }


}
