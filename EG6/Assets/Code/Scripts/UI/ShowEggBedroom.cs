using UnityEngine;

public class ShowEggBedroom : MonoBehaviour
{
    [SerializeField] GameObject _egg;
    [SerializeField] GameObject _pannelEgg;
    [SerializeField] GameObject _invisibleWall;

    private bool _isEggPlaced;
 
    private void Start()
    {
        _isEggPlaced = GlobalObjectRegistry.instance.GetLevelState("Map-Exterior").LastCheckpointID >= 2;

        if (_isEggPlaced && GlobalObjectRegistry.instance.isEggPicked)
        {
            _egg.SetActive(true);
            _invisibleWall.SetActive(false);
            _pannelEgg.SetActive(false);
            Debug.Log("1");
        }
        else if (GlobalObjectRegistry.instance.isEggPicked && _isEggPlaced == false)
        {
            _egg.SetActive(false);
            _invisibleWall.SetActive(true);
            _pannelEgg.SetActive(true);
            Debug.Log("2");
        }
        else if (GlobalObjectRegistry.instance.isEggPicked == false && _isEggPlaced == false)
        {
            _pannelEgg.SetActive(false);
            _egg.SetActive(false);
            _invisibleWall.SetActive(false);
            Debug.Log("3");
        }
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ChildMovement>() != null && GlobalObjectRegistry.instance.isEggPicked && _isEggPlaced == false)
        {
            _egg.SetActive(true);
            _pannelEgg.SetActive(false);
            _invisibleWall.SetActive(false);

            GlobalObjectRegistry.LevelState mainLevelState = GlobalObjectRegistry.instance.LevelStates[0];
            mainLevelState.LastCheckpointID = 2;
            GlobalObjectRegistry.instance.SaveLevelState(mainLevelState.PickedObjects, mainLevelState.OpenedDoors, mainLevelState.DestroyedObjects, mainLevelState.PressedButtons, mainLevelState.LastCheckpointID, mainLevelState.SceneName);
            Destroy(gameObject);
        }
    }
   

}
