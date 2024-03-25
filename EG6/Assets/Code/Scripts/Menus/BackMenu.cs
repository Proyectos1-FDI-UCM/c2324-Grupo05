using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackMenu : MonoBehaviour
{
    [SerializeField] private GameObject _menu;
    public  void Back()
    {

        Time.timeScale = 1f;
        _menu.SetActive(false);
    }
}
