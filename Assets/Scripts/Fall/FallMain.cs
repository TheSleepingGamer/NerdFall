using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

// invokerepeating
// https://docs.unity3d.com/ScriptReference/MonoBehaviour.InvokeRepeating.html

public class FallMain : MonoBehaviour
{
    // public int min = -1;
    // public int max = 1;

    public Text message;

    //public float timeBetweenQuestioms = 4f;

    public GameObject spawnPosition;
    public GameObject questionObjectPrefab;

    private QuestionData oneData;



    public void Start()
    {
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
        QuestionComponent qComponent = newObject.GetComponent<QuestionComponent>();
        qComponent.BindQuestionData(qData);
    }

    public void OnCorrectNumberHit(QuestionComponent questionObject)
    {
        this.message.text = "Correct -> " + questionObject.correctAnswer;
        Destroy(questionObject.gameObject);
        this.SpawnNewQuestion(this.oneData);
    }

    public void OnIncorrectNumberHit(int numHit)
    {
        this.message.text = "Incorrect -> " + numHit;
        //this.SpawnNewQuestion(this.oneData);
    }
}
