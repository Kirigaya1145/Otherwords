using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using TMPro;
public class TextScript : MonoBehaviour
{
    Dictionary<string, string> dictionary;
    public Dialogues currentDialogue;
    public int currentIndex = 0;

    #region Dialog Box
    public GameObject dialogBox;
    RectTransform rectTransform;
    float bYMax;
    float bXMax;
    #endregion

    public GameObject textItem;
    public char[] skipChar = new char[] { ',', '.', ';', ' ', '?', '!' };
    public List<GameObject> dialogueTexts = new List<GameObject>();

    //ngetes layout container
    public Transform wordContainer;
    public bool isTalking = false;
    void Start()
    {
        dictionary = DictionaryManager.instance.dictionary;
        rectTransform = dialogBox.GetComponent<RectTransform>();
    
        if (rectTransform != null)
        {
            bYMax = rectTransform.rect.height;
            bXMax = rectTransform.rect.width;
        }
    }

    public void OnAttack()
    {
        TextAdvance();
    }
  
    public void OnInteract()
    {
        TextAdvance();
    }

    public void OnInteract(InputValue value)
    {
        // value.isPressed is true when pushed down, false when released
        if (value.isPressed)
        {
            TextAdvance();
        }
    }
    public void TextAdvance()
    {
        isTalking = true;
        ResetDialogueTexts();
        /*Tes ubah pakai HorizontalLayout
        Vector3 spawnPosition = dialogBox.transform.position;
        
        #region Debug Position
        // Debug.Log(spawnPosition.y);
        // Debug.Log(bYMax);
        // Debug.Log(spawnPosition.x);
        // Debug.Log(bXMax);
        #endregion

        spawnPosition.y += bYMax;
        spawnPosition.x = bXMax/3;
        Quaternion spawnRotation = Quaternion.identity; */

        string[] pureTexts = currentDialogue.dialogues[currentIndex].text.Split(" ");
        
        for(int i = 0; i < pureTexts.Length; i++)
        {
            if(pureTexts[i] != "")
            {
                //GameObject insText = Instantiate(textItem, spawnPosition, spawnRotation, transform);
                GameObject insText = Instantiate(textItem, wordContainer);
                dialogueTexts.Add(insText);
                TextHolder textHolder = insText.GetComponent<TextHolder>();
                if(textHolder != null)
                {
                    textHolder.enText.text = pureTexts[i];
                    string dictKey = pureTexts[i].Trim(skipChar).ToLower();
                    if(dictionary.ContainsKey(dictKey)) textHolder.idText.text = dictionary[dictKey];
                    textHolder.enText.ForceMeshUpdate();
                    Debug.Log(pureTexts[i] + dictKey);

                    /* Tes ubah pakai HorizontalLayout ubah Spacing di panelDialog
                    float textWidth = textHolder.enText.preferredWidth;
                    // Debug.Log(textWidth);
                    spawnPosition.x += (textWidth*1.25f)+100f;*/
                }
            }
        }
        
        if(currentIndex < currentDialogue.dialogues.Count - 1)
        {
            currentIndex++;
        }
        else
        {
            isTalking = false;
            currentDialogue = null;
            dialogBox.SetActive(false);
        }
    }

    public void ResetDialogueTexts()
    {
        for (int i = dialogueTexts.Count - 1; i >= 0; i--)
        {
            if (dialogueTexts[i] != null)
            {
                Destroy(dialogueTexts[i]);
            }
        }

        dialogueTexts.Clear();
    }
}
