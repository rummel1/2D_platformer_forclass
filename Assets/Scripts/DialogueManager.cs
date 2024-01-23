using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    public Image characterIcon;
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI dialogueArea;

    private Queue<DialogueLine> _lines;

    public bool isDialogueActive = false;
    public float typingSpeed = 0f;
    public Animator animator;
    void Start()
    {
        _lines = new Queue<DialogueLine>();
        if (Instance == null)
            Instance = this;
    }
    public void StartDialogue(Dialogue dialogue)
    {
        isDialogueActive = true;
        animator.Play("Dialogue");
        _lines.Clear();
        foreach (DialogueLine dialogueLine in dialogue.dialogueLines)
        {
            _lines.Enqueue(dialogueLine);
        }

        DisplayNextDialogueLine();
    }

    public void DisplayNextDialogueLine()
    {
        if (_lines.Count == 0)
        {
            EndDialogue();
            return;
        }

        DialogueLine currentLine = _lines.Dequeue();
        characterIcon.sprite = currentLine.character.icon;
        characterName.text = currentLine.character.name;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(currentLine));
    }

    private void EndDialogue()
    {
        isDialogueActive = false;
        animator.Play("Dialogue_hide");
    }

    IEnumerator TypeSentence(DialogueLine dialogueLine)
    {
        dialogueArea.text = "";
        foreach (char letter in dialogueLine.line.ToCharArray())
        {
            dialogueArea.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
