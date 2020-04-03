using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    Inventory inventory;
    public bool isActive;
    public bool isActivelyPersued;

    public string title;
    public string description;
    public int experienceReward;
    public int goldReward;
    public Equipment questItemReward;

    public QuestGoal goal;

    public void Complete()
    {
        isActive = false;
        isActivelyPersued = false;
        inventory.Add(questItemReward);
        Debug.Log("Quest:" + title + " is completed!");
    }
}
