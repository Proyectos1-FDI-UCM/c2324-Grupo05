using UnityEngine;

/// <summary>
/// This class is used to animate the conveyor belt sprite.
/// </summary>
public class ConveyorBeltAnimator : MonoBehaviour
{
   private SpriteRenderer _spriteRenderer;


   private void Start()
    {
       _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    

   public void RotateSprite()
   {   
        
      if (gameObject.CompareTag("A")) //verificar si tiene la etiqueta
      {
         Vector3 currentScale = _spriteRenderer.transform.localScale;   //rotar el objeto en vertical
         currentScale.y *= -1;
         _spriteRenderer.transform.localScale = currentScale;
      }

      else
      {
         Vector3 currentScale = _spriteRenderer.transform.localScale;     //rotar el objeto en horizontal
         currentScale.x *= -1;
         _spriteRenderer.transform.localScale = currentScale;
       }
   }
}
