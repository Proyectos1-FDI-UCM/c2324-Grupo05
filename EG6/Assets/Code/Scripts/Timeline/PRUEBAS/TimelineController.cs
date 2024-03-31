using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class TimelineController : MonoBehaviour
{
    //reference to saved file
    [SerializeField] GameObject[] cinemáticas; // Arreglo para almacenar las cinemáticas
    [SerializeField] GameObject _menu;
    private int cinemáticaActual = -1; // Índice de la cinemática actual (-1 significa que ninguna está siendo reproducida)

    void Start()
    {
        _menu.SetActive(true);
        // Desactiva todas las cinemáticas al inicio
        foreach (GameObject cinemática in cinemáticas)
        {
            cinemática.SetActive(false);
        }
    }

    // Método para iniciar una cinemática específica
    public void IniciarCinemática(int índice)
    {
        // Si hay una cinemática reproduciéndose, la detenemos
        if (cinemáticaActual != -1)
        {
            cinemáticas[cinemáticaActual].SetActive(false);
        }

        // Activamos la nueva cinemática
        _menu.SetActive(false);
        cinemáticaActual = índice;
        cinemáticas[índice].SetActive(true);
    }

    // Método para cambiar de escena
    public void CambiarEscena()
    {
        SceneManager.LoadScene("BedroomTest");
    }
}
