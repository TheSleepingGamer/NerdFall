using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ProblemButtonComponent : MonoBehaviour
{
    public Text text;

    private Problem problem;

    public Problem GetProblem()
    {
        return this.problem;
    }

    public void SetProblem(Problem problem)
    {
        this.problem = problem;
        this.text.text = problem.ToString();
    }
}
