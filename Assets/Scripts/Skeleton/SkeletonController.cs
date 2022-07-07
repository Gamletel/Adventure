using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class SkeletonController : MonoBehaviour
{
    private Animator _animator;
    private GameObject _player;
    private Health _health;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _health = GetComponent<Health>();
    }

    public void DoReact(int x)
    {
        x = Random.Range(0, 11);
        if (x == 0)
            _animator.SetBool("React", true);
        else
            _animator.SetBool("React", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("mainPlayer"))
        {
            _player = collision.gameObject;
            
            StartCoroutine("Attacking");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("mainPlayer"))
        {
            StopCoroutine("Attacking");
            _animator.SetBool("Attack", false);
        }
    }
    private IEnumerator Attacking()
    {
        while (true)
        {
            _animator.SetBool("Attack", true);
            _player.GetComponent<Health>().curHp--;
            _health.curHp--;
            if (_health.curHp == 0)
            {
                _animator.SetBool("Attack", false);
                _animator.SetTrigger("Death");
                Destroy(GetComponent<BoxCollider2D>());
            }  
            yield return new WaitForSeconds(2f);
        }
    }
}
