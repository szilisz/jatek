using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lose : MonoBehaviour
{
    public GameObject loseScreen;


    void Start()
    {
        loseScreen.SetActive(false);
    }
    public void BackToMenu()
    {
        PlayerMovement.isGameOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
