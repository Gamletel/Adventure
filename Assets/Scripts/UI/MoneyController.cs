using UnityEngine;
using UnityEngine.UI;

public class MoneyController : MonoBehaviour
{
    [SerializeField] private Text _moneyTxt;

    public static class Money
    {
        public static int curMoney = 5;
    }

    private void Update()
    {
        _moneyTxt.text = $"Money: {Money.curMoney}$";
    }
}
