using System.Collections.Generic;
using UnityEngine;

public class BookPageUI : MonoBehaviour
{
    Dictionary<string, string> dictionary;
    public Transform pageLeftContent;   
    public Transform pageRightContent;  
    public WordRowUI wordRowPrefab;     
    public EditPanel editPanel;         

    private List<WordRowUI> _rows = new List<WordRowUI>();

    void Start()
    {
        dictionary = DictionaryManager.instance.dictionary;
        SpawnWords();
    }

    void OnEnable()
    {
        
    }

    void SpawnWords()
    {
        foreach (var row in _rows) Destroy(row.gameObject);
        _rows.Clear();

        int half = Mathf.CeilToInt(dictionary.Count / 2f);
        int i = 0;
        foreach(KeyValuePair<string, string> p in dictionary)
        {
            Transform parent = i < half ? pageLeftContent : pageRightContent;

            WordRowUI row = Instantiate(wordRowPrefab, parent);
            row.Setup(p.Key, editPanel);
            _rows.Add(row);
        }
    }
}
