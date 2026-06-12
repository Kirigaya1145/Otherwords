using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using TMPro;
public class TextScript : MonoBehaviour
{
    Dictionary<string, string> dictionary = new Dictionary<string, string>();
    public Dialogues currentDialogue;
    public int currentIndex = 0;
    public char[] skipChar = new char[] { ',', '.', ';', ' ', '?', '!' };
    public GameObject textItem;
    public List<GameObject> dialogueTexts = new List<GameObject>();
    void Start()
    {
        dictionary.Add("you", "kamu");
    }

    // Update is called once per frame
    void Update()
    {
        
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
        ResetDialogueTexts();
        Vector3 spawnPosition = new Vector3(500, 500, 0f);
        Quaternion spawnRotation = Quaternion.identity; 
        string[] splitTexts = currentDialogue.dialogues[currentIndex].text.ToLower().Split(skipChar);
        for(int i = 0; i < splitTexts.Length; i++)
        {
            if(splitTexts[i] != "")
            {
                GameObject insText = Instantiate(textItem, spawnPosition, spawnRotation, transform);
                dialogueTexts.Add(insText);
                TextHolder textHolder = insText.GetComponent<TextHolder>();
                if(textHolder != null)
                {
                    textHolder.enText.text = splitTexts[i];
                    string dictKey = splitTexts[i].Trim(skipChar);
                    if(dictionary.ContainsKey(dictKey)) textHolder.idText.text = dictionary[dictKey];
                    textHolder.enText.ForceMeshUpdate();
                    float textWidth = textHolder.enText.preferredWidth;
                    spawnPosition.x += textWidth+ 100f;
                }
            }
        }
        
        if(currentIndex < currentDialogue.dialogues.Count - 1)currentIndex++;
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
