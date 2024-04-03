using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class TimelineController : MonoBehaviour
{
    //reference to saved file
    [SerializeField] GameObject[] cinematicas; // Arreglo para almacenar las cinem�ticas
    [SerializeField] GameObject _menu;
    private int cinematicaActual = -1; // �ndice de la cinem�tica actual (-1 significa que ninguna est� siendo reproducida)

    void Start()
    {
        _menu.SetActive(true);
        // Desactiva todas las cinem�ticas al inicio
        foreach (GameObject cinematica in cinematicas)
        {
            cinematica.SetActive(false);
        }
    }

    // M�todo para iniciar una cinem�tica espec�fica
    public void IniciarCinematica(int indice)
    {
        // Si hay una cinem�tica reproduci�ndose, la detenemos
        if (cinematicaActual != -1)
        {
            cinematicas[cinematicaActual].SetActive(false);
        }

        // Activamos la nueva cinem�tica
        _menu.SetActive(false);
        cinematicaActual = indice;
        cinematicas[indice].SetActive(true);
    }

    // M�todo para cambiar de escena
    public void CambiarEscena()
    {
        SceneManager.LoadScene("BedroomTest");
    }
}
