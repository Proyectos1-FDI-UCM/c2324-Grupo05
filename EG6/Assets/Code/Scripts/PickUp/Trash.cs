using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class of pickable trash
/// </summary>
public class Trash : PickableObject
{
    [SerializeField] private TrashCounter _counter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ChildMovement>() != null)
        {
            PickUp();
        }
    }

    public override void PickUp()
    {
        base.PickUp();
        GlobalObjectRegistry.instance.collectedTrash++;
        _counter.IncrementCount();

        CharacterDamage[] characterDamages = FindObjectsOfType<CharacterDamage>();
        foreach (CharacterDamage characterDamage in characterDamages)
        {
            characterDamage.SetDamage(GlobalObjectRegistry.instance.collectedTrash);
        }
    }
}
