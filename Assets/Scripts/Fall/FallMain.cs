using System;
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

    [Header("Game elements")]

    public GameObject spawnPosition;
    public GameObject questionObjectPrefab;

    private QuestionData oneData;

    private bool isGameRunning;

    public void Start()
    {
        this.isGameRunning = false;

        this.oneData = new QuestionData()
        {
            question = "3 + 7",
            correctAnswer = 10,
            givenNumbers = new List<int>()
            {
                2,
                8,
                7,
                10
            }
        
        };

        this.SpawnNewQuestion(this.oneData);
    }

    /*
    private float timer = 0f;
    private List<float> spawnPositions;
    
    public void Start()
    {
        this.timeBetweenQuestioms = Time.time + timeBetweenQuestioms;

        this.spawnPositions = new List<float>()
        {
            -6,
            -2,
            2,
            6
        };
    }
    
    public void Update()
    {
        // TODO: replace with InvokeRepeat()
        timer += Time.deltaTime;
        if (timer >= timeBetweenQuestioms)
        {
            this.SpawnNewQuestion();
            timer = 0f;
        }
    }*/

    private void SpawnNewQuestion(QuestionData qData)
    {
        GameObject newObject = (GameObject)Instantiate(this.questionObjectPrefab, this.spawnPosition.transform.position, this.spawnPosition.transform.rotation);
        newObject.SetActive(true);
        QuestionComponent qComponent = newObject.GetComponent<QuestionComponent>();
        qComponent.BindQuestionData(qData);
    }

    public void OnCorrectNumberHit(QuestionComponent questionObject)
    {
        this.messageHolderText.text = "Correct -> " + questionObject.correctAnswer;
        Destroy(questionObject.gameObject);
        this.SpawnNewQuestion(this.oneData);
    }

    public void OnIncorrectNumberHit(int numHit)
    {
        this.messageHolderText.text = "Incorrect -> " + numHit;
        //this.EndGame;
    }

    //------------------------

    public void OnClickButtonMenu()
    {
        // TODO: Pause game

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
        this.isGameRunning = true;
        this.menu.SetActive(false);
        
        //TODO: Start game
    }

    public void OnClickButtonChangeLevel()
    {
        //TODO: Fill available problems
        this.actionChoicePanel.SetActive(false);
        this.problemChoicePanel.SetActive(true);
    }

    public void OnClickButtonProblem()
    {
        //TODO: Fill levels
        this.problemChoicePanel.SetActive(false);
        this.levelChoicePanel.SetActive(true);
    }

    public void OnClickButtonLevel()
    {
        this.isGameRunning = false;
        this.startGameButtonText.text = "Start";

        //TODO: Load new level information

        this.levelChoicePanel.SetActive(false);
        this.actionChoicePanel.SetActive(true);
    }

    public void OnClickButtonOpenMap()
    {
        throw new NotImplementedException();
    }


}
