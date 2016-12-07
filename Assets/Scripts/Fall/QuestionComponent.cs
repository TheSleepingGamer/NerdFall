using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuestionComponent : MonoBehaviour
{
    public FallMain targetScript;
    public TextMesh question;
    public BubbleComponent[] bubbles;

    public float fallSpeed;
    public int correctAnswer;

    public void Start()
    {
        for (int i = 0; i < this.bubbles.Length; i++)
        {
            bubbles[i].AttachAHitListener(this.BubbleHitListener);
        }
    }

    public void Update()
    {
        this.transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);

        // TODO: Destroy object based on collider with floor
        if (this.transform.position.y < -16)
        {
            Destroy(this.gameObject);
        }
    }

    public void BubbleHitListener(int numberHit)
    {
        if (numberHit == this.correctAnswer)
        {
            this.targetScript.OnCorrectNumberHit(this);
        }
        else
        {
            this.targetScript.OnIncorrectNumberHit(numberHit);
        }
    }

    public void BindQuestionData(QuestionData data)
    {
        this.question.text = data.question;
        this.correctAnswer = data.correctAnswer;

        for (int i = 0; i < data.givenNumbers.Count; i++)
        {
            this.bubbles[i].SetNumber(data.givenNumbers[i]);
        }
    }
}
