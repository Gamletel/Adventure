using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent (typeof(Health))]
[RequireComponent(typeof(Shooter))]
public class PlayerMovement : MonoBehaviour
{
    [Header("For Jump")]
    public int maxJump = 1;
    [SerializeField] private int _curJump = 0;
    [SerializeField] private float _jumpForce;
    private const float _jumpOffset = 0.06f; 
    [SerializeField] private Transform _groundColliderTransform;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private bool _isGrounded;

    [Header("Other")]
    private Animator _animator;
    private Rigidbody2D _rb;
    private Health _health;

    [Header("UI")]
    [SerializeField] private GameObject _losePanel;

    [Header("For Movement")]
    [SerializeField] private AnimationCurve _curve;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _health = GetComponent<Health>();
    }

    private void FixedUpdate()
    {
        Vector3 overlapCirclePos = _groundColliderTransform.position;
        _isGrounded = Physics2D.OverlapCircle(overlapCirclePos, _jumpOffset, _groundMask);
        if(_health.curHp == 0)
        {
            Death();
        }
    }

    public void Attack()
    {
        _animator.SetBool("isAttacking", true);
    }

    public void EndAttackingAnim()
    {
        _animator.SetBool("isAttacking", false);
    }

    public void Move(float direction, bool isJumpBtnPressed)
    {
        #region Jump
        if (isJumpBtnPressed && _isGrounded)
            Jump();
        if (!_isGrounded)
        {
            _animator.SetBool("isFalling", true);
            //NextJump
            if (_curJump < maxJump-1 && isJumpBtnPressed)
            {
                _curJump++;
                Jump();
            }
                
        } 
        else
        {
            _curJump = 0;
            _animator.SetBool("isFalling", false);
        }
        #endregion

        #region Move
        if (Mathf.Abs(direction) > 0.01f)
            HorizontalMovement(direction);
        else
            _animator.SetBool("isRunning", false);
        #endregion
    }

    private void Jump()
    {
        _animator.SetBool("Jump", true);
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
    }

    public void EndJumpAnim()
    {
        _animator.SetBool("Jump", false);
    }

    private void HorizontalMovement(float direction)
    {
        _animator.SetBool("isRunning", true);
        _rb.velocity = new Vector2(_curve.Evaluate(direction), _rb.velocity.y);
        if (Input.GetAxis(GlobalStringVars.HORIZONTAL_AXIS) > 0.01f)
            transform.localScale = new Vector2(1, 1);
        if (Input.GetAxis(GlobalStringVars.HORIZONTAL_AXIS) < 0.01f)
            transform.localScale = new Vector2(-1, 1);
    }

    private void Death()
    {
        _animator.SetTrigger("Death");
        Destroy(GetComponent<PlayerMovement>());
        Destroy(GetComponent<PlayerInput>());
        _losePanel.SetActive(true);
    }
}
