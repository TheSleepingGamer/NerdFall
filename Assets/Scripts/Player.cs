using System;
using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class Player
{
    public static int intelligenceAmount;
    public static Dictionary<Problem, ProblemData> playerProgressData;

    public static Problem selectedProblem = Problem.Addition;

    public static bool Save()
    {
        try
        {
            BinaryFormatter bf = new BinaryFormatter();

            Dictionary<string, object> dataToSave = new Dictionary<string, object>();
            dataToSave.Add("Intelligance", intelligenceAmount);
            dataToSave.Add("PlayerProgressData", playerProgressData);
            dataToSave.Add("SelectedProblem", selectedProblem);

            //Users\Aleksandar.Tanev\AppData\LocalLow\DefaultCompany\NerdFall
            using (FileStream file = File.Create(Application.persistentDataPath + "/savedGames.gd"))
            {
                bf.Serialize(file, dataToSave);
            }

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public static bool Load()
    {
        try
        {
            if (File.Exists(Application.persistentDataPath + "/savedGames.gd"))
            {
                BinaryFormatter bf = new BinaryFormatter();

                using (FileStream file = File.Open(Application.persistentDataPath + "/savedGames.gd", FileMode.Open))
                {
                    Dictionary<string, object> dataToLoad = (Dictionary<string, object>)bf.Deserialize(file);

                    intelligenceAmount = (int)dataToLoad["Intelligance"];
                    playerProgressData = (Dictionary<Problem, ProblemData>)dataToLoad["PlayerProgressData"];
                    selectedProblem = (Problem)dataToLoad["SelectedProblem"];
                }

                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception)
        {
            return false;
        }
    }
}
