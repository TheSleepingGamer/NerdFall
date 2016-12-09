using UnityEngine;
using System.Collections.Generic;

public class LoginMain : MonoBehaviour
{
    public void OnClickStartGame()
    {
        // Mocking player data
        Player.intelligenceAmount = 150;
        Player.playerProgressData = new Dictionary<Problem, ProblemData>();
        Player.playerProgressData.Add(Problem.Addition, ProblemManager.GenerateNewProblem(Problem.Addition));
        for (int i = 2; i < 10; i++)
        {
            Player.playerProgressData[Problem.Addition].levels[i] = true;
        }
        // -------------

        GameStateManager.TransitionToScene(GameScene.Home);
    }

    public void OnClickExit()
    {
        Application.Quit();
    }
}
