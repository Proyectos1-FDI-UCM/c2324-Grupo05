using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// This class is used to change the scene when the animation ends
/// </summary>
public class SceneTransition : MonoBehaviour
{
    private Animator animator;

    [SerializeField] private AnimationClip animacionFinal;
    
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void ChangeScene(bool start)
    {
        if(start)
        {
            StartCoroutine(CambiarEscena());
        }    
    }

    IEnumerator CambiarEscena()
    {
        animator.SetTrigger("Iniciar");
        yield return new WaitForSeconds(animacionFinal.length);
        SceneManager.LoadScene("Timelines");
    }
}
