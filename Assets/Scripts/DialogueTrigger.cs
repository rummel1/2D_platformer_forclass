using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class DialogueCharacter
{
    public string name;
    public Sprite icon;
}
[System.Serializable]
public class DialogueLine
{
    public DialogueCharacter character;
    [TextArea(3,10)]
    public string line;
}
[System.Serializable]
public class Dialogue
{
    public List<DialogueLine> dialogueLines = new List<DialogueLine>();
}
public class DialogueTrigger : MonoBehaviour
{
    public GameObject CanvasF;
    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        DialogueManager.Instance.StartDialogue(dialogue);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("MainPlayer"))
        {
            CanvasF.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("MainPlayer"))
        {
            if (Input.GetKey(KeyCode.F))
            { 
                CanvasF.SetActive(false);
                TriggerDialogue();
            }
           
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        CanvasF.SetActive(false);
    }
}
