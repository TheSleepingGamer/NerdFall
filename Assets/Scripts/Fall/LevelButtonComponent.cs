using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelButtonComponent : MonoBehaviour
{
    public Text text;

    [HideInInspector]
    public Problem representedProblem;
}
