using UnityEngine;
using System.Collections.Generic;

[System.Serializable] 
public class Dialogue
{
    public string character;
    public string text;
}

[CreateAssetMenu(fileName = "Dialogue", menuName = "Dialogue")]
public class Dialogues : ScriptableObject
{
    public List<Dialogue> dialogues = new List<Dialogue>();
}
