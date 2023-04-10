using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class HeroAttack : MonoBehaviour
{
    public bool turn=true;
    public EnemyAttack enemyAttack;
    public hero_character hero_character;
    public enemy_character enemy_character;
    public Animator heroAnimator;
    public float impactTime;
    public bool isImpact;
    public float time;
    private void Start()
    {
        time = Time.time;
    }
    private void Update()
    {
        Impact();
    }
    public void AttackJump()
    {
        if (turn && time + 4f <= Time.time && hero_character.currentMana>0)
        {
            hero_character.ChangeMana(-50);
            enemy_character.ChangeHealth(-30);
            turn = false;
            enemyAttack.time = Time.time;
            enemyAttack.isImpact = true;
            enemyAttack.turn = true;
            heroAnimator.SetTrigger("isAttackJump");
            time = Time.time;
            enemyAttack.impactTime = Time.time;

        }
        
    }
    public void Attack()
    {
        if (turn && time + 4f <= Time.time && hero_character.currentMana > 0)
        {
            hero_character.ChangeMana(-30);
            enemy_character.ChangeHealth(-20);
            turn = false;
            enemyAttack.time = Time.time;
            enemyAttack.impactTime = Time.time;
            enemyAttack.isImpact = true;
            enemyAttack.turn = true;
            Run();
            heroAnimator.SetTrigger("isAttack");
        }
       
    }
    public void Kick()
    {
        if (turn && time + 4f <= Time.time && hero_character.currentMana > 0)
        {
            hero_character.ChangeMana(-10);
            enemy_character.ChangeHealth(-10);
            turn = false;
            enemyAttack.time = Time.time;
            enemyAttack.impactTime = Time.time;
            enemyAttack.isImpact = true;
            enemyAttack.turn = true;
            Run();
            heroAnimator.SetTrigger("isKick");
        }
        
    }
    private void Run()
    {
        heroAnimator.SetTrigger("isRun");
    }


    public void Mana()
    {
        hero_character.ChangeMana(50);
        turn = false;
        enemyAttack.time = Time.time;
        enemyAttack.turn = true;

    }

    public void Impact()
    {

        if(impactTime+ 1.2f <= Time.time && isImpact)
        {

            if (hero_character.currentHealth == 0)
            {
                heroAnimator.SetTrigger("isDeathBody");
            }
            else
            {
                heroAnimator.SetTrigger("isImpactLow");
                
                
            }
            gameObject.transform.position = new Vector3(0, 0, -2.9f);
            isImpact = false;
        }
        


    }

   

}
