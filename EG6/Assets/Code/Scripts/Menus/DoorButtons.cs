using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButtons : MonoBehaviour
{
    [SerializeField] private GameObject _SegirJugando;
    [SerializeField] private GameObject _end;
    public void ClickYes()
    {
        _end.SetActive(true);

    }

    public void ClickNo()
    {
        _SegirJugando.SetActive(false);

    }
}
