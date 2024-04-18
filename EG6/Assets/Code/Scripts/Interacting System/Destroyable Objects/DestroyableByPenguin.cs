using UnityEngine;

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
        if (_characterSwitcher.isControllingChild == false)
        {
            base.PerformInteraction(characterInteraction);
        }
        else
        {
            AudioClip onKnockSound = Resources.Load<AudioClip>("Audio/Destroyable/knockIce");
            AudioSource.PlayClipAtPoint(onKnockSound,transform.position);
            Shake();
        }
    }
}
