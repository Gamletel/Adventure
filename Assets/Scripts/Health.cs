using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHp, curHp;
    private bool _isAlive;
    private Animator _animator;

    private void Awake()
    {
        curHp = maxHp;
        _isAlive = true;
        _animator = GetComponent<Animator>();
    }

    public void TakeDmg(float dmg)
    {
        curHp -= dmg;
        CheckIsAlive();
        if (!_isAlive)
        {
            Destroy(GetComponent<BoxCollider2D>());
            _animator.SetTrigger("Death");
            if (TryGetComponent(out Rigidbody2D rb))
            {
                Destroy(rb);
                Destroy(GetComponent<PlayerInput>());
            }
        }      
    }

    private void CheckIsAlive()
    {
        if (curHp <= 0)
            _isAlive = false;
        else
            _isAlive = true;
    }
}
