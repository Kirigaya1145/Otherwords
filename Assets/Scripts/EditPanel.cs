using TMPro;
using UnityEngine;

public class EditPanel : MonoBehaviour
{
    public TMP_Text textWordEn;
    public TMP_InputField inputField;
    private WordData currentWord;
    private WordRowUI currentRow;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Open(WordData data, WordRowUI row)
    {
        currentWord = data;
        currentRow = row;
        textWordEn.text = data.wordEn;
        inputField.text = data.wordId;

        gameObject.SetActive(true);
        inputField.Select();
        inputField.ActivateInputField();
    }
    public void Save()
    {
        currentWord.wordId = inputField.text;
        if (currentRow != null) currentRow.Refresh();
        gameObject.SetActive(false);
    }
    public void Close()
    {
        gameObject.SetActive(false);
    }
}
