using System;
using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System.Collections;
public class DictionaryManager : MonoBehaviour
{
    public static DictionaryManager instance;
    public List<WordData> words = new List<WordData>();

    private void Awake()
    {
        instance = this;
        words.Add(new WordData { wordEn = "tree", wordId = "" });
        words.Add(new WordData { wordEn = "run", wordId = "" });
        words.Add(new WordData { wordEn = "slay", wordId = "" });
        words.Add(new WordData { wordEn = "bag", wordId = "" });
        words.Add(new WordData { wordEn = "horse", wordId = "" });
        words.Add(new WordData { wordEn = "road", wordId = "" });
    }
}
