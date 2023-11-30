using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
        //Time.timeScale = 1.0f;
    }

    public void NextRound()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
        //Time.timeScale = 1.0f;
        if(SceneManager.GetActiveScene().buildIndex + 1 > 2)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        
        
    }
    public void StartGame()
    {
        Time.timeScale = 1;
    }
}
