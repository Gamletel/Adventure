using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    public int moneyForChest;
    private bool isOpened = false;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("mainPlayer") && Input.GetKeyDown(KeyCode.E) && !isOpened)
            CollectChest(collision.gameObject);   
    }

    private void CollectChest(GameObject player)
    {
        MoneyController.Money.curMoney += moneyForChest;
        player.GetComponent<Animator>().SetTrigger("Interaction");
        animator.SetTrigger("Open");
        isOpened = true;
    }
}
