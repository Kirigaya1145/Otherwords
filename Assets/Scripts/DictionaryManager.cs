using System;
using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System.Collections;
public class DictionaryManager : MonoBehaviour
{
    public static DictionaryManager instance;
    public Dictionary<string, string> dictionary = new Dictionary<string, string>();

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);



        LoadPref("i");
        LoadPref("you");
        LoadPref("they");
        LoadPref("that");
        LoadPref("this");
        LoadPref("bag");
        LoadPref("road");
        /* Coba playerPref
        dictionary.Add("i", "aku");
        dictionary.Add("you", "kamu");
        dictionary.Add("they", "?");
        dictionary.Add("that", "itu");
        dictionary.Add("this", "?");
        dictionary.Add("bag", "?");
        dictionary.Add("road", "?");*/
    }
    void LoadPref(string word)
    {
        dictionary[word] = PlayerPrefs.GetString(word, "?");
    }
}
