﻿using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

// invokerepeating
// https://docs.unity3d.com/ScriptReference/MonoBehaviour.InvokeRepeating.html

public class FallMain : MonoBehaviour
{
    [Header("HUD elements")]

    public Text problemText;
    public Text levelText;
    public Text intAmountText;

    public Text messageHolderText;
    public Text startGameButtonText;

    public GameObject menu;
    public GameObject actionChoicePanel;
    public GameObject problemChoicePanel;
    public GameObject levelChoicePanel;

    public GameObject problemButtonContainer;
    public GameObject levelButtonContainer;

    public GameObject problemButtonPrefab;
    public GameObject levelButtonPrefab;

    [Header("Game elements")]

    public WeaponController weaponController;

    public GameObject spawnPosition;
    public GameObject questionObjectPrefab;

    private bool isGameRunning;

    private Problem currentlySelectedProblem;
    private int currentLevel;
    private int spawnCount;

    private QuestionComponent currentlyActiveQuestObject;
    private BulletComponent currentlyFiredWeapon;

    public void Start()
    {
        this.currentlyFiredWeapon = this.weaponController.LoadNewBullet().GetComponent<BulletComponent>();
        this.currentlyFiredWeapon.AddListenerToBullet(OnBulletDeactivation);

        this.isGameRunning = false;

        this.currentlySelectedProblem = Problem.Addition;
        this.currentLevel = 1;

        /*// Mocking player data
        Player.intelligenceAmount = 150;
        Player.playerProgressData = new Dictionary<Problem, ProblemData>();
        Player.playerProgressData.Add(Problem.Addition, ProblemManager.GenerateNewProblem(Problem.Addition));
        Player.playerProgressData.Add(Problem.Subtraction, ProblemManager.GenerateNewProblem(Problem.Subtraction));
        for (int i = 2; i < 10; i++)
        {
            Player.playerProgressData[Problem.Subtraction].levels[i] = true;
        }*/
        // -------------

        this.UpdateInfoPanel();
        this.UpdatePlayerResources(0);
        this.GenerateProblemsInProblemPanel();

        this.spawnCount = 1;
        this.SpawnNewQuestion(ProblemManager.GetNewQuestion(this.currentlySelectedProblem, this.currentLevel, this.spawnCount));

    }

    private void GenerateProblemsInProblemPanel()
    {
        for (int i = 0; i < this.problemButtonContainer.transform.childCount; i++)
        {
            Destroy(this.problemButtonContainer.transform.GetChild(i).gameObject);
        }

        foreach (var problem in Player.playerProgressData)
        {
            GameObject newProblemButton = (GameObject)Instantiate(this.problemButtonPrefab, Vector3.zero, this.spawnPosition.transform.rotation);
            newProblemButton.transform.parent = this.problemButtonContainer.transform;

            ProblemButtonComponent newProblemButtonComponent = newProblemButton.GetComponent<ProblemButtonComponent>();
            newProblemButtonComponent.SetProblem(problem.Key);
        }
    }

    private void GenerateLevelsInLevelPanel(Problem selectedProblem)
    {
        for (int i = 0; i < this.levelButtonContainer.transform.childCount; i++)
        {
            Destroy(this.levelButtonContainer.transform.GetChild(i).gameObject);
        }

        foreach (var level in Player.playerProgressData[selectedProblem].levels)
        {
            if (level.Value)
            {
                GameObject newLevelButton = (GameObject)Instantiate(this.levelButtonPrefab, Vector3.zero, new Quaternion(0, 0, 0, 0));
                newLevelButton.transform.parent = this.levelButtonContainer.transform;

                LevelButtonComponent newProblemButtonComponent = newLevelButton.GetComponent<LevelButtonComponent>();
                newProblemButtonComponent.text.text = level.Key.ToString();
                newProblemButtonComponent.representedProblem = selectedProblem;
            }
        }
    }

    public void OnCorrectNumberHit(QuestionComponent questionObject)
    {
        this.messageHolderText.text = "Correct -> " + questionObject.correctAnswer;

        this.currentlyActiveQuestObject = null;
       // Destroy(questionObject.gameObject);
        Destroy(questionObject.gameObject);

        this.UpdatePlayerResources(1);

        this.spawnCount++;
        this.SpawnNewQuestion(ProblemManager.GetNewQuestion(this.currentlySelectedProblem, this.currentLevel, this.spawnCount));
    }

