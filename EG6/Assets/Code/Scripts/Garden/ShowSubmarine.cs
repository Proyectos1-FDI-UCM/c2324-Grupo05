using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowSubmarine : MonoBehaviour
{
    [SerializeField] GameObject _submarine;
    [SerializeField] GameObject _pannel;
    [SerializeField] GameObject _trigger;
    [SerializeField] GameObject _pannel2;
    [SerializeField] GameObject _penguin;
    [SerializeField] private CharacterSwitcher _switcher;
    public void ClickTransform()
    {
        //
        if (_switcher.isControllingChild)
        {

            _penguin.SetActive(false);
            _submarine.SetActive(true);
            _pannel.SetActive(false);
            Destroy(_trigger);
            _pannel2.SetActive(true);
            GlobalObjectRegistry.instance.isPenguinUnlocked = false;
        }
        else
        {
            _pannel.SetActive(true);
        }
       
    
    }
}
