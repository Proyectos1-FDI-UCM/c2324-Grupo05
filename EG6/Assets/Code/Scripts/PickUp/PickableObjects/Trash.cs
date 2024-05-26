using UnityEngine;

/// <summary>
/// Class of pickable trash
/// Increments the trash counter when picked up
/// Updates the damage of the characters when picked up
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

        CharacterDamage[] characterDamages = FindObjectsOfType<CharacterDamage>();
        foreach (CharacterDamage characterDamage in characterDamages)
        {
            characterDamage.SetDamage(GlobalObjectRegistry.instance.collectedTrash);
        }

        if (GlobalObjectRegistry.instance.collectedTrash == 10)
        {
            FindAnyObjectByType<AchievementNotifier>().ShowNotify();
        }

        if (GlobalObjectRegistry.instance.collectedTrash == 68)
        {
            FindAnyObjectByType<AchievementNotifier>().ShowNotify();
        }

        AudioManager audioManager = FindAnyObjectByType<AudioManager>();
        audioManager.PlaySFX(audioManager._pickUpTrash);
    }
}
