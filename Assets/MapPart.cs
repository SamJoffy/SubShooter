using UnityEngine;

public class MapPart : MonoBehaviour
{

    public GameObject SpawnRowOne;
    public GameObject SpawnRowTwo;
    public GameObject SpawnRowThree;
    public GameObject TreasureSpawn;


    void Start()
    {
        foreach(Transform child in SpawnRowOne.transform) {
            child.gameObject.GetComponent<SpawnEnemy>().spawn();
        }
    }

    
    void Update()
    {
        transform.position += new Vector3(0, 10.0F * Time.deltaTime, 0);
    }

    
}
