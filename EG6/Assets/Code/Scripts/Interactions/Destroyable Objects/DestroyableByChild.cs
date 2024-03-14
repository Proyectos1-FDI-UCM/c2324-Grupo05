using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

/// <summary>
/// This class is used to define the objects that can be destroyed by the child
/// </summary>
public class DestroyableByChild : DestroyableObject
{
    private CharacterSwitcher _characterSwitcher;
    
    protected override void Start()
    {
        base.Start();
        _characterSwitcher = FindObjectOfType<CharacterSwitcher>();
    }

    public override void Destroy()
    {
        if (_characterSwitcher._isControllingChild)
        {
            base.Destroy();
        }
        else
        {
            Debug.Log("Only the child can destroy this object");
        }
    }
}