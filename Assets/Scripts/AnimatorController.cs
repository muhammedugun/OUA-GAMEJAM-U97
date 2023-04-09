using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            animator.SetTrigger("isRun");
            animator.SetTrigger("isAttack");
            animator.SetTrigger("isWalk");
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            animator.SetTrigger("isRun");
            animator.SetTrigger("isAttackJump");
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            animator.SetTrigger("isRun");
            animator.SetTrigger("isKick");
        }
    }
}