using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;

public class main_script : MonoBehaviour
{
    public hero_character hero_character;
    public enemy_character enemy_character;
    System.Random random = new System.Random();
    int damage = 0;
    bool enemy_turn = false;
    int enemy_attack_type;
    int enemy_possible_attack_type;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
 
        if (Input.anyKeyDown)
        {
            damage = 0;
            if (Input.GetKeyDown(KeyCode.R))
            {
                hero_character.ChangeHealth(100);
                hero_character.ChangeMana(100);
                enemy_character.ChangeHealth(100);
                enemy_character.ChangeMana(100);
            }

            if (Input.GetKeyDown(KeyCode.Z) && hero_character.currentMana >= 10)
            {
                hero_character.ChangeMana(-10);
                damage = random.Next(10);
                enemy_turn = true;
            }
            if (Input.GetKeyDown(KeyCode.X) && hero_character.currentMana >= 20)
            {
                hero_character.ChangeMana(-20);
                damage = random.Next(20);
                enemy_turn = true;
            }
            if (Input.GetKeyDown(KeyCode.C) && hero_character.currentMana >= 30)
            {
                hero_character.ChangeMana(-30);
                damage = random.Next(30);
                enemy_turn = true;
            }
            if (Input.GetKeyDown(KeyCode.V) && hero_character.currentMana < 100)
            {
                hero_character.ChangeMana(50);
                enemy_turn = true;
            }

            if (enemy_turn)
            {
                enemy_character.ChangeHealth(-damage);

                

                if (enemy_character.currentMana < 10)
                {
                    enemy_character.ChangeMana(50);
                    enemy_turn = false;
                }
                else
                {
                    enemy_possible_attack_type = Min(enemy_character.currentMana/10, 3);
                    
                    enemy_attack_type = random.Next(1, enemy_possible_attack_type);
                    enemy_character.ChangeMana(-enemy_attack_type*10);
                    
                    damage = random.Next(enemy_attack_type*2, enemy_attack_type*10);
                    hero_character.ChangeHealth(-damage);
                    Debug.Log(damage);
                
                    enemy_turn = false;
                }
            }
        }     

    }
}