    public void OnIncorrectNumberHit(int numHit)
    {
        this.messageHolderText.text = "You failed!";

        if (numHit == -1)
        {
            this.StartNewGame();
        }
        //this.StartNewGame();
    }

    private void SpawnNewQuestion(QuestionData qData)
    {
        GameObject newObject = (GameObject)Instantiate(this.questionObjectPrefab, this.spawnPosition.transform.position, this.spawnPosition.transform.rotation);
        newObject.SetActive(true);
        QuestionComponent qComponent = newObject.GetComponent<QuestionComponent>();
        qComponent.BindQuestionData(qData);

        this.currentlyActiveQuestObject = qComponent;
    }

    //------------------------

    public void OnClickButtonMenu()
    {
        this.PauseGame();

        if (!this.isGameRunning)
        {
            this.startGameButtonText.text = "Start";
        }
        else
        {
            this.startGameButtonText.text = "Resume";
        }

        this.menu.SetActive(true);
    }

    public void OnClickButtonStartGame()
    {
        this.ResumeGame();

        this.isGameRunning = true;
        this.menu.SetActive(false);

        if (this.startGameButtonText.text == "Start")
        {
            this.StartNewGame();
        }
    }

    public void StartNewGame()
    {
        if (this.currentlyActiveQuestObject != null)
        {
            Destroy(this.currentlyActiveQuestObject.gameObject);
            this.currentlyActiveQuestObject = null;
        }

        if (this.currentlyFiredWeapon != null)
        {
            Destroy(this.currentlyFiredWeapon.gameObject);
            this.currentlyFiredWeapon = null;
            this.weaponController.loadedBullet = null;
        }

        this.weaponController.Resume();
        this.currentlyFiredWeapon = this.weaponController.LoadNewBullet().GetComponent<BulletComponent>();
        this.currentlyFiredWeapon.AddListenerToBullet(OnBulletDeactivation);

        this.spawnCount = 1;
        this.SpawnNewQuestion(ProblemManager.GetNewQuestion(this.currentlySelectedProblem, this.currentLevel, this.spawnCount));

    }

    public void OnClickButtonChangeLevel()
    {
        //TODO: Fill available problems - probably not needed due to this being done in begining
        this.actionChoicePanel.SetActive(false);
        this.problemChoicePanel.SetActive(true);
    }

    public void OnClickButtonProblem(ProblemButtonComponent problemButtonComponent)
    {
        this.GenerateLevelsInLevelPanel(problemButtonComponent.GetProblem());

        this.problemChoicePanel.SetActive(false);
        this.levelChoicePanel.SetActive(true);
    }

    public void OnClickButtonLevel(LevelButtonComponent levelButtonComponent)
    {
        this.currentlySelectedProblem = levelButtonComponent.representedProblem;
        this.currentLevel = int.Parse(levelButtonComponent.text.text);

        this.UpdateInfoPanel();

        this.isGameRunning = false;
        this.startGameButtonText.text = "Start";

        //TODO: Destroy objects on screen

        this.levelChoicePanel.SetActive(false);
        this.actionChoicePanel.SetActive(true);
    }

    private void UpdateInfoPanel()
    {
        this.problemText.text = this.currentlySelectedProblem.ToString();
        this.levelText.text = this.currentLevel.ToString();
    }

    private void UpdatePlayerResources(int amount)
    {
        Player.intelligenceAmount += amount;
        this.intAmountText.text = Player.intelligenceAmount.ToString();
    }

    public void OnClickButtonOpenMap()
    {
        GameStateManager.TransitionToScene(GameScene.Map);
    }

    public void OnBulletDeactivation()
    {
        this.currentlyFiredWeapon = this.weaponController.LoadNewBullet().GetComponent<BulletComponent>();
        this.currentlyFiredWeapon.AddListenerToBullet(OnBulletDeactivation);
    }

    private void PauseGame()
    {
        this.currentlyActiveQuestObject.Pause();
        this.currentlyFiredWeapon.Pause();
        this.weaponController.Pause();
    }

    private void ResumeGame()
    {
        this.currentlyActiveQuestObject.Resume();
        this.currentlyFiredWeapon.Resume();
        this.weaponController.Resume();
    }
}
