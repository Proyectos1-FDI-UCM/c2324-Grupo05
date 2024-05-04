using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StadisticsMenu : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] _spriteRenderers;
    [SerializeField] private int _nMaxTrash;
    public Slider slider;

    private void Start()
    {
        //Implementation
        //egg
        if (GlobalObjectRegistry.instance.isEggPicked)
        {
            _spriteRenderers[0].color = Color.white;
        }
        else
        {
            _spriteRenderers[0].color = Color.black;
        }

        //1st piece
        if (GlobalObjectRegistry.instance.collectedPieces >= 1)
        {
            _spriteRenderers[1].color = Color.white;
        }
        else
        {
            _spriteRenderers[1].color = Color.black;
        }

        //2nd piece
        if (GlobalObjectRegistry.instance.collectedPieces >= 2)
        {
            _spriteRenderers[2].color = Color.white;
            _spriteRenderers[3].color = Color.white;
        }
        else
        {
            _spriteRenderers[2].color = Color.black;
            _spriteRenderers[3].color = Color.black;
        }

        //3rd piece
        if (GlobalObjectRegistry.instance.collectedPieces >= 3)
        {
            _spriteRenderers[4].color = Color.white;
        }
        else
        {
            _spriteRenderers[4].color = Color.black;
        }

        slider.maxValue = _nMaxTrash;
        slider.value = GlobalObjectRegistry.instance.collectedTrash;
        
    }

    
    
}
