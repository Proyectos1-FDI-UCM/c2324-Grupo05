using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardenIce : DestroyableByPenguin
{
    public override void PerformInteraction(CharacterInteraction characterInteraction)
    {
        if (GlobalObjectRegistry.instance.collectedPieces >= 3)
        {
            base.PerformInteraction(characterInteraction);
        }
        else
        {
            AudioClip onKnockSound = Resources.Load<AudioClip>("Audio/Destroyable/knockIce");
            AudioSource.PlayClipAtPoint(onKnockSound, transform.position);
            Shake();
        }
    }
}
