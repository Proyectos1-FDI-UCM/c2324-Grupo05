using UnityEngine;

/// <summary>
/// This class is used to define the objects that can be destroyed by the penguin
/// </summary>
public class DestroyableByPenguin : DestroyableObject
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
        if (_characterSwitcher.isControllingChild == false)
        {
            base.PerformInteraction(characterInteraction);
        }
        else
        {
            _audioManager.PlaySFX(_audioManager._knockIce);
            /*
            AudioClip onKnockSound = Resources.Load<AudioClip>("Audio/Destroyable/knockIce");
            AudioSource.PlayClipAtPoint(onKnockSound,transform.position);
            */
            Shake();
        }
    }
}
