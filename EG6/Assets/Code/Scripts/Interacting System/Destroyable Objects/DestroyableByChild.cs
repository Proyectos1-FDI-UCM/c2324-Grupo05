using UnityEngine;

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

    public override void PerformInteraction(CharacterInteraction characterInteraction)
    {
        if (_characterSwitcher.isControllingChild)
        {
            base.PerformInteraction(characterInteraction);
        }
        else
        {
            AudioClip onKnockSound = Resources.Load<AudioClip>("Audio/Destroyable/knockWood");
            AudioSource.PlayClipAtPoint(onKnockSound,transform.position);
            Shake();
        }
    }
}