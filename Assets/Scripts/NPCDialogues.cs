using System.Collections;
using UnityEngine;

public class NPCDialogues : MonoBehaviour
{
    public Dialogues dialogue;
    public TextScript textScript;
    public void StartDialogue()
    {
        StartCoroutine(OpenDialogue());
    }
    private IEnumerator OpenDialogue()
    {
        textScript.dialogBox.SetActive(true);

        // tunggu 1 frame supaya Layout Group siap
        yield return null;

        textScript.currentDialogue = dialogue;
        textScript.currentIndex = 0;
        textScript.TextAdvance();
    }
}
