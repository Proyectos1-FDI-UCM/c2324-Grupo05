using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

/// <summary>
/// This class is used to define the objects that can be destroyed by the penguin
/// </summary>
public class DestroyableByPenguin : DestroyableObject
{
    private CharacterSwitcher _characterSwitcher;

    protected override void Start()
    {
        base.Start();
        _characterSwitcher = FindObjectOfType<CharacterSwitcher>();
    }

    public override void PerformInteraction(CharacterInteraction characterInteraction)
    {
        if (_characterSwitcher._isControllingChild == false)
        {
            base.PerformInteraction(characterInteraction);
        }
        else
        {
            Debug.Log("Only the penguin can destroy this object");
        }
    }
}
