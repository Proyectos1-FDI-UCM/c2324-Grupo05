using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Interface for the interactable objects
public interface IInteractable
{
    SpriteRenderer SpriteRenderer { get; }

    void PerformInteraction(CharacterInteraction characterInteraction);
}
