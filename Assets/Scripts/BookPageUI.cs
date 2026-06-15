using System.Collections.Generic;
using UnityEngine;

public class BookPageUI : MonoBehaviour
{
    public Transform pageLeftContent;   
    public Transform pageRightContent;  
    public WordRowUI wordRowPrefab;     
    public EditPanel editPanel;         

    private List<WordRowUI> _rows = new List<WordRowUI>();

    void OnEnable()
    {
        SpawnWords();
    }

    void SpawnWords()
    {
        foreach (var row in _rows) Destroy(row.gameObject);
        _rows.Clear();

        var words = DictionaryManager.instance.words;
        int half = Mathf.CeilToInt(words.Count / 2f);

        for (int i = 0; i < words.Count; i++)
        {
            Transform parent = i < half ? pageLeftContent : pageRightContent;

            WordRowUI row = Instantiate(wordRowPrefab, parent);
            row.Setup(words[i], editPanel);
            _rows.Add(row);
        }
    }
}
