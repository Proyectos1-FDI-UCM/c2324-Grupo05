using UnityEngine;
using UnityEngine.SceneManagement;

public class Egg : PickableObject
{
    //reference to egg counter
    public int _nEgg;

    [SerializeField] private Checkpoint _nextCheckpoint;
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
        if (collision.gameObject.GetComponent<ChildMovement>() != null)
        {
            PickUp();
            DontDestroyOnLoad(gameObject);
            
            _localObjectHandler.SetLastCheckpoint(_nextCheckpoint);
            GlobalObjectRegistry.instance.isPenguinUnlocked = true;
            SceneManager.LoadScene("Cinematica");
            //SceneManager.LoadScene("BedroomTest");
        }
    }

    public override void PickUp()
    {
        _nEgg++;
        base.PickUp(); // base. is used to call method PickUp from PickableObject class and then execute additional code below
        
    }
}
