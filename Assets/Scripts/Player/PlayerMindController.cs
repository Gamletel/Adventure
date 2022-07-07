using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMindController : MonoBehaviour
{
    private float _timeToClose = 3f, _curTime = 0f;
    [SerializeField] private Text _mindText;

    private void Start()
    {
        _mindText.gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (_mindText.gameObject.activeSelf == true)
        {
            _mindText.gameObject.transform.position = new Vector2(transform.position.x, transform.position.y + 0.3f);
                _curTime += Time.deltaTime;
        }
        if (_curTime >= _timeToClose)
        {
            _mindText.gameObject.SetActive(false);
            _curTime = 0;
        }  
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("mind"))
        {
            _mindText.gameObject.SetActive(true);
            _mindText.text = collision.GetComponent<Text>().text;
            Destroy(collision.gameObject);
        }
    }
}
