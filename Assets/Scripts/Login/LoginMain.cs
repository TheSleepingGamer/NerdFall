using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LoginMain : MonoBehaviour
{
    public AudioSource clickButton;

    public void OnClickStartGame()
    {
        StartCoroutine(PlayButtonClickSound());
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
        StartCoroutine(PlayButtonClickSound());
        Application.Quit();
    }

    private IEnumerator PlayButtonClickSound()
    {
        clickButton.Play();
        yield return new WaitForSeconds(clickButton.clip.length);
    }
}
