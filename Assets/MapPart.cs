using System;
using UnityEngine;

public class MapPart : MonoBehaviour
{

    public GameObject SpawnRowOne;
    public GameObject SpawnRowTwo;
    public GameObject SpawnRowThree;
    public GameObject TreasureSpawn;

    public GameObject Player;

 
    public float speed = 2.0f;




    void Start()
    {

        foreach(Transform child in SpawnRowOne.transform) {
            child.gameObject.GetComponent<SpawnEnemy>().spawn(Player);
        }
        foreach(Transform child in TreasureSpawn.transform) {

           
            

                    
            child.gameObject.GetComponent<SpawnTreasure>().spawn(Player);


            
        }
    }

    
    void Update()
    {
        transform.position += new Vector3(0, speed * Time.deltaTime, 0);
    }

    
}
