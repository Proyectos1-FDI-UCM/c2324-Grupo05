using UnityEngine;
using System.Collections;

public class Ice : MovableObject
{
    [SerializeField] public float _lifeTime = 10f; 
    private float _startTime;
    private bool _isBlinking = false; 
    private SpriteRenderer spriteRenderer;


    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
        _startTime = Time.time;
    }


    private void Update()
    {
        if ((Time.time - _startTime) >= 0.7f * _lifeTime)
        {
            if (!_isBlinking)
            {
                StartCoroutine(BlinkSprite());
                _isBlinking = true;
            }
        }
         if ((Time.time - _startTime) >= _lifeTime)
        {
            Destroy(gameObject); 
        }
    }

    
    private IEnumerator BlinkSprite()
    {
        while (true)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            yield return new WaitForSeconds(0.1f); 
        }
    }
}


