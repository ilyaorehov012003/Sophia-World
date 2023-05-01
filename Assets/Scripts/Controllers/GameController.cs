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
    public GameScene Scene92;
    public GameScene Scene132;
    public GameScene Scene138;
    public GameScene Scene140;
    public GameScene Scene143;
    public GameScene Scene146;
    public GameScene Scene153;
    public GameScene Scene156;
    public GameScene Scene156p3;
    public GameScene Scene158;
    public GameScene Scene159p3;
    public GameScene Scene165;
    public GameScene Scene176;
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
    public GameObject ImageLetter8;
    public GameObject ImageLetter9;
    public GameObject ImageLetter11;

    public GameObject ImageCard1;
    public GameObject ImageCard2;
    public GameObject ImageCard3;
    public GameObject ImageCard4;
    public GameObject ImageCard5;

    public GameObject ImageLetterText1;
    public GameObject ImageLetterText2;
    public GameObject ImageLetterText3;
    public GameObject ImageLetterText4;
    public GameObject ImageLetterText5;
    public GameObject ImageLetterText6;
    public GameObject ImageLetterText7;
    public GameObject ImageLetterText8;
    public GameObject ImageLetterText9;
    public GameObject ImageLetterText11;

    public GameObject ImageCardText1;
    public GameObject ImageCardText2;
    public GameObject ImageCardText3;
    public GameObject ImageCardText4;
    public GameObject ImageCardText5;

    private bool isWork1 = true;
    private bool isWork2 = true;
    private bool isWork3 = true;
    private bool isWork4 = true;
    private bool isWork5 = true;
    private bool isWork6 = true;
    private bool isWork7 = true;
    private bool isWork8 = true;
    private bool isWork9 = true;
    private bool isWork11 = true;

    public GameObject Abstract1;
    public GameObject Abstract2;
    public GameObject Abstract3;
    public GameObject Abstract4;
    public GameObject Abstract5;
    public GameObject Abstract6;
    public GameObject Abstract7;
    public GameObject Abstract8;
    public GameObject Abstract9;
    public GameObject Abstract10;
    public GameObject Abstract11;
    public GameObject Abstract12;
    public GameObject Abstract13;

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
            Letters.letter4 = data.letter4;
            Letters.letter5 = data.letter5;
            Letters.letter6 = data.letter6;
            Letters.letter7 = data.letter7;
            Letters.letter8 = data.letter8;
            Letters.letter9 = data.letter9;
            Letters.letter10 = data.letter10;
            Letters.letter11 = data.letter11;
            Letters.PuzzleCard1 = data.puzzleCard1;
            Letters.PuzzleCard2 = data.puzzleCard2;
            Letters.PuzzleCard3 = data.puzzleCard3;
            Letters.PuzzleCard4 = data.puzzleCard4;
            Letters.PuzzleCard5 = data.puzzleCard5;
            Letters.GameKeyStatus = data.keyStatus;
            Letters.GameMapStatus = data.mapStatus;
            Letters.VideoStatusInSchool = data.videoStatusInSchool;
            Letters.VideoStatusScene96 = data.videoStatusScene96;
            Letters.VideoStatusScene124 = data.videoStatusScene124;
            Letters.VideoStatusScene175 = data.videoStatusScene175;
            Letters.Puzzle1 = data.puzzle1;
            Letters.Puzzle2 = data.puzzle2;
            Letters.Puzzle3 = data.puzzle3;
            Letters.Puzzle4 = data.puzzle4;
            Letters.Puzzle5 = data.puzzle5;
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

        if (Letters.letter8 == true)
        {
            ImageLetter8.SetActive(true);
            Debug.Log("Письмо 6 открыто");
        }

        if (Letters.letter9 == true)
        {
            ImageLetter9.SetActive(true);
            Debug.Log("Письмо 6 открыто");
        }

        if (Letters.letter11 == true)
        {
            ImageLetter11.SetActive(true);
            Debug.Log("Письмо 6 открыто");
        }

        if (Letters.PuzzleCard1 == true)
        {
            ImageCard1.SetActive(true);
        }

        if (Letters.PuzzleCard2 == true)
        {
            ImageCard2.SetActive(true);
        }

        if (Letters.PuzzleCard3 == true)
        {
            ImageCard3.SetActive(true);
        }

        if (Letters.PuzzleCard4 == true)
        {
            ImageCard4.SetActive(true);
        }

        if (Letters.PuzzleCard5 == true)
        {
            ImageCard5.SetActive(true);
        }

        if (bottomBar.GetSceneNumber() == 1001)
        {
            Abstract1.SetActive(true);
        }

        if (bottomBar.GetSceneNumber() == 1002)
        {
            Abstract2.SetActive(true);
        }

        if (bottomBar.GetSceneNumber() == 1003)
        {
            Abstract3.SetActive(true);
        }

        if (bottomBar.GetSceneNumber() == 1004)
        {
            Abstract4.SetActive(true);
        }

        if (bottomBar.GetSceneNumber() == 1005)
        {
            Abstract5.SetActive(true);
        }

        if (bottomBar.GetSceneNumber() == 1006)
        {
            Abstract6.SetActive(true);
        }

        if (bottomBar.GetSceneNumber() == 1007)
        {
            Abstract7.SetActive(true);
        }

        if (bottomBar.GetSceneNumber() == 1008)
        {
            Abstract8.SetActive(true);
        }

        if (bottomBar.GetSceneNumber() == 1009)
        {
            Abstract9.SetActive(true);
        }

        if (bottomBar.GetSceneNumber() == 1010)
        {
            Abstract10.SetActive(true);
        }

        if (bottomBar.GetSceneNumber() == 152153) // вместо 1011
        {
            Abstract11.SetActive(true);
        }

        if (bottomBar.GetSceneNumber() == 1012)
        {
            Abstract12.SetActive(true);
        }

        if (bottomBar.GetSceneNumber() == 1013)
        {
            Abstract13.SetActive(true);
        }

        if (bottomBar.GetSceneNumber() != 1001)
        {
            Abstract1.SetActive(false);
        }

        if (bottomBar.GetSceneNumber() != 1002)
        {
            Abstract2.SetActive(false);
        }

        if (bottomBar.GetSceneNumber() != 1003)
        {
            Abstract3.SetActive(false);
        }

        if (bottomBar.GetSceneNumber() != 1004)
        {
            Abstract4.SetActive(false);
        }

        if (bottomBar.GetSceneNumber() != 1005)
        {
            Abstract5.SetActive(false);
        }

        if (bottomBar.GetSceneNumber() != 1006)
        {
            Abstract6.SetActive(false);
        }

        if (bottomBar.GetSceneNumber() != 1007)
        {
            Abstract7.SetActive(false);
        }

        if (bottomBar.GetSceneNumber() != 1008)
        {
            Abstract8.SetActive(false);
        }

        if (bottomBar.GetSceneNumber() != 1009)
        {
            Abstract9.SetActive(false);
        }

        if (bottomBar.GetSceneNumber() != 1010)
        {
            Abstract10.SetActive(false);
        }

        if (bottomBar.GetSceneNumber() != 152153) // вместо 1011
        {
            Abstract11.SetActive(false);
        }

        if (bottomBar.GetSceneNumber() != 1012)
        {
            Abstract12.SetActive(false);
        }

        if (bottomBar.GetSceneNumber() != 1013)
        {
            Abstract13.SetActive(false);
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

        if (bottomBar.GetSceneNumber() == 8 && isWork8 == true)
        {
            isWork8 = false;
            ShowTextLetter8();
        }

        if (bottomBar.GetSceneNumber() == 9 && isWork9 == true)
        {
            isWork9 = false;
            ShowTextLetter9();
        }

        if (bottomBar.GetSceneNumber() == 11 && isWork11 == true)
        {
            isWork11 = false;
            ShowTextLetter11();
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

        if (bottomBar.GetSceneNumber() == 105 && Letters.VideoStatusScene175 == true)
        {
            Debug.Log("Просмотр видео 'Альберто и София на дне рождения у Хильды'");
            Letters.VideoStatusScene175 = false;
            SaveGameData();
            SceneManager.LoadScene("VideoScene175");
        }

        if (bottomBar.GetSceneNumber() == 111 && Letters.Puzzle1 == true && bottomBar.IsLastSentence() && bottomBar.IsCompleted())
        {
            Debug.Log("Паззл 1");
            ImageCard1.SetActive(true);
            Letters.Puzzle1 = false;
            Letters.NamePuzzle = "images1/image01_8_5";
            SaveGameData();
            SceneManager.LoadScene("JigsawGame");
        }

        if (bottomBar.GetSceneNumber() == 112 && Letters.Puzzle2 == true && bottomBar.IsLastSentence() && bottomBar.IsCompleted())
        {
            Debug.Log("Паззл 2");
            ImageCard2.SetActive(true);
            Letters.Puzzle2 = false;
            Letters.NamePuzzle = "images2/image01_8_5";
            SaveGameData();
            SceneManager.LoadScene("JigsawGame");
        }

        if (bottomBar.GetSceneNumber() == 113 && Letters.Puzzle3 == true && bottomBar.IsLastSentence() && bottomBar.IsCompleted())
        {
            Debug.Log("Паззл 3");
            ImageCard3.SetActive(true);
            Letters.Puzzle3 = false;
            Letters.NamePuzzle = "images3/image01_8_5";
            SaveGameData();
            SceneManager.LoadScene("JigsawGame");
        }

        if (bottomBar.GetSceneNumber() == 114 && Letters.Puzzle4 == true && bottomBar.IsLastSentence() && bottomBar.IsCompleted())
        {
            Debug.Log("Паззл 4");
            ImageCard4.SetActive(true);
            Letters.Puzzle4 = false;
            Letters.NamePuzzle = "images4/image01_8_5";
            SaveGameData();
            SceneManager.LoadScene("JigsawGame");
        }

        if (bottomBar.GetSceneNumber() == 115 && Letters.Puzzle5 == true && bottomBar.IsLastSentence() && bottomBar.IsCompleted())
        {
            Debug.Log("Паззл 5");
            ImageCard5.SetActive(true);
            Letters.Puzzle5 = false;
            Letters.NamePuzzle = "images5/image01_8_5";
            SaveGameData();
            SceneManager.LoadScene("JigsawGame");
        }

        if (bottomBar.GetSceneNumber() == 1000 && bottomBar.IsLastSentence() && bottomBar.IsCompleted())
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

                    else if (bottomBar.IsLastSentence() && bottomBar.GetSceneNumber() == 9192 && Letters.letter10 == false && Letters.letter9 == false && GetLetterAmount() < 4)
                    {
                        PlayScene(Scene92);
                    }

                    else if (bottomBar.IsLastSentence() && bottomBar.GetSceneNumber() == 130132 && Letters.letter9 == false && GetLetterAmount() < 4)
                    {
                        PlayScene(Scene132);
                    }

                    else if (bottomBar.IsLastSentence() && bottomBar.GetSceneNumber() == 132138 && Letters.letter9 == false && GetLetterAmount() < 4)
                    {
                        PlayScene(Scene138);
                    }

                    else if (bottomBar.IsLastSentence() && bottomBar.GetSceneNumber() == 13812140 && Letters.letter9 == false && GetLetterAmount() < 4)
                    {
                        PlayScene(Scene140);
                    }

                    else if (bottomBar.IsLastSentence() && bottomBar.GetSceneNumber() == 140143 && Letters.letter9 == false && GetLetterAmount() < 4)
                    {
                        PlayScene(Scene143);
                    }

                    else if (bottomBar.IsLastSentence() && bottomBar.GetSceneNumber() == 143146 && Letters.letter9 == false && GetLetterAmount() < 4)
                    {
                        PlayScene(Scene146);
                    }

                    else if (bottomBar.IsLastSentence() && bottomBar.GetSceneNumber() == 152153 && Letters.letter9 == false && GetLetterAmount() < 4)
                    {
                        PlayScene(Scene153);
                    }

                    else if (bottomBar.IsLastSentence() && bottomBar.GetSceneNumber() == 1531156 && Letters.letter9 == false && GetLetterAmount() < 4)
                    {
                        PlayScene(Scene156);
                    }

                    else if (bottomBar.IsLastSentence() && bottomBar.GetSceneNumber() == 1561562 && Letters.letter9 == false && GetLetterAmount() < 4)
                    {
                        PlayScene(Scene156p3);
                    }

                    else if (bottomBar.IsLastSentence() && bottomBar.GetSceneNumber() == 1563158 && Letters.letter9 == false && GetLetterAmount() < 4)
                    {
                        PlayScene(Scene158);
                    }

                    else if (bottomBar.IsLastSentence() && bottomBar.GetSceneNumber() == 1591592 && Letters.letter9 == false && GetLetterAmount() < 4)
                    {
                        PlayScene(Scene159p3);
                    }

                    else if (bottomBar.IsLastSentence() && bottomBar.GetSceneNumber() == 1623165 && Letters.letter9 == false && GetLetterAmount() < 4)
                    {
                        PlayScene(Scene165);
                    }

                    else if (bottomBar.IsLastSentence() && bottomBar.GetSceneNumber() == 1657176 && Letters.letter9 == false && GetLetterAmount() < 4)
                    {
                        PlayScene(Scene176);
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

    public void ShowTextLetter8()
    {
        ImageLetterText8.SetActive(true);
        animator.SetTrigger("ShowLetter6");
    }

    public void ShowTextLetter9()
    {
        ImageLetterText9.SetActive(true);
        animator.SetTrigger("ShowLetter6");
    }

    public void ShowTextLetter11()
    {
        ImageLetterText11.SetActive(true);
        animator.SetTrigger("ShowLetter6");
    }

    public void ShowTextCard1()
    {
        ImageCardText1.SetActive(true);
        animator.SetTrigger("ShowLetter6");
    }

    public void ShowTextCard2()
    {
        ImageCardText2.SetActive(true);
        animator.SetTrigger("ShowLetter6");
    }

    public void ShowTextCard3()
    {
        ImageCardText3.SetActive(true);
        animator.SetTrigger("ShowLetter6");
    }

    public void ShowTextCard4()
    {
        ImageCardText4.SetActive(true);
        animator.SetTrigger("ShowLetter6");
    }

    public void ShowTextCard5()
    {
        ImageCardText5.SetActive(true);
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
            letter8 = Letters.letter8,
            letter9 = Letters.letter9,
            letter10 = Letters.letter10,
            letter11 = Letters.letter11,
            puzzleCard1 = Letters.PuzzleCard1,
            puzzleCard2 = Letters.PuzzleCard2,
            puzzleCard3 = Letters.PuzzleCard3,
            puzzleCard4 = Letters.PuzzleCard4,
            puzzleCard5 = Letters.PuzzleCard5,
            keyStatus = Letters.GameKeyStatus,
            mapStatus = Letters.GameMapStatus,
            videoStatusInSchool = Letters.VideoStatusInSchool,
            videoStatusScene96 = Letters.VideoStatusScene96,
            videoStatusScene124 = Letters.VideoStatusScene124,
            videoStatusScene175 = Letters.VideoStatusScene175,
            namePuzzle = Letters.NamePuzzle
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

    public int GetLetterAmount()
    {
        int letterAmount = 0;
        if (Letters.letter1) letterAmount++;
        if (Letters.letter2) letterAmount++;
        if (Letters.letter3) letterAmount++;
        if (Letters.letter4) letterAmount++;
        if (Letters.letter5) letterAmount++;
        if (Letters.letter6) letterAmount++;
        if (Letters.letter7) letterAmount++;
        if (Letters.letter8) letterAmount++;
        if (Letters.letter9) letterAmount++;
        if (Letters.letter10) letterAmount++;
        if (Letters.letter11) letterAmount++;
        Debug.Log(letterAmount);
        return letterAmount;
    }
}
