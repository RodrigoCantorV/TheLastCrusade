using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShortDistance : Enemy
{

    // SOUND
    public AudioSource audioSource;
    public AudioClip deadSound;
    public AudioClip walkSound;
    public AudioClip attackSound;
    public AudioClip hurtSound;

    protected override void AttackEnemy()
    {
        if (timePassed >= attackTime)
        {
            // Si la sitancia entre el enemigo y el player es menor al rango de ataque entonces que ataque
            if (Vector3.Distance(player.transform.position, transform.position) <= attackRange)
            {
                animator.SetTrigger("attack");
                timePassed = 0;
            }
        }
        timePassed += Time.deltaTime;
    }


    private void soundDead()
    {
        audioSource.clip = deadSound;
        audioSource.Play();
    }

    private void soundWalk()
    {
        audioSource.clip = walkSound;
        audioSource.Play();
    }

    private void soundAttack()
    {
        audioSource.clip = attackSound;
        audioSource.Play();
    }

    private void soundHurt()
    {
        audioSource.clip = hurtSound;
        audioSource.Play();
    }
}
