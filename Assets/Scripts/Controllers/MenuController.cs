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
        Letters.letter8 = false;
        Letters.letter9 = false;
        Letters.letter10 = false;
        Letters.letter11 = false;
        Letters.PuzzleCard1 = false;
        Letters.PuzzleCard2 = false;
        Letters.PuzzleCard3 = false;
        Letters.PuzzleCard4 = false;
        Letters.PuzzleCard5 = false;
        Letters.GameKeyStatus = true;
        Letters.GameMapStatus = true;
        Letters.VideoStatusInSchool = true;
        Letters.VideoStatusScene96 = true;
        Letters.VideoStatusScene124 = true;
        Letters.VideoStatusScene175 = true;
        Letters.Puzzle1 = true;
        Letters.Puzzle2 = true;
        Letters.Puzzle3 = true;
        Letters.Puzzle4 = true;
        Letters.Puzzle5 = true;
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

    public void OpenTelegram()
    {
        Application.OpenURL("https://t.me/+8oV8wigoT5I4Mjli");
    }
}
