using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextSentence : MonoBehaviour
{
    public static bool nextSentenceStatus = false;
    public static bool nextSceneStatus = false;

    public void GoNextSentence()
    {
        nextSentenceStatus = true;
        Debug.Log("������ ������ ���������� �����������");
    }

    public void GoNextScene()
    {
        //nextSentenceStatus = true;
        nextSceneStatus = true;
    }
}