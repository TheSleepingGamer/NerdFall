using System;
using System.Collections.Generic;
using System.Linq;

public static class ProblemManager
{
    public static int AmountOfQuestionsPerLevel = 50;

    public static ProblemData GenerateNewProblem(Problem wanterProblem)
    {
        switch (wanterProblem)
        {
            case Problem.Addition:
                return GenerateAdditionData();
            case Problem.Subtraction:
                return GenerateSubtractionData();
            default:
                throw new ArgumentException("Problem cannot be generated.");
        }
    }

    private static ProblemData GenerateAdditionData()
    {
        ProblemData newData = new ProblemData(Problem.Addition);
        newData.levels.Add(1, true);
        for (int i = 2; i <= 50; i++)
        {
            newData.levels.Add(i, false);
        }

        newData.levelsSpawnCount.Add(1, 15);
        for (int i = 2; i <= 50; i++)
        {
            newData.levelsSpawnCount.Add(i, 15);
        }

        return newData;
    }

    private static ProblemData GenerateSubtractionData()
    {
        ProblemData newData = new ProblemData(Problem.Addition);
        newData.levels.Add(1, true);
        for (int i = 2; i <= 50; i++)
        {
            newData.levels.Add(i, false);
        }

        newData.levelsSpawnCount.Add(1, 15);
        for (int i = 2; i <= 50; i++)
        {
            newData.levelsSpawnCount.Add(i, 15);
        }

        return newData;
    }

    public static QuestionData GetNewQuestion(Problem problem, int level, int spawnNumber)
    {
        switch (problem)
        {
            case Problem.Addition:
                return GetNewAddtitionQuestion(level, spawnNumber);
            case Problem.Subtraction:
                return GetNewSubtractionQuestion(level, spawnNumber);
            default:
                throw new ArgumentException("Problem cannot be generated.");
        }
    }

    private static QuestionData GetNewAddtitionQuestion(int level, int spawnNumber)
    {
        QuestionData newQData = new QuestionData();

        int a = level;
        int b = UnityEngine.Random.Range(0, level + 10 + spawnNumber);
        newQData.question = a.ToString() + " + " + b.ToString();

        int correctAnswer = a + b;
        newQData.correctAnswer = correctAnswer;

        HashSet<int> differentNumbersCollection = new HashSet<int>();
        differentNumbersCollection.Add(correctAnswer);

        while (differentNumbersCollection.Count < 4)
        {
            int newIncorrectAnswer = UnityEngine.Random.Range(a, level + 10 + spawnNumber + a);

            if (newIncorrectAnswer != correctAnswer && !differentNumbersCollection.Contains(newIncorrectAnswer))
            {
                differentNumbersCollection.Add(newIncorrectAnswer);
            }
        }

        newQData.givenNumbers = differentNumbersCollection.ToList();
        Shuffle(newQData.givenNumbers);

        return newQData;
    }

    private static QuestionData GetNewSubtractionQuestion(int level, int spawnNumber)
    {
        throw new NotImplementedException();
    }

    private static void Shuffle(List<int> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = UnityEngine.Random.Range(0, n + 1);
            int value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}