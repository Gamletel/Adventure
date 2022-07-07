using UnityEngine;

public class BeardedmanController : MonoBehaviour
{
    [SerializeField] private GameObject buyMojitoCanvas;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("mainPlayer"))
            buyMojitoCanvas.SetActive(true);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("mainPlayer") && Input.GetKeyDown(KeyCode.Q))
            BuyMojito(collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("mainPlayer"))
        {
            buyMojitoCanvas.SetActive(false);
        }
    }

    private void BuyMojito(GameObject player)
    {
        if (player.GetComponent<Health>().curHp == player.GetComponent<Health>().maxHp)
            return;
        else
        {
            MoneyController.Money.curMoney -= 5;
            player.GetComponent<Health>().curHp++;
        }
        
    }
}
