using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class EnemyController : MonoBehaviour
{
    [SerializeField] private float speed, timeToRevert;
    private const float idle_state = 0;
    private const float walk_state = 1;
    private const float revert_state = 2;
    private float prevSpeed;
    private float curState, curTimeToRevert;
    private Animator animator;
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private GameObject player;
    private Health health;

    private void Awake()
    {
        prevSpeed = speed;
        health = GetComponent<Health>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        curState = walk_state;
        curTimeToRevert = 0;
    }

    private void Update()
    {
        if (health.curHp == 0)
            Death();

        if(curTimeToRevert >= timeToRevert)
        {
            curTimeToRevert = 0;
            curState = revert_state;
        }
        switch (curState)
        {
            case idle_state:
                curTimeToRevert += Time.deltaTime;
                break;
            case walk_state:
                rb.velocity = Vector2.right * speed;
                break;
            case revert_state:
                sr.flipX = !sr.flipX;
                speed *= -1;
                curState = walk_state;
                break;
        }
        animator.SetFloat("Velocity", rb.velocity.magnitude);
    }

    public void DoReact(int x)
    {
        x = Random.Range(0, 11);
        if (x == 0)
            animator.SetBool("React", true);
        else
            animator.SetBool("React", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemyStopper"))
            curState = idle_state;
        if (collision.CompareTag("mainPlayer"))
        {
            player = collision.gameObject;
            StartCoroutine("Attacking");
            speed = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("mainPlayer"))
        {
            speed = prevSpeed;
            StopCoroutine("Attacking");
            animator.SetBool("Attack", false);
        }
    }

    private IEnumerator Attacking()
    {
        while (true)
        {
            animator.SetBool("Attack", true);
            player.GetComponent<Health>().curHp--;
            health.curHp--;
            if (health.curHp == 0)
            {
                animator.SetBool("Attack", false);
                animator.SetTrigger("Death");
                Destroy(GetComponent<BoxCollider2D>());
            }
            yield return new WaitForSeconds(2f);
        }
    }

    private void Death()
    {
        Destroy(rb);
        Destroy(GetComponentInChildren<CapsuleCollider2D>());
        Destroy(GetComponent<EnemyController>());
    }
}
