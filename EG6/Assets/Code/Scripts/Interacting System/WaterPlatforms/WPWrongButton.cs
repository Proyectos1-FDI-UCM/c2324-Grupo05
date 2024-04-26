using System.Threading.Tasks;
using UnityEngine;

public class WPWrongButton : Button
{
   [SerializeField] GameObject _waterPlatform;

    protected override async void ButtonPressed()
    {
        base.ButtonPressed();
        ButtonPressCommand buttonPressCommand = new ButtonPressCommand(ButtonId, _buttonRenderer, _localObjectHandler);
        buttonPressCommand.Execute();
        foreach (Transform smallPlatform in _waterPlatform.GetComponentInChildren<Transform>())
        {
            smallPlatform.gameObject.AddComponent<Water>();
            smallPlatform.gameObject.AddComponent<BoxCollider2D>().isTrigger = true;
            Water water = smallPlatform.gameObject.GetComponent<Water>();
            smallPlatform.GetComponent<SpriteRenderer>().enabled = false;
        }
        AudioClip onPressedSound = Resources.Load<AudioClip>("Audio/WaterPlatform/waterPlatform");
        AudioSource.PlayClipAtPoint(onPressedSound, transform.position);

        await Task.Delay(1000);
        buttonPressCommand.Undo();
    }
}
