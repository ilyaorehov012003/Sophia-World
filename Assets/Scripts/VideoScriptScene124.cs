using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VideoScriptScene124 : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Co_WaitForSeconds(55f)); // 55f - ����� ����� � ��������
    }

    private IEnumerator Co_WaitForSeconds(float value)
    {
        yield return new WaitForSeconds(value);
        Debug.Log("����� �����������");
        SceneManager.LoadScene("LoadScene");
    }
}
