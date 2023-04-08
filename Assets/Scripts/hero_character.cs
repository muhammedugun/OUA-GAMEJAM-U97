using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;

public class hero_character : MonoBehaviour
{
    public hero_health_bar healthBar;
    public int maxHealth = 100;
    public int minHealth = 0;
    public int currentHealth;

    public hero_mana_bar manaBar;
    public int maxMana = 100;
    public int minMana = 0;
    public int currentMana;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        currentMana = maxMana;
        manaBar.SetMaxMana(maxMana);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeHealth(int health)
    {
        currentHealth += health;
        currentHealth = Max(minHealth, currentHealth);
        currentHealth = Min(maxHealth, currentHealth);

        healthBar.SetHealth(currentHealth);
    }
    
    public void ChangeMana(int mana)
    {
        currentMana += mana;
        currentMana = Max(minMana, currentMana);
        currentMana = Min(maxMana, currentMana);

        manaBar.SetMana(currentMana);
    }    
}
