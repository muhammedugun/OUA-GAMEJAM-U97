using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyAttack : MonoBehaviour
{
    public bool turn = false;
    public HeroAttack heroAttack;
    public enemy_character enemy_character;
    public hero_character hero_character;
    public Animator heroAnimator;
    public float time;
    public float impactTime;
    public bool isImpact;


    private void Start()
    {
        turn = false;
        time = Time.time;
        impactTime = Time.time;

    }
    private void Update()
    {
        RandomAttack();
        Impact();
    }
    public void AttackJump()
    {
        if (turn && time+3f<=Time.time && enemy_character.currentMana > 0)
        {
            enemy_character.ChangeMana(-80);
            StartCoroutine(hero_character.ChangeHealth(-40)); 
            turn = false;
            heroAttack.time = Time.time;
            heroAttack.impactTime = Time.time;
            heroAttack.isImpact = true;
            heroAttack.turn = true;
            heroAnimator.SetTrigger("isAttackJump");
        }

    }
    public void Attack()
    {
        if (turn && time + 3f <= Time.time && enemy_character.currentMana > 0)
        {
            enemy_character.ChangeMana(-40);
            StartCoroutine(hero_character.ChangeHealth(-20));
            turn = false;
            heroAttack.time = Time.time;
            heroAttack.impactTime = Time.time;
            heroAttack.isImpact = true;
            heroAttack.turn = true;
            Run();
            heroAnimator.SetTrigger("isAttack");
        }

    }
    public void Kick()
    {
        if (turn && time + 3f <= Time.time && enemy_character.currentMana > 0)
        {
            enemy_character.ChangeMana(-10);
            StartCoroutine(hero_character.ChangeHealth(-10));
            turn = false;
            heroAttack.time = Time.time;
            heroAttack.impactTime = Time.time;
            heroAttack.isImpact = true;
            heroAttack.turn = true;
            Run();
            heroAnimator.SetTrigger("isKick");
        }

    }

    

    private void Run()
    {
        heroAnimator.SetTrigger("isRun");
    }


    void RandomAttack()
    {
        
        if(turn)
        {
            if(enemy_character.currentMana==0)
            {
                Mana();
            }
            else
            {
                int randomNum = Random.Range(1, 4);
                if (randomNum == 1)
                {
                    AttackJump();
                }
                else if (randomNum == 2)
                {
                    Attack();
                }
                else if (randomNum == 3)
                {
                    Kick();
                }
            }
            

        }
        
    }

    public void Mana()
    {
        enemy_character.ChangeMana(50);
        turn = false;
        heroAttack.time = Time.time;
        heroAttack.turn = true;
    }
    public void Impact()
    {

        if (impactTime + 1.2f <= Time.time && isImpact)
        {
            if(enemy_character.currentHealth==0)
            {
                heroAnimator.SetTrigger("isDeathBody");
                StartCoroutine(VictoryMenu());
            }
            else
            {
                heroAnimator.SetTrigger("isImpactLow");
                

            }
            gameObject.transform.position = new Vector3(0, 0, 2.9f);
            isImpact = false;
        }

    }

  

    private IEnumerator VictoryMenu()
    {
        
            yield return new WaitForSeconds(3f);
            SceneManager.LoadScene("VictoryMenu 1");

       
    }
}
