using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : Characterstats
{
    public int myMoney;
    public int myExperience;
    public int mana=100;
    public int currentMana { get; private set; }
    private List<int> everyQuest=new List<int>();
    public Quest quest;
    // Start is called before the first frame update
    void Start()
    {
        Equippingthings.instance.onEquipmentChanged += OnEquipmentChanged;
    }

     void Awake()
    {
        currentMana = mana;   
    }

    void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
    {
        if (newItem != null)
        { 
         armour.AddModifier(newItem.armourModifier);
         damage.AddModifier(newItem.damageModifier);
            fire.AddModifier(newItem.fireModifier);
            ice.AddModifier(newItem.iceModifier);
            wind.AddModifier(newItem.windModifier);
            shock.AddModifier(newItem.shockModifier);
            amethyst.AddModifier(newItem.amethystModifier);
            bleeding.AddModifier(newItem.bleedingModifier);
            healed.AddModifier(newItem.healedModifier);
            push.AddModifier(newItem.pushModifier);
            explosions.AddModifier(newItem.explosionsModifier);
            fireResistance.AddModifier(newItem.fireResistanceModifier);
            iceResistance.AddModifier(newItem.iceResistanceModifier);
            windResistance.AddModifier(newItem.windResistanceModifier);
            shockResistance.AddModifier(newItem.shockResistanceModifier);
            amethystResistance.AddModifier(newItem.amethystResistanceModifier);
            bleedingResistance.AddModifier(newItem.bleedingResistanceModifier);
            negateHealed.AddModifier(newItem.negateHealedModifier);
            pushResistance.AddModifier(newItem.pushResistanceModifier);
            explosionsResistance.AddModifier(newItem.explosionsResistanceModifier);
            extraExperience.AddModifier(newItem.extraExperienceModifier);
            extraMoney.AddModifier(newItem.moneyModifier);
        }

        if (oldItem != null)
        {
            armour.RemoveModifier(oldItem.armourModifier);
            damage.RemoveModifier(oldItem.damageModifier);
            fire.RemoveModifier(oldItem.fireModifier);
            ice.RemoveModifier(oldItem.iceModifier);
            wind.RemoveModifier(oldItem.windModifier);
            shock.RemoveModifier(oldItem.shockModifier);
            amethyst.RemoveModifier(oldItem.amethystModifier);
            bleeding.RemoveModifier(oldItem.bleedingModifier);
            healed.RemoveModifier(oldItem.healedModifier);
            push.RemoveModifier(oldItem.pushModifier);
            explosions.RemoveModifier(oldItem.explosionsModifier);
            fireResistance.RemoveModifier(oldItem.fireResistanceModifier);
            iceResistance.RemoveModifier(oldItem.iceResistanceModifier);
            windResistance.RemoveModifier(oldItem.windResistanceModifier);
            shockResistance.RemoveModifier(oldItem.shockResistanceModifier);
            amethystResistance.RemoveModifier(oldItem.amethystResistanceModifier);
            bleedingResistance.RemoveModifier(oldItem.bleedingResistanceModifier);
            negateHealed.RemoveModifier(oldItem.negateHealedModifier);
            pushResistance.RemoveModifier(oldItem.pushResistanceModifier);
            explosionsResistance.RemoveModifier(oldItem.explosionsResistanceModifier);
            extraExperience.RemoveModifier(oldItem.extraExperienceModifier);
            extraMoney.RemoveModifier(oldItem.moneyModifier);
        }
    }

    public void Rewarded()
    {
        if (quest.isActive)
        {
            if (quest.isActivelyPersued)
            {
                if (quest.goal.IsReached())
                {
                    myMoney += quest.goldReward;
                    myExperience += quest.experienceReward;
                    quest.Complete();
                }
            }
        }
    }
}
