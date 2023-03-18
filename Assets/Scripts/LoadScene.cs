using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    AsyncOperation asyncOperation;
    public Image LoadBar;

    private void Start()
    {
        StartCoroutine(LoadSceneCor());
    }


    IEnumerator LoadSceneCor()
    {
        yield return new WaitForSeconds(1f);
        asyncOperation = SceneManager.LoadSceneAsync(1);
       /* while (!asyncOperation.isDone)
        {
            float progress = asyncOperation.progress / 0.9f;
            LoadBar.fillAmount = progress;
            //BarTxt.text = "Loading Complate   " + string.Format("{0:0}%", progress * 100f);
            yield return 0;
        }*/
    }

}