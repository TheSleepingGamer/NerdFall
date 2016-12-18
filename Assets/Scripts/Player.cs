using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;

public static class Player
{
    public static int intelligenceAmount;
    public static Dictionary<Problem, ProblemData> playerProgressData;

    public static Problem selectedProblem = Problem.Addition;

    public static void SavePlayerData()
    {
        
    }

    public static void LoadPlayerData()
    {


    }

    public static string Serialize(object obj)
    {
        StringBuilder xml = new StringBuilder();

        XmlSerializer serializer = new XmlSerializer(obj.GetType());

        using (TextWriter textWriter = new StringWriter(xml))
        {
            serializer.Serialize(textWriter, obj);
        }

        return xml.ToString();
    }

    public static object DeSerialize(string xml, Type type)
    {
        object obj;

        XmlSerializer deserializer = new XmlSerializer(type);

        using (TextReader textReader = new StringReader(xml))
        {
            obj = deserializer.Deserialize(textReader);
        }

        return obj;
    }


}
