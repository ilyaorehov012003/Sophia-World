using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VideoScriptChurch : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Co_WaitForSeconds(107f)); // 107f - длина видео в секундах
    }

    private IEnumerator Co_WaitForSeconds(float value)
    {
        yield return new WaitForSeconds(value);
        Debug.Log("Видео завершилось");
        SceneManager.LoadScene("LoadScene");
    }
}
