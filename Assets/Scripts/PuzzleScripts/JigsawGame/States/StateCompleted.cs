using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Patterns;
using UnityEngine.SceneManagement;

// The Loading Playing.
public class StateCompleted : State<JigsawGameStates>
{
    public JigsawGame Game { get; set; }
    public StateCompleted(JigsawGame game) : 
        base(JigsawGameStates.COMPLETED)
    {
        Game = game;
    }

    public override void Enter()
    {
        base.Enter();
        SceneManager.LoadScene("LoadScene");
        Game.menu.TextWin.gameObject.SetActive(true);
        Game.menu.SetActivePlayBtn(true);
    }
}
