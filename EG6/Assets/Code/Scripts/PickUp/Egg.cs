using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class Egg : PickableObject
{
    //reference to egg counter
    public int _nEgg;

    //reference to instance
    private static Egg _instance;
    static public Egg Instance
    {
        get { return _instance; }
    }

    private void Awake()
    {
        if(!_instance)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Deberia coger el huevo");
        if (collision.gameObject.GetComponent<PlayerMovement>() != null)
        {
            PickUp();
            DontDestroyOnLoad(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }

    public override void PickUp()
    {
        _nEgg++;
        base.PickUp(); // base. is used to call method PickUp from PickableObject class and then execute additional code below
        
    }
}
