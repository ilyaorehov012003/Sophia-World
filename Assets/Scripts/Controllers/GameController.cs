using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameScene currentScene;
    public GameScene Scene9_1;
    public GameScene Scene14;
    public GameScene Scene17;
    public GameScene Scene20;
    public GameScene Scene20_1;
    public GameScene Scene20_2; 
    public GameScene Scene20_3;
    public BottomBarController bottomBar;
    public SpriteSwitcher backgroundController;
    public ChooseController chooseController;
    public AudioController audioController;

    private Animator animator;
    //private int _window = 0;

    public DataHolder data;

    public string menuScene;

    private State state = State.IDLE;

    private List<StoryScene> history = new List<StoryScene>();

    //public bool game_letter1;
    //public bool game_letter2;

    public GameObject ImageLetter1;
    public GameObject ImageLetter2;

    public GameObject ImageLetterText1;
    public GameObject ImageLetterText2;

    private enum State
    {
        IDLE, ANIMATE, CHOOSE
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        if (SaveManager.IsGameSaved())
        {
            SaveData data = SaveManager.LoadGame();
            data.prevScenes.ForEach(scene =>
            {
                history.Add(this.data.scenes[scene] as StoryScene);
            });
            currentScene = history[history.Count - 1];
            history.RemoveAt(history.Count - 1);
            bottomBar.SetSentenceIndex(data.sentence - 1);
            Letters.letter1 = data.letter1;
            Letters.letter2 = data.letter2;
        }
        if (currentScene is StoryScene)
        {
            StoryScene storyScene = currentScene as StoryScene;
            history.Add(storyScene);
            bottomBar.PlayScene(storyScene, bottomBar.GetSentenceIndex());
            backgroundController.SetImage(storyScene.background);
            PlayAudio(storyScene.sentences[bottomBar.GetSentenceIndex()]);
        }

        /*if (Letters.letter1 == true)
        {
            //ImageLetter1.SetActive(true);
            Debug.Log("Письмо 1 открыто");
        }

        if (Letters.letter2 == true)
        {
            Debug.Log("Письмо 2 закрыто");
        }*/
    }

    void Update()
    {
        if (Letters.letter1 == true)
        {
            ImageLetter1.SetActive(true);
            Debug.Log("Письмо 1 открыто");
        }

        if (Letters.letter2 == true)
        {
            ImageLetter2.SetActive(true);
            Debug.Log("Письмо 2 открыто");
        }

        if (state == State.IDLE) {
            //if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            if(NextSentence.nextSentenceStatus)
            {
                NextSentence.nextSentenceStatus = false;
                if (bottomBar.IsCompleted())
                {
                    bottomBar.StopTyping();

                    if (bottomBar.IsLastSentence() && bottomBar.GetSceneNumber() == 911 && Letters.letter1 == false)
                    {
                        PlayScene(Scene9_1);
                    }

                    else if (bottomBar.IsLastSentence() && bottomBar.GetSceneNumber() == 1214 && Letters.letter1 == false)
                    {
                        PlayScene(Scene14);
                    }

                    else if (bottomBar.IsLastSentence() && bottomBar.GetSceneNumber() == 1517 && Letters.letter1 == false)
                    {
                        PlayScene(Scene17);
                    }

                    else if (bottomBar.IsLastSentence() && bottomBar.GetSceneNumber() == 1920)
                    {
                        if (Letters.letter1 == true && Letters.letter2 == true) PlayScene(Scene20);
                        else if (Letters.letter1 == true && Letters.letter2 == false) PlayScene(Scene20_1);
                        else if (Letters.letter1 == false && Letters.letter2 == true) PlayScene(Scene20_2);
                        else PlayScene(Scene20_3);
                    }

                    else if (bottomBar.IsLastSentence())
                    {
                        PlayScene((currentScene as StoryScene).nextScene);
                    }
                    else
                    {
                        bottomBar.PlayNextSentence();
                        PlayAudio((currentScene as StoryScene)
                            .sentences[bottomBar.GetSentenceIndex()]);
                    }
                }
                else
                {
                    bottomBar.SpeedUp();
                }
            }
            /*if (Input.GetMouseButtonDown(1))
            {
                if (bottomBar.IsFirstSentence())
                {
                    if(history.Count > 1)
                    {
                        bottomBar.StopTyping();
                        bottomBar.HideSprites();
                        history.RemoveAt(history.Count - 1);
                        StoryScene scene = history[history.Count - 1];
                        history.RemoveAt(history.Count - 1);
                        PlayScene(scene, scene.sentences.Count - 2, false);
                    }
                }
                else
                {
                    bottomBar.GoBack();
                }
            }*/
            //if (Input.GetKeyDown(KeyCode.Escape))
            /*if (GoToMenu.menuStatus)
            {
                GoToMenu.menuStatus = false;
                List<int> historyIndicies = new List<int>();
                history.ForEach(scene =>
                {
                    historyIndicies.Add(this.data.scenes.IndexOf(scene));
                });
                SaveData data = new SaveData
                {
                    sentence = bottomBar.GetSentenceIndex(),
                    prevScenes = historyIndicies
                };
                SaveManager.SaveGame(data);
                SceneManager.LoadScene(menuScene);
            }*/
        }
    }

    public void PlayScene(GameScene scene, int sentenceIndex = -1, bool isAnimated = true)
    {
        StartCoroutine(SwitchScene(scene, sentenceIndex, isAnimated));
    }

    public void ShowInventory()
    {
        animator.SetTrigger("ShowInventory");
        //_window = 1;
    }

    public void HideInventory()
    {
        animator.SetTrigger("HideInventory");
        //_window = 0;
    }

    public void ShowLetter1()
    {
        ImageLetterText1.SetActive(true);
        animator.SetTrigger("ShowLetters");
        Debug.Log("Анимация открытия письма 1");
    }

    public void ShowLetter2()
    {
        ImageLetterText2.SetActive(true);
        animator.SetTrigger("ShowLetters");
        Debug.Log("Анимация открытия письма 1");
    }

    public void HideLetter()
    {
        animator.SetTrigger("HideLetters");
    }

    public void ShowLettersPart2()
    {
        animator.SetTrigger("ShowLettersPart2");
    }

    public void GoToMenu()
    {
        //GoToMenu.menuStatus = false;
        List<int> historyIndicies = new List<int>();
        history.ForEach(scene =>
        {
            historyIndicies.Add(this.data.scenes.IndexOf(scene));
        });
        SaveData data = new SaveData
        {
            sentence = bottomBar.GetSentenceIndex(),
            prevScenes = historyIndicies,
            letter1 = Letters.letter1,
            letter2 = Letters.letter2
        };
        SaveManager.SaveGame(data);
        SceneManager.LoadScene(menuScene);
    }

    private IEnumerator SwitchScene(GameScene scene, int sentenceIndex = -1, bool isAnimated = true)
    {
        state = State.ANIMATE;
        currentScene = scene;
        if (isAnimated)
        {
            bottomBar.Hide();
            yield return new WaitForSeconds(1f);
        }
        if (scene is StoryScene)
        {
            StoryScene storyScene = scene as StoryScene;
            history.Add(storyScene);
            PlayAudio(storyScene.sentences[sentenceIndex + 1]);
            if (isAnimated)
            {
                backgroundController.SwitchImage(storyScene.background);
                yield return new WaitForSeconds(1f);
                bottomBar.ClearText();
                bottomBar.Show();
                yield return new WaitForSeconds(1f);
            }
            else
            {
                backgroundController.SetImage(storyScene.background);
                bottomBar.ClearText();
            }
            bottomBar.PlayScene(storyScene, sentenceIndex, isAnimated);
            state = State.IDLE;
        }
        else if (scene is ChooseScene)
        {
            state = State.CHOOSE;
            chooseController.SetupChoose(scene as ChooseScene);
        }
    }

    private void PlayAudio(StoryScene.Sentence sentence)
    {
        audioController.PlayAudio(sentence.music, sentence.sound);
    }
}
