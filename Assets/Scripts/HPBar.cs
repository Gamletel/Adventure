using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] private float _curHP;
    [SerializeField] private float _maxHP;
    [SerializeField] private Health health;
    private Image HPBarImg;

    void Start()
    {
        HPBarImg = GetComponent<Image>();
    }

    void Update()
    {
        _maxHP = health.maxHp;
        _curHP = health.curHp;
        HPBarImg.fillAmount = _curHP/_maxHP;
    }
}
