using TMPro;
using UnityEngine;

public class WordRowUI : MonoBehaviour
{
    public TMP_Text textEn;
    public TMP_Text textId;

    private WordData wordData;
    private EditPanel editPanel;

    public void Setup(WordData data, EditPanel edit)
    {
        wordData = data;
        editPanel = edit;

        textEn.text = data.wordEn;
        textId.text = data.wordId == "" ? "???" : data.wordId;
    }
    public void OnClick()
    {
        editPanel.Open(wordData, this);
    }
    public void Refresh()
    {
        textId.text = wordData.wordId == "" ? "???" : wordData.wordId;
    }
}
