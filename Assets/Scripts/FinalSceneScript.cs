using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalSceneScript : MonoBehaviour
{
    public void FinalGoToMenu()
    {
        SaveManager.ClearSavedGame();
        SceneManager.LoadScene("Menu");
    }
}
