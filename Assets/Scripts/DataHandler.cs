using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using System;

public static class DataHandler
{
    // Start is called before the first frame update
    public static void Save(List<LevelAsset> list, string levelName)
    {
        string content = JsonHelper.ToJson<LevelAsset>(list.ToArray(), true);
        Debug.Log(content);
        var mapDir = Application.persistentDataPath + "/" + levelName + ".json";
        Debug.Log(mapDir);
        FileStream fs = new FileStream(mapDir, FileMode.Create);
        using( StreamWriter writer = new StreamWriter(fs)) {
            writer.Write (content);
        }
    }

    public static void Save(string list, string levelName)
    {
        string content = list;
        Debug.Log(content);
        var mapDir = Application.persistentDataPath + "/" + levelName + ".json";
        Debug.Log(mapDir);
        FileStream fs = new FileStream(mapDir, FileMode.Create);
        using( StreamWriter writer = new StreamWriter(fs)) {
            writer.Write (content);
        }
    }

    public static List<LevelAsset> Load(string levelName) {
        string content = ReadFromJson(levelName);
        if (string.IsNullOrEmpty(content) || content == "{}") {
            return new List<LevelAsset>();
        }

        List<LevelAsset> result = JsonHelper.FromJson<LevelAsset>(content).ToList();
        return result;
    }

    public static string ReadFromJson (string levelName) {
        var lname = Application.persistentDataPath + "/" + levelName;
        
        if (File.Exists(Application.persistentDataPath + "/" + levelName)) {
            using (StreamReader reader = new StreamReader (lname)) {
                string content = reader.ReadToEnd();
                return content;
            }
        }
        return "";
    }

    public static string ReadFromJson (string levelName, string directory) {
        var lname = directory + "/" + levelName ;
        
        if (File.Exists(directory + "/" + levelName )) {
            using (StreamReader reader = new StreamReader (lname)) {
                string content = reader.ReadToEnd();
                return content;
            }
        }
        return "";
    }

}

public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }

    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper);
    }

    public static string ToJson<T>(T[] array, bool prettyPrint)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }

    [Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }
}
