using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottonDeath : MonoBehaviour
{
    [SerializeField] GameObject _pannel;
    public void Retry()
    {
        _pannel.SetActive(false);
        //tiempo normal
        Time.timeScale = 1f;

    }
}
