using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameKeyScript : MonoBehaviour
{
    private Animator animator;

    public void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void GoToGame()
    {
        Debug.Log("Кнопка нажата");
        SceneManager.LoadScene("LoadScene");
    }

    public void KeyLose1()
    {
        animator.SetTrigger("KeyLose1");
    }

    public void KeyLose2()
    {
        animator.SetTrigger("KeyLose2");
    }

    public void KeyLose4()
    {
        animator.SetTrigger("KeyLose4");
    }
}