using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StadisticsMenu : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] _spriteRenderers;


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
        }
        else
        {
            _spriteRenderers[2].color = Color.black;
        }

        //3rd piece
        if (GlobalObjectRegistry.instance.collectedPieces >= 3)
        {
            _spriteRenderers[3].color = Color.white;
        }
        else
        {
            _spriteRenderers[3].color = Color.black;
        }



    }

    
}
