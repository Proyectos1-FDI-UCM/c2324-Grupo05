using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CombinationComponent : MonoBehaviour
{
    // Block with private (or protected) _fields
    [SerializeField]
    private int[] combination; //combinación correcta (1,2,3,4)
    
    private int i;

    [SerializeField] private DoorComponent _doorComponent;

    // Block with public Properties {get; set;}

    // Block with MonoBehaviour life-cycle methods (ONLY mono-functions)
    private void Awake()
    {
        
    }

    private void Start()
    {
        //Inicializar contador:
        i = -1;

        //Inicializar array combinación:
        combination = InicializarComb(out combination);
    }

    // MonoBehaviour update methods
    private void Update()
    {
        
    }

    // Block with custom classes or structures

    // Block with custom private Methods
    private int[] InicializarComb(out int[] combination)
    {
        combination = new int[4] { 0, 0, 0, 0 };
        
        return combination;
    }

    private bool CombOrdenado(int[] combination)
    {
        bool ordenado = true;
        int j = 0;
        while(j < combination.Length - 1 && ordenado)
        {
            if (combination[j] > combination[j + 1])
            {
                ordenado = false;
            }
            j++;
        }
        return ordenado;
    }

    // Block with custom public Methods (with summary if it has complex logic)
    public void CombCheck(int cifra)
    {
        //Se van metiendo los ids de cada botón en el orden de pulsado
        i++;
        combination[i] = cifra;

        //Verificar cuantos botones se han pulsado
        int j = 0;
        while (j < combination.Length && combination[j] != 0) j++;

        if(j >= combination.Length) //se han pulsado todos los botones
        {
            if(CombOrdenado(combination)) //si el vector está ordenado, la combinación es correcta
            {
                _doorComponent.OnPressedButton();
            }
            else //el vector no está ordenado, hay que resetear todo
            {
                combination = InicializarComb(out combination); //inicializar combinacion a 0
                i = -1; //inicializar contador
                //activar botón para que se pueda volver a pulsar
            }


        }

    }
}
