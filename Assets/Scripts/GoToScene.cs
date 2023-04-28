using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour
{
    private string input;
    private int inputNumber;
    private State state = State.IDLE;

    private enum State
    {
        IDLE, ANIMATE, CHOOSE
    }

    public DataHolder data;
    private List<StoryScene> history = new List<StoryScene>();
    public GameScene currentScene;
    public BottomBarController bottomBar;
    public SpriteSwitcher backgroundController;
    public AudioController audioController;
    public ChooseController chooseController;


    void Start()
    {
        if (inputNumber != 0)
        {
            //NextSentence.nextSceneStatus = true;
            currentScene = data.scenes[inputNumber];
            Debug.Log(currentScene);

            StoryScene storyScene = currentScene as StoryScene;
            bottomBar.PlayScene(storyScene);
            //history.Add(storyScene);
            backgroundController.SetImage(storyScene.background);
            PlayAudio(storyScene.sentences[bottomBar.GetSentenceIndex()]);
            inputNumber = 0;

            Debug.Log("Next scene: " + (currentScene as StoryScene).nextScene);
        }
    }

    void Update()
    {
        //if (state == State.IDLE)
        //{
            Debug.Log("1");
            if (NextSentence.nextSceneStatus)
            {
                Debug.Log("2");
                if (NextSentence.nextSentenceStatus)
                {
                    if (bottomBar.IsCompleted())
                    {
                        Debug.Log("3");
                        if (inputNumber != 0)
                        {
                            Debug.Log("4");
                            currentScene = data.scenes[inputNumber];
                            Debug.Log(currentScene);

                            StoryScene storyScene = currentScene as StoryScene;
                            bottomBar.PlayScene(storyScene);
                            //history.Add(storyScene);
                            backgroundController.SetImage(storyScene.background);
                            PlayAudio(storyScene.sentences[bottomBar.GetSentenceIndex()]);
                            inputNumber = 0;
                            NextSentence.nextSentenceStatus = false;

                            Debug.Log("Next scene: " + (currentScene as StoryScene).nextScene);
                        }

                        else if (bottomBar.IsLastSentence())
                        {
                            PlayScene((currentScene as StoryScene).nextScene);
                            NextSentence.nextSentenceStatus = false;
                        }
                        else
                        {
                            NextSentence.nextSentenceStatus = false;
                            bottomBar.PlayNextSentence();
                            PlayAudio((currentScene as StoryScene)
                                .sentences[bottomBar.GetSentenceIndex()]);
                        }
                    }
                } 
            }
        //}
    }

    public void ReadStringInput(string s)
    {
        //NextSentence.nextSceneStatus = true;
        input = s;
        inputNumber = Convert.ToInt32(input);
        Debug.Log("Выбранная сцена:" + data.scenes[inputNumber]);
    }

    public void PlayScene(GameScene scene, int sentenceIndex = -1, bool isAnimated = true)
    {
        StartCoroutine(SwitchScene(scene, sentenceIndex, isAnimated));
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
