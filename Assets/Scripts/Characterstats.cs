using UnityEngine;

public class Characterstats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth { get; private set; }
    public Stats damage;
    public Stats armour;
    public Stats magic;
    public Stats fire;
    public Stats ice;
    public Stats wind;
    public Stats shock;
    public Stats amethyst;
    public Stats bleeding;
    public Stats healed;
    public Stats push;
    public Stats explosions;
    public Stats fireResistance;
    public Stats iceResistance;
    public Stats windResistance;
    public Stats shockResistance;
    public Stats amethystResistance;
    public Stats bleedingResistance;
    public Stats negateHealed;
    public Stats pushResistance;
    public Stats explosionsResistance;
    public Stats extraExperience;
    public Stats extraMoney;
    void Awake()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
       if(Input.GetKeyDown(KeyCode.F))
       {
            TakeDamage(10);
       }
        if (Input.GetKeyDown(KeyCode.H))
        {
            Healing();
        }
    }

    public void TakeDamage(int damage)
    {

        damage -= armour.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);
        currentHealth -= damage;
        Debug.Log(transform.name + "takes" + damage + "damage.");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Healing()
    {
        currentHealth+= healed.GetValue();

        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public virtual void Die()
    {
        //Dying. Overwritten for different characters.
        Debug.Log(transform.name + "died.");
    }
}
