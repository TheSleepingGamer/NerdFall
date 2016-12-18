using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginMain : MonoBehaviour
{
    public AudioSource clickButton;
    public Text startGameButtonText;

    public void OnClickStartGame()
    {
        // Mocking player data
        /*  Player.intelligenceAmount = 150;
          Player.playerProgressData = 
          Player.playerProgressData.Add(Problem.Addition, ProblemManager.GenerateNewProblem(Problem.Addition));
          Player.playerProgressData.Add(Problem.Subtraction, ProblemManager.GenerateNewProblem(Problem.Subtraction)); */
        // -------------

        if (!Player.Load())
        {
            Player.playerProgressData = new Dictionary<Problem, ProblemData>();
            Player.playerProgressData.Add(Problem.Addition, ProblemManager.GenerateNewProblem(Problem.Addition));
            Player.selectedProblem = Problem.Addition;
            Player.intelligenceAmount = 0;

            if (!Player.Save())
            {
                Debug.LogError("Couldn't save player data!");
            }

            Debug.Log("New Player data was created and saved!");
        }
        else
        {
            Debug.Log("Player data loaded successfully!");
        }

        StartCoroutine(PlayButtonClickSound());

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
