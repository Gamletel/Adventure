using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealler : MonoBehaviour
{
    [SerializeField] private float _dmg;

    private void Start()
    {
        StartCoroutine("DelayBeforeDestroy");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Damageable") || collision.CompareTag("mainPlayer"))
        {
            collision.gameObject.GetComponent<Health>().TakeDmg(_dmg);
            Destroy(gameObject);
        }
    }

    public IEnumerator DelayBeforeDestroy()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
    
}
