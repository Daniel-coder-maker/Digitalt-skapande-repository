using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestGoal
{

    //public Quest questGoal;
    public GoalType goalType;
    public int requiredAmount;
    public int currentAmount;

    public bool IsReached()
    {
        return (currentAmount >= requiredAmount);
    }

    public void EnemyKilled()
    {
       // if (questGoal.isActivelyPersued == true)
        //{
        
        //if (goalType == GoalType.Kill)
        //{
          //  currentAmount++;
        //}

        //}
    }

    public void GatheredItem()
    {
       // if (questGoal.isActivelyPersued == true)
       // {


            //if (goalType == GoalType.Gathering)
            //{
           //     currentAmount++;
         //   }
       // }
    }

    public void FoundLocation()
    {
       // if (questGoal.isActivelyPersued == true)
        //{


          //  if (goalType == GoalType.Find)
            //{
              //  currentAmount++;
            //}
        //}
    }

}

public enum GoalType { Kill, Gathering, Find}
