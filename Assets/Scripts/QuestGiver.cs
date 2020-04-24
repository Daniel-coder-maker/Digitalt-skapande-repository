using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestGiver : MonoBehaviour
{
    public Quest quest;
    public Item item;
    public PlayerStats player;
    public GameObject questDescription;
    public TMP_Text titleText;
    public TMP_Text descriptionText;
    public TMP_Text experienceText;
    public TMP_Text goldText;
    public void OpenQuestDescription()
    {
        questDescription.SetActive(true);
        titleText.text = quest.title;
        descriptionText.text = quest.description;
        experienceText.text = quest.experienceReward.ToString();
        goldText.text = quest.goldReward.ToString();
    }

    public void AcceptQuest()
    {
        questDescription.SetActive(false);
        quest.isActive = true;
        quest.isActivelyPersued = true;
        player.quest = quest;
    }
}
