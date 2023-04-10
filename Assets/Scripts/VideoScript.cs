using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VideoScript : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Co_WaitForSeconds(5f)); // 5f - ����� ����� � ��������
    }

    private IEnumerator Co_WaitForSeconds(float value)
    {
        yield return new WaitForSeconds(value);
        Debug.Log("����� �����������");
        SceneManager.LoadScene("LoadScene");
    }
}
