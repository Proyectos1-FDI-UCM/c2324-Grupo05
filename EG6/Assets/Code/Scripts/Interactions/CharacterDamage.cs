using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDamage : MonoBehaviour
{
    [SerializeField] private int _damage = 1;

    public int Damage => _damage;

    public void SetDamage(int damage)
    {
        _damage = damage;
    }
}
