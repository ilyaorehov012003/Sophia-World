using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryAnim : MonoBehaviour
{
    public Transform box;

    private void OnEnable()
    {
        box.localPosition = new Vector2(0, Screen.height);
        box.LeanMoveLocalY(0, 0.5f).setEaseOutExpo().delay = 0.1f;
    }

    public void CloseDialog()
    {
        box.LeanMoveLocalY(0.5f, 0).setEaseOutExpo().delay = 0.1f;
        Debug.Log("Окно закрыто");
    }

    void Complete()
    {
        gameObject.SetActive(false);
    }
}
