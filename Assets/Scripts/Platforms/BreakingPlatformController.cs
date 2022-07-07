using System.Collections;
using UnityEngine;

public class BreakingPlatformController : MonoBehaviour
{
    [SerializeField] private GameObject[] partsOfPlatform;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            GetComponent<Animator>().SetTrigger("shake");
        }
    }

    public void BreakPlatform()
    {
        Destroy(GetComponent<Animator>());
        for (int i = 0; i <= partsOfPlatform.Length-1; i++)
        {
            Destroy(partsOfPlatform[i].GetComponent<PolygonCollider2D>());
            partsOfPlatform[i].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            Destroy(GetComponent<BreakingPlatformController>());
            StartCoroutine("DelayBeforeDestroy");
        }
    }

    private IEnumerator DelayBeforeDestroy()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

}
