using UnityEngine;

public class StatueController : MonoBehaviour
{
    [SerializeField] private GameObject _img;
    private PlayerMovement _playerMovement;
    private Animator _animator;

    private void Awake()
    {
        _playerMovement = GameObject.FindGameObjectWithTag("mainPlayer").GetComponent<PlayerMovement>();
        _animator = GetComponent<Animator>();
        _img.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("mainPlayer"))
        {
            _img.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
                Upgrade(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("mainPlayer"))
            _img.SetActive(false);
    }

    private void Upgrade(GameObject player)
    {
        _playerMovement.maxJump++;
        _animator.SetTrigger("Activated");
        player.GetComponent<Animator>().SetTrigger("Interaction");
        Destroy(_img);
        Destroy(GetComponent<StatueController>());
    }
}
