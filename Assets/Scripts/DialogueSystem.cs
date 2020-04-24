using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    public Animator animator;
    public TMP_Text nameText;
    public TMP_Text dialougeText;
    private Queue<string> sentences;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartTalk(Dialouge dialouge)
    {
        animator.SetBool("IsTalking", true);
        nameText.text = dialouge.name;
        sentences.Clear();
        foreach(string sentence in dialouge.sentences)
        {
            sentences.Enqueue(sentence);
            
        }
        DisplaySentence();
    }

    public void DisplaySentence()
    {
        if (sentences.Count == 0)
        {
            EndTalking();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialougeText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialougeText.text += letter;
            yield return null;
        }
    }

    void EndTalking()
    {
        animator.SetBool("IsTalking", false);
    }
}
