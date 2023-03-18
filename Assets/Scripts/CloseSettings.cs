using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseSettings : MonoBehaviour
{
    public static bool closeSettingsStatus = false;

    public void CloseSetting()
    {
        closeSettingsStatus = true;
        Debug.Log("Нажата кнопка выхода из настроек");
    }
}