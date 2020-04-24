using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int eMaxHealth = 100;
    public int eCurrentHealth { get; private set; }
    public Stats eDamage;
    public Stats eArmour;
    public Stats eMagic;
    public Stats eFire;
    public Stats eIce;
    public Stats eWind;
    public Stats eShock;
    public Stats eAmethyst;
    public Stats eBleeding;
    public Stats eHealed;
    public Stats ePush;
    public Stats eExplosions;
    public Stats eFireResistance;
    public Stats eIceResistance;
    public Stats eWindResistance;
    public Stats eShockResistance;
    public Stats eAmethystResistance;
    public Stats eBleedingResistance;
    public Stats eNegateHealed;
    public Stats ePushResistance;
    public Stats eExplosionsResistance;
}
