using TMPro;
using UnityEngine;
using System.Collections.Generic;
public class WordRowUI : MonoBehaviour
{
    Dictionary<string, string> dictionary;
    public TMP_Text textEn;
    public TMP_Text textId;

    string english;
    private EditPanel editPanel;

    public void Setup(string en, EditPanel edit)
    {
        dictionary = DictionaryManager.instance.dictionary;
        english = en;
        editPanel = edit;

        textEn.text = en;
        
        textId.text = dictionary.ContainsKey(en)? dictionary[en] : "???";
    }

    public void OnClick()
    {
        editPanel.Open(english, this);
    }

    public void Refresh()
    {
        dictionary = DictionaryManager.instance.dictionary;
        textId.text = dictionary.ContainsKey(english)? dictionary[english] : "???";
    }
}
