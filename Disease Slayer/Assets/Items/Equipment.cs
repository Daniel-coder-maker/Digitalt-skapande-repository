using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Equipment", menuName ="Inventory/Equipment")]
public class Equipment : Item
{
    public Equipmentslot equipslot;

    public int armourModifier;
    public int damageModifier;
    public int fireModifier;
    public int iceModifier;
    public int windModifier;
    public int shockModifier;
    public int amethystModifier;
    public int bleedingModifier;
    public int fireResistanceModifier;
    public int iceResistanceModifier;
    public int windResistanceModifier;
    public int shockResistanceModifier;
    public int amethystResistanceModifier;
    public int bleedingResistanceModifier;
    public int healedModifier;
    public int extraExperienceModifier;
    public int moneyModifier;
    public int pushModifier;
    public int explosionsModifier;
    public int negateHealedModifier;
    public int pushResistanceModifier;
    public int explosionsResistanceModifier;

    public override void Use()
    {
        base.Use();
        Equippingthings.instance.Equip(this);
        RemovefromInventory();
    }
}

public enum Equipmentslot { Head, Torso, LowerBody, Weapon, Usable}