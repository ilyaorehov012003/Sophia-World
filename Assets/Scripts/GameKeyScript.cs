using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameKeyScript : MonoBehaviour
{
    //private bool GameKeyStatus = false;

    /*void Update()
    {
        if (GameKeyStatus == true)
        {
            Debug.Log("Кнопка нажата");
        }
    }*/

    public void GoToGame()
    {
        //GameKeyStatus = true;
        Debug.Log("Кнопка нажата");
        SceneManager.LoadScene("LoadScene");
    }
}