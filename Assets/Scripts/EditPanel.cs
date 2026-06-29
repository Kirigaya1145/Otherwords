using TMPro;
using UnityEngine;
using System.Collections.Generic;
public class EditPanel : MonoBehaviour
{
    Dictionary<string, string> dictionary;
    public TMP_Text textWordEn;
    public TMP_InputField inputField;
    string english;
    private WordRowUI currentRow;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dictionary = DictionaryManager.instance.dictionary;
        gameObject.SetActive(false);
    }

    public void Open(string en, WordRowUI row)
    {
        english = en;
        currentRow = row;
        textWordEn.text = en;
        inputField.text = dictionary.ContainsKey(en)? dictionary[en] : "???";

        gameObject.SetActive(true);
        inputField.Select();
        inputField.ActivateInputField();
    }

    public void Save()
    {
        dictionary[english] = inputField.text;
        //Coba PlayerPref
        PlayerPrefs.SetString(english, inputField.text);
        PlayerPrefs.Save();

        if (currentRow != null) currentRow.Refresh();
        gameObject.SetActive(false);
    }
    public void Close()
    {
        gameObject.SetActive(false);
    }
}
