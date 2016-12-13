using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HomeScript : MonoBehaviour
{
    private const string LEVEL_TEXT = "Level\n";

    public Text additionText;

    public Text subrtactionText;

    public Text divisionText;

    public Text multiplicationText;

    public Text trigonometryText;

    public Text fibonacciText;

    void Start()
    {
        if (Player.intelligenceAmount >= 600)
        {
            maxValueInCollection(Problem.Fibonacci, this.fibonacciText);
        }

        if (Player.intelligenceAmount > 450)
        {
            maxValueInCollection(Problem.Trigonometry, this.trigonometryText);
        }

        if (Player.intelligenceAmount > 350)
        {
            maxValueInCollection(Problem.Division, this.divisionText);
        }

        if (Player.intelligenceAmount > 250)
        {
            maxValueInCollection(Problem.Subtraction, this.subrtactionText);
        }

        maxValueInCollection(Problem.Addition, this.additionText);
    }

    private void maxValueInCollection(Problem ProblemType, Text textToChange)
    {
        int maxLevel = 1;

        ProblemData problemData = Player.playerProgressData[ProblemType];

        foreach (var entry in problemData.levels)
        {
            if (entry.Value != true)
            {
                break;
            }

            maxLevel = entry.Key;
        }

        textToChange.text = LEVEL_TEXT + maxLevel;
        textToChange.color = Color.black;
    }
}
