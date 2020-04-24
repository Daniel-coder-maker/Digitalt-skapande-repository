using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialougetrigger : MonoBehaviour
{
    public Dialouge dialouge;

    public void TriggerDialouge()
    {
        FindObjectOfType<DialogueSystem>().StartTalk(dialouge);
    }
}
