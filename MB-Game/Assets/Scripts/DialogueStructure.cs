using UnityEngine;

[System.Serializable]
public class DialogueStructure
{
    public string name;
    [TextArea(1, 3)] public string[] sentence;
}
