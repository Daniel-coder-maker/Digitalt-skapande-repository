using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : Characterstats
{
    public int myMoney;
    public int myExperience;

    public Quest quest;
    // Start is called before the first frame update
    void Start()
    {
        Equippingthings.instance.onEquipmentChanged += OnEquipmentChanged;
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
        }
    }

    public void Rewarded()
    {
        myMoney = myMoney + quest.goldReward;
        myExperience = myExperience + quest.experienceReward;
    }
}
