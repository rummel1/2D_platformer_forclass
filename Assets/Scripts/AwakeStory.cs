using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AwakeStory : MonoBehaviour
{
    public TextMeshProUGUI displayText;
    public float typingSpeed = 0.05f;
    public string line;
    public GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("MainPlayer");
        player.GetComponent<PlayerController>().enabled = false;
        StartDialogue();
    }

    private void Update()
    {
    }

    private void StartDialogue()
    {
        StartCoroutine(TypeSentence());
    }
    IEnumerator TypeSentence()
    {
        displayText.text = "";
        foreach (char letter in line.ToCharArray())
        {
            displayText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void Exit()
    {
        player.GetComponent<PlayerController>().enabled = true;
        Destroy(gameObject);
    }
}
