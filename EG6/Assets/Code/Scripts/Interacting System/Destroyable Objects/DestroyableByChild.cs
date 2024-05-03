using UnityEngine;

/// <summary>
/// This class is used to define the objects that can be destroyed by the child
/// </summary>
public class DestroyableByChild : DestroyableObject
{
    private CharacterSwitcher _characterSwitcher;
    private AudioManager _audioManager;
    
    protected override void Start()
    {
        base.Start();
        _characterSwitcher = FindObjectOfType<CharacterSwitcher>();
        _audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public override void PerformInteraction(CharacterInteraction characterInteraction)
    {
        if (_characterSwitcher.isControllingChild)
        {
            base.PerformInteraction(characterInteraction);
        }
        else
        {
            _audioManager.PlaySFX(_audioManager._knockWood);
            /*
            AudioClip onKnockSound = Resources.Load<AudioClip>("Audio/Destroyable/knockWood");
            AudioSource.PlayClipAtPoint(onKnockSound,transform.position);
            */
            Shake();
        }
    }
}