using UnityEngine;
using UnityEngine.SceneManagement;

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
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Deberia coger el huevo");
        if (collision.gameObject.GetComponent<ChildMovement>() != null)
        {
            PickUp();
            DontDestroyOnLoad(gameObject);
            
            _localObjectHandler.SaveLocalState();
            SceneManager.LoadScene("BedroomTest");
        }
    }

    public override void PickUp()
    {
        _nEgg++;
        base.PickUp(); // base. is used to call method PickUp from PickableObject class and then execute additional code below
        
    }
}
