using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayerSpeed : MonoBehaviour
{
    [SerializeField] private float drag;
    [SerializeField] private float gravity;
    private float _curDrag, _curGravity;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("mainPlayer"))
        {
            _curDrag = collision.gameObject.GetComponent<Rigidbody2D>().drag;
            _curGravity = collision.gameObject.GetComponent<Rigidbody2D>().gravityScale;
            collision.gameObject.GetComponent<Rigidbody2D>().drag = drag;
            collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = gravity;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("mainPlayer"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().drag = _curDrag;
            collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = _curGravity;
        }
    }
}
