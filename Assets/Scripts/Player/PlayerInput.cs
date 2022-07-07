using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(Shooter))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private Shooter _shooter;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _shooter = GetComponent<Shooter>();
    }

    private void Update()
    {
        #region Movement
        float horizontalDirection = Input.GetAxis(GlobalStringVars.HORIZONTAL_AXIS);
        float verticalDirection = Input.GetAxis(GlobalStringVars.VERTICALL_AXIS);
        bool isJumpBtnPressed = Input.GetButtonDown(GlobalStringVars.JUMP);
        _playerMovement.Move(horizontalDirection, isJumpBtnPressed);
        #endregion

        #region ThrowGrenade
        if (Input.GetKeyDown(KeyCode.G))
        {
            _shooter.Shoot(horizontalDirection);
        }
        #endregion

        #region Attacking
        if (Input.GetMouseButtonDown(0))
            _playerMovement.Attack();
        #endregion
    }
}
