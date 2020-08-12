using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimController : MonoBehaviour
{
    Animator animator;

    public void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayAttack()
    {
        Reset();
        animator.SetBool("attack", true);
    }

    public void PlayStagger()
    {
        animator.SetTrigger("stagger");
    }

    public void PlayRun()
    {
        Reset();
        animator.SetBool("run", true);
    }

    private void Reset()
    {
        animator.SetBool("run", false);
        animator.SetBool("attack", false);
    }
}