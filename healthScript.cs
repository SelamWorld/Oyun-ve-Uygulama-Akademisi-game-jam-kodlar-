using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthScript : MonoBehaviour
{
    public Image healthBar;
    public float HealtAmount=100f;


    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            Damage(20);
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Heal(5);
        }
    }
    public void Damage(float damage)
    {
        HealtAmount -= damage;
        healthBar.fillAmount = HealtAmount / 100f;
    }

    public void Heal(float healingAmount)
    {
        HealtAmount += healingAmount;
        HealtAmount = Mathf.Clamp(HealtAmount,0,100);

        healthBar.fillAmount += HealtAmount/100;
    }
}
