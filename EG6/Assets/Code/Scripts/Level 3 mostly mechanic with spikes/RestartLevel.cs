using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartLevel : MonoBehaviour
{
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _playerNewPosition;
    [SerializeField] GameObject _panel;
    public void OnClickRetry()
    { 
    
        _player.transform.position=_playerNewPosition.transform.position;
    
    
    
    }
}
