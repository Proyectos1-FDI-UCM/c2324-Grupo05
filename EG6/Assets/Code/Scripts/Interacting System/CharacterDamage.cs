using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDamage : MonoBehaviour
{
    [SerializeField] private int _damage = 4;

    public int Damage => _damage;

    public void SetDamage(int collectedTrash)
    {
        if (collectedTrash >= 20)
        {
            _damage = 12;
        }
        else if (collectedTrash >= 10)
        {
            _damage = 6;
        }
        else
        {
            _damage = 4;
        }
    }
}
