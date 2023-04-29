using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameScene currentScene;
    public StoryScene Scene4;
    public StoryScene Scene4_1;
    public GameScene Scene7p2;
    public GameScene Scene9_1;
    public StoryScene Scene11_1;
    public GameScene Scene14;
    public GameScene Scene17;
    public GameScene Scene20;
    public GameScene Scene20_1;
    public GameScene Scene20_2; 
    public GameScene Scene20_3;
    public GameScene Scene37_2;
    public GameScene Scene39;
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
    public GameObject ImageLetter3;
    public GameObject ImageLetter6;

    public GameObject ImageLetterText1;
    public GameObject ImageLetterText2;
    public GameObject ImageLetterText3;
    public GameObject ImageLetterText4;
    public GameObject ImageLetterText5;
    public GameObject ImageLetterText6;
    public GameObject ImageLetterText7;

    private bool isWork1 = true;
    private bool isWork2 = true;
    private bool isWork3 = true;
    private bool isWork4 = true;
    private bool isWork5 = true;
    private bool isWork6 = true;
    private bool isWork7 = true;

    //private bool gameKey = true;

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
            Letters.letter3 = data.letter3;
            Letters.GameKeyStatus = data.keyStatus;
            Letters.GameMapStatus = data.mapStatus;
            Letters.VideoStatusInSchool = data.videoStatusInSchool;
            Letters.VideoStatusScene96 = data.videoStatusScene96;
            Letters.VideoStatusScene124 = data.videoStatusScene124;
        }
        if (currentScene is StoryScene)
        {
            StoryScene storyScene = currentScene as StoryScene;
            history.Add(storyScene);
            bottomBar.PlayScene(storyScene, bottomBar.GetSentenceIndex());
            backgroundController.SetImage(storyScene.background);
            PlayAudio(storyScene.sentences[bottomBar.GetSentenceIndex()]);
        }

        /*if (SaveManager.IsGameSaved() == false)
        {
            Scene4.number = 100;
            Scene4_1.number = 100;
            Scene11_1.number = 101;
        }*/

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

        if (Letters.letter3 == true)
        {
            ImageLetter3.SetActive(true);
            Debug.Log("Письмо 3 открыто");
        }

        if (Letters.letter6 == true)
        {
            ImageLetter6.SetActive(true);
            Debug.Log("Письмо 6 открыто");
        }

        if (bottomBar.GetSceneNumber() == 1 && isWork1 == true)
        {
            isWork1 = false;
            ShowLetter1();
        }

        if (bottomBar.GetSceneNumber() == 2 && isWork2 == true)
        {
            isWork2 = false;
            ShowLetter2();
        }

        if (bottomBar.GetSceneNumber() == 3 && isWork3 == true)
        {
            isWork3 = false;
            ShowLetter3();
        }

        if (bottomBar.GetSceneNumber() == 4 && isWork4 == true)
        {
            isWork4 = false;
            ShowLetter4();
        }

        if (bottomBar.GetSceneNumber() == 5 && isWork5 == true)
        {
            isWork5 = false;
            ShowLetter5();
        }

        if (bottomBar.GetSceneNumber() == 6 && isWork6 == true)
        {
            isWork6 = false;
            ShowLetter6();
        }

        if (bottomBar.GetSceneNumber() == 7 && bottomBar.IsLastSentence() && isWork7 == true)
        {
            isWork7 = false;
            ShowLetter7();
        }

        if (bottomBar.GetSceneNumber() == 100 && Letters.GameKeyStatus == true)
        {
            Debug.Log("Игра 'Подбери ключ'");
            Letters.GameKeyStatus = false;
            //Scene4.number = 0;
            //Scene4_1.number = 0;

            SaveGameData();

            /*List<int> historyIndicies = new List<int>();
            history.ForEach(scene =>
            {
                historyIndicies.Add(this.data.scenes.IndexOf(scene));
            });
            SaveData data = new SaveData
            {
                sentence = bottomBar.GetSentenceIndex(),
                prevScenes = historyIndicies,
                letter1 = Letters.letter1,
                letter2 = Letters.letter2,
                letter3 = Letters.letter3,
                letter4 = Letters.letter4,
                letter5 = Letters.letter5,
                letter6 = Letters.letter6,
                letter7 = Letters.letter7,
                keyStatus = Letters.GameKeyStatus,
                mapStatus = Letters.GameMapStatus,
                videoStatus = Letters.VideoStatus
            };
            SaveManager.SaveGame(data);*/
            SceneManager.LoadScene("KeyGame");
        }

        if (bottomBar.GetSceneNumber() == 101 && Letters.GameMapStatus == true)
        {
            Debug.Log("Игра 'Отметь на карте'");
            //Scene11_1.number = 0;
            Letters.GameMapStatus = false;

            SaveGameData();
            /*List<int> historyIndicies = new List<int>();
            history.ForEach(scene =>
            {
                historyIndicies.Add(this.data.scenes.IndexOf(scene));
            });

            SaveData data = new SaveData
            {
                sentence = bottomBar.GetSentenceIndex(),
                prevScenes = historyIndicies,
                letter1 = Letters.letter1,
                letter2 = Letters.letter2,
                letter3 = Letters.letter3,
                letter4 = Letters.letter4,
                letter5 = Letters.letter5,
                letter6 = Letters.letter6,
                letter7 = Letters.letter7,
                keyStatus = Letters.GameKeyStatus,
                mapStatus = Letters.GameMapStatus,
                videoStatus = Letters.VideoStatus
            };
            SaveManager.SaveGame(data);*/
            SceneManager.LoadScene("MapGame");
        }

        if (bottomBar.GetSceneNumber() == 102 && Letters.VideoStatusInSchool == true && bottomBar.IsLastSentence())
        {
            Debug.Log("Просмотр видео 'София читает сочинение'");
            //Scene11_1.number = 0;
            Letters.VideoStatusInSchool = false;

            SaveGameData();

            /*List<int> historyIndicies = new List<int>();
            history.ForEach(scene =>
            {
                historyIndicies.Add(this.data.scenes.IndexOf(scene));
            });

            SaveData data = new SaveData
            {
                sentence = bottomBar.GetSentenceIndex(),
                prevScenes = historyIndicies,
                letter1 = Letters.letter1,
                letter2 = Letters.letter2,
                letter3 = Letters.letter3,
                letter4 = Letters.letter4,
                letter5 = Letters.letter5,
                letter6 = Letters.letter6,
                letter7 = Letters.letter7,
                keyStatus = Letters.GameKeyStatus,
                mapStatus = Letters.GameMapStatus,
                videoStatus = Letters.VideoStatus
            };
            SaveManager.SaveGame(data);*/
            SceneManager.LoadScene("VideoInSchool");
        }

        if (bottomBar.GetSceneNumber() == 103 && Letters.VideoStatusScene96 == true)
        {
            Debug.Log("Просмотр видео 'София идёт в церковь'");
            Letters.VideoStatusScene96 = false;
            SaveGameData();
            SceneManager.LoadScene("VideoScene96");
        }

        if (bottomBar.GetSceneNumber() == 104 && Letters.VideoStatusScene124 == true)
        {
            Debug.Log("Просмотр видео 'Альберто играет на кларнете'");
            Letters.VideoStatusScene124 = false;
            SaveGameData();
            SceneManager.LoadScene("VideoScene124");
        }

        if (bottomBar.GetSceneNumber() == 1000 && bottomBar.IsLastSentence())
        {
            SaveManager.ClearSavedGame();
            SceneManager.LoadScene(menuScene);
        }

        if (state == State.IDLE) {
            //if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            if (NextSentence.nextSentenceStatus && NextSentence.nextSceneStatus == false)
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

                    else if (bottomBar.IsLastSentence() && bottomBar.GetSceneNumber() == 37372 && Letters.letter1 == false)
                    {
                        PlayScene(Scene37_2);
                    }

                    else if (bottomBar.IsLastSentence() && bottomBar.GetSceneNumber() == 3839 && Letters.letter1 == true)
                    {
                        PlayScene(Scene39);
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

    public void ShowLetter3()
    {
        ImageLetterText3.SetActive(true);
        animator.SetTrigger("ShowLetters");
        Debug.Log("Анимация открытия письма 1");
    }

    public void ShowLetter4()
    {
        ImageLetterText4.SetActive(true);
        animator.SetTrigger("ShowLetter4from7");
        Debug.Log("Анимация открытия письма 4");
    }

    public void ShowLetter5()
    {
        ImageLetterText5.SetActive(true);
        animator.SetTrigger("ShowLetter4from7");
        Debug.Log("Анимация открытия письма 5");
    }

    public void ShowLetter6()
    {
        ImageLetterText6.SetActive(true);
        animator.SetTrigger("ShowLetter6");
        Debug.Log("Анимация открытия письма 6");
    }

    public void ShowLetter7()
    {
        ImageLetterText7.SetActive(true);
        animator.SetTrigger("ShowLetter4from7");
        Debug.Log("Анимация открытия письма 7");
    }

    public void ShowTextLetter1()
    {
        ImageLetterText1.SetActive(true);
        animator.SetTrigger("ShowTextLetter1");
    }

    public void ShowTextLetter2()
    {
        ImageLetterText2.SetActive(true);
        animator.SetTrigger("ShowTextLetter1");
    }

    public void ShowTextLetter3()
    {
        ImageLetterText3.SetActive(true);
        animator.SetTrigger("ShowTextLetter1");
    }

    public void ShowTextLetter6()
    {
        ImageLetterText6.SetActive(true);
        animator.SetTrigger("ShowLetter6");
    }

    public void HideLetter()
    {
        animator.SetTrigger("HideLetters");
    }

    public void ShowLettersPart2()
    {
        animator.SetTrigger("ShowLettersPart2");
    }

    public void SaveGameData() //функция сохранения игровых данных
    {
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
            letter2 = Letters.letter2,
            letter3 = Letters.letter3,
            letter4 = Letters.letter4,
            letter5 = Letters.letter5,
            letter6 = Letters.letter6,
            letter7 = Letters.letter7,
            keyStatus = Letters.GameKeyStatus,
            mapStatus = Letters.GameMapStatus,
            videoStatusInSchool = Letters.VideoStatusInSchool,
            videoStatusScene96 = Letters.VideoStatusScene96,
            videoStatusScene124 = Letters.VideoStatusScene124
        };
        SaveManager.SaveGame(data);
    }

    public void GoToMenu()
    {
        //GoToMenu.menuStatus = false;
        SaveGameData();
        /*List<int> historyIndicies = new List<int>();
        history.ForEach(scene =>
        {
            historyIndicies.Add(this.data.scenes.IndexOf(scene));
        });
        SaveData data = new SaveData
        {
            sentence = bottomBar.GetSentenceIndex(),
            prevScenes = historyIndicies,
            letter1 = Letters.letter1,
            letter2 = Letters.letter2,
            letter3 = Letters.letter3,
            letter4 = Letters.letter4,
            letter5 = Letters.letter5,
            letter6 = Letters.letter6,
            letter7 = Letters.letter7,
            keyStatus = Letters.GameKeyStatus,
            mapStatus = Letters.GameMapStatus,
            videoStatus = Letters.VideoStatus
        };
        SaveManager.SaveGame(data);*/
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
