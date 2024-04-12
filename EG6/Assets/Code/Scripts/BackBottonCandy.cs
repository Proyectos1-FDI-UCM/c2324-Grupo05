using UnityEngine;

public class BackBottonCandy : MonoBehaviour
{
    [SerializeField]private GameObject _pannel;
    public void Back()
    {
        //move again
        Time.timeScale = 1f;
        _pannel.SetActive(false);
    }



}
