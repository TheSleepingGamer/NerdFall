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
        maxValueInCollection(Problem.Addition, this.additionText);

        maxValueInCollection(Problem.Subtraction, this.subrtactionText);

        maxValueInCollection(Problem.Division, this.divisionText);

        maxValueInCollection(Problem.Trigonometry, this.trigonometryText);

        maxValueInCollection(Problem.Fibonacci, this.fibonacciText);
    }

    private void maxValueInCollection(Problem ProblemType, Text textToChange)
    {
        if (Player.playerProgressData.ContainsKey(ProblemType))
        {
            ProblemData problemData = Player.playerProgressData[ProblemType];

            if (problemData.levels.Count > 0)
            {
                int maxLevel = 1;

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
    }
}
