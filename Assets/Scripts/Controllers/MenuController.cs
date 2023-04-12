using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public string gameScene;

    public TextMeshProUGUI musicValue;
    public AudioMixer musicMixer;
    public TextMeshProUGUI soundsValue;
    public AudioMixer soundsMixer;
    public Button loadButton;

    private Animator animator;
    //private int _window = 0;

    public void Start()
    {
        animator = GetComponent<Animator>();
        loadButton.interactable = SaveManager.IsGameSaved();
    }

    /*public void Update()
    {
        if(CloseSettings.closeSettingsStatus || Input.GetKeyDown(KeyCode.Escape) && _window == 1)
        {
            CloseSettings.closeSettingsStatus = false;
            animator.SetTrigger("HideOptions");
            _window = 0;
        }
    }*/

    public void NewGame()
    {
        Letters.letter1 = false;
        Letters.letter2 = false;
        Letters.letter3 = false;
        Letters.letter4 = false;
        Letters.letter5 = false;
        Letters.letter6 = false;
        Letters.letter7 = false;
        Letters.GameKeyStatus = true;
        Letters.GameMapStatus = true;
        Letters.VideoStatus = true;
        SaveManager.ClearSavedGame();
        Load();
    }

    public void Load()
    {
        SceneManager.LoadScene(gameScene, LoadSceneMode.Single);
    }

    public void ShowOptions()
    {
         animator.SetTrigger("ShowOptions");
        //_window = 1;
    }

    public void HideOptions()
    {
        animator.SetTrigger("HideOptions");
        //_window = 1;
    }

    public void ShowNewGame()
    {
        animator.SetTrigger("ShowNewGame");
    }

    public void HideNewGame()
    {
        animator.SetTrigger("HideNewGame");
    }

    public void QuitShow()
    {
        animator.SetTrigger("ShowQuit");
    }

    public void QuitHide()
    {
        animator.SetTrigger("HideQuit");
    }

    public void Quit()
    {
        Application.Quit();
    }
    
    public void OnMusicChanged(float value)
    {
        musicValue.SetText(value + "%");
        musicMixer.SetFloat("volume", -50 + value / 2);
    }
    
    public void OnSoundsChanged(float value)
    {
        soundsValue.SetText(value + "%");
        soundsMixer.SetFloat("volume", -50 + value / 2);
    }
}
