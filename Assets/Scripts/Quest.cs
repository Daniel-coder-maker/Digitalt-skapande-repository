using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    Inventory inventory;
    PlayerStats pstats;
    public bool isActive;
    public bool isActivelyPersued;
    public int enemyID;

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
        pstats.Rewarded();
        Debug.Log("Quest:" + title + " is completed!");
    }
}
