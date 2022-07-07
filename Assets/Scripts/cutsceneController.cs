using UnityEngine;
using Cinemachine;
[RequireComponent(typeof(InteractionWithMovement))]
[RequireComponent(typeof(BoxCollider2D))]
public class cutsceneController : MonoBehaviour
{
    private Animator _animator;
    private InteractionWithMovement _movement;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        _movement = GetComponent<InteractionWithMovement>();
        _animator = GetComponent<Animator>();
        if (collision.CompareTag("mainPlayer"))
            _animator.SetTrigger("Play");
    }

    private void StartCutscene()
    {
        _movement.DisableMovement();
        gameObject.GetComponent<CinemachineVirtualCamera>().Priority = 11;
    }

    private void OverCutscene()
    {
        _movement.EnableMovement();
        gameObject.GetComponent<CinemachineVirtualCamera>().Priority = 1;
        DestroyCamera();
    }

    private void DestroyCamera()
    {
        Destroy(gameObject);
    }
}
