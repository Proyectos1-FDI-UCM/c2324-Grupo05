using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButtons : MonoBehaviour
{
    [SerializeField] private GameObject _SegirJugando;
    public void ClickYes()
    {
        //desbloquear cinematica

    }

    public void ClickNo()
    {
        _SegirJugando.SetActive(false);

    }
}
