using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextSentence : MonoBehaviour
{
    public static bool nextSentenceStatus = false;

    public void GoNextSentence()
    {
        nextSentenceStatus = true;
        Debug.Log("Нажата кнопка следующего предложения");
    }
}