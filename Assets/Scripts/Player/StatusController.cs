using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusController : MonoBehaviour
{
    [SerializeField]
    private int hp;
    private int currentHP;

    [SerializeField]
    private int mp;
    private int currentMP;

    [SerializeField]
    private int IncreasedSpeed;

    [SerializeField]
    private int RechargeTime;
    private int currentRechargeTime;

    [SerializeField]
    private int DecreaseTime;
    private int currentDecreaseTime;

    private bool spUsed;

    [SerializeField]
    private Image[] images_Gauge;

    private const int HP = 0, MP = 1;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = hp;
        currentMP = mp;
    }

    // Update is called once per frame
    void Update()
    {
        GaugeUpdate();
        HPRechargeTIme();
        HPRecover();
    }

    private void HPRechargeTIme()
    {
        if (spUsed)
        {
            if (currentRechargeTime < RechargeTime)
                currentRechargeTime++;
            else
                spUsed = false;
        }
    }

    private void HPRecover()
    {
        if (!spUsed && currentHP < hp)
            currentHP += IncreasedSpeed;
    }

    public void DecreaseHP(int _count)
    {
        spUsed = true;
        currentRechargeTime = 0;

        if (currentHP - _count > 0)
        {
            currentHP -= _count;
        }

        else
            currentHP = 0;
    }

    private void GaugeUpdate()
    {
        images_Gauge[HP].fillAmount = (float)currentHP / hp;
        images_Gauge[MP].fillAmount = (float)currentMP / mp;
    }
}
