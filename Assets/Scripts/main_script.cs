using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;

public class main_script : MonoBehaviour
{
    public UnityEngine.UI.Button myButton_1;
    public UnityEngine.UI.Button myButton_2;
    public UnityEngine.UI.Button myButton_3;
    public UnityEngine.UI.Button myButton_4;

    public hero_character hero_character;
    public enemy_character enemy_character;

    System.Random random = new System.Random();
    int damage = 0;
    bool enemy_turn = false;
    int enemy_attack_type;
    int enemy_possible_attack_type;
    
    float updateInterval = 2;
    float elapsedTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        myButton_4.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            hero_character.ChangeHealth(100);
            hero_character.ChangeMana(100);
            enemy_character.ChangeHealth(100);
            enemy_character.ChangeMana(100);
        }
        
        if (enemy_turn)
        {
            
            
            
            elapsedTime += Time.deltaTime;

            if (elapsedTime >= updateInterval)
            {
                EnemyFunction(); // call the update function
                elapsedTime = 0; // reset elapsed time
            }

           
        }        

        if (hero_character.currentHealth == 0)
        {
            Debug.Log("enemy_wins");
        }
        else if (enemy_character.currentHealth == 0)
        {
            Debug.Log("hero_wins");
        }
    }

    public void MyButtonClick_1()
    {
        hero_character.ChangeMana(-10);
        damage = random.Next(10);
        enemy_turn = true;

        enemy_character.ChangeHealth(-damage);
        damage = 0;
        myButton_1.interactable = false;
        myButton_2.interactable = false;
        myButton_3.interactable = false;
        myButton_4.interactable = false;
    }  

    public void MyButtonClick_2()
    {
        hero_character.ChangeMana(-20);
        damage = random.Next(20);
        enemy_turn = true;

        enemy_character.ChangeHealth(-damage);
        damage = 0;
        myButton_1.interactable = false;
        myButton_2.interactable = false;
        myButton_3.interactable = false;
        myButton_4.interactable = false;
    }  

    public void MyButtonClick_3()
    {
        hero_character.ChangeMana(-30);
        damage = random.Next(30);
        enemy_turn = true;

        enemy_character.ChangeHealth(-damage);
        damage = 0;
        myButton_1.interactable = false;
        myButton_2.interactable = false;
        myButton_3.interactable = false;
        myButton_4.interactable = false;
    }

    public void MyButtonClick_4()
    {
        hero_character.ChangeMana(50);
        enemy_turn = true;
        myButton_1.interactable = false;
        myButton_2.interactable = false;
        myButton_3.interactable = false;
        myButton_4.interactable = false;
    }

    public void EnemyFunction()
    {
        if (enemy_character.currentMana >= 10)
        {
            enemy_possible_attack_type = Min(enemy_character.currentMana/10, 3);
                    
            enemy_attack_type = random.Next(1, enemy_possible_attack_type);
            enemy_character.ChangeMana(-enemy_attack_type*10);
                    
            damage = random.Next(enemy_attack_type*2, enemy_attack_type*10);
            hero_character.ChangeHealth(-damage);
            damage = 0;
            Debug.Log(damage);
                
            enemy_turn = false;
        }
        else
        {
            enemy_character.ChangeMana(50);
            enemy_turn = false;
        }

        if (hero_character.currentMana >= 10){myButton_1.interactable = true;}
        if (hero_character.currentMana >= 20){myButton_2.interactable = true;}
        if (hero_character.currentMana >= 30){myButton_3.interactable = true;}
        if (hero_character.currentMana < 100){myButton_4.interactable = true;}

    }
    

}