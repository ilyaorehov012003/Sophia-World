using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapKeyScript : MonoBehaviour
{
    private Animator animator;

    public void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Marker1()
    {
        animator.SetTrigger("Win1");
    }

    public void Marker2()
    {
        animator.SetTrigger("Lose2");
    }

    public void Marker3()
    {
        animator.SetTrigger("Lose3");
    }

    public void Marker4()
    {
        animator.SetTrigger("Lose4");
    }

    public void Marker5()
    {
        animator.SetTrigger("Lose5");
    }

    public void Marker6()
    {
        animator.SetTrigger("Lose6");
    }

    public void Marker7()
    {
        animator.SetTrigger("Lose7");
    }

    public void Marker8()
    {
        animator.SetTrigger("Lose8");
    }

    public void ReadHistory()
    {
        Debug.Log("Читает историю");
        Application.OpenURL("https://disk.yandex.ru/i/-Yn0pr4isHnAKQ");
    }

    public void CompleteGame()
    {
        Debug.Log("Переход на игровую сцену");
        SceneManager.LoadScene("LoadScene");
    }
}