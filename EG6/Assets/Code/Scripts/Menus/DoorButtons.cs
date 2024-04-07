using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorButtons : MonoBehaviour
{
    [SerializeField] private GameObject _SegirJugando;
    public void ClickYes()
    {
        SceneManager.LoadScene("END");

    }

    public void ClickNo()
    {
        _SegirJugando.SetActive(false);

    }
}
