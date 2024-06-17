using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    int _hp = 5;
    public int health = 5;
         public int hp
    {
        get => _hp;
        set => _hp = Mathf.Clamp(value, 0, maxHP);
    }
    public int maxHP = 5;

    void OnCollisionEnter()
    {
        if (hp > 0)
            hp--;
        else
           Destroy(this.gameObject);
    }    
}
