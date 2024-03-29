using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExPlayer : MonoBehaviour
{
    private int health = 100;   //플레이어 체력

    public void TakeDamge(int damge)
    {
        //플레이어 체력 감소
        health -= damge;
        Debug.Log("플레이어가 체력 : " + health);
        //플레이어 체력이 0이하로 떨어졌을 때 플레이어 사망 처리
        if (health <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        Debug.Log("플레이어가 사망했습니다.");
    }
}
