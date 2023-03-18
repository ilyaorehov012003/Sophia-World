using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGameAnim : MonoBehaviour
{
    public Transform box;
    public CanvasGroup Back;

    private void OnEnable()
    {
        Back.alpha = 0;
        Back.LeanAlpha(0.7f, 0.5f);

        box.localPosition = new Vector2(Screen.width, 0);
        box.LeanMoveLocalX(0, 0.5f).setEaseOutExpo().delay = 0.1f;
    }

    public void CloseDialog()
    {
        Back.LeanAlpha(0, 0.5f);
        box.LeanMoveLocalX(-Screen.width, 0.5f).setEaseInExpo().setOnComplete(Complete);
    }

    void Complete()
    {
        gameObject.SetActive(false);
    }
}