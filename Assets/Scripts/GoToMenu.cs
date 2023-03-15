using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoToMenu : MonoBehaviour
{
    public static bool menuStatus = false;

    public void GoMenu()
    {
        menuStatus = true;
        Debug.Log("Нажата кнопка MENU");
    }
}