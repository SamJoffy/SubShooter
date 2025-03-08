using System.Numerics;
using UnityEngine;

public class sharkSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public GameObject treasurePrefab; 

    public GameObject player; 

    public float spawnDistance = 20f; 
    public float minSpawnInterval = 1f; 
    public float maxSpawnInterval = 3f;

    public float minX = -10f; 

    public float maxX = 10f; 

    public float despawnDistance = 15f; //The Area above the player in which the player despawns
    public GameObject current;

    private float nextSpawnY; 
    private float speed = 2;

    private float mapYPosition = 0f; //Current bottom of spawned content 

    private GameObject treasureContainer; 



    
    void Start()
    {
        nextSpawnY = player.transform.position.y - spawnDistance; 

        mapYPosition = nextSpawnY; 
        
    }

    // Update is called once per frame
    void Update()
    {

        while (player.transform.position.y - spawnDistance < nextSpawnY) {
            SpawnCoins(); 
            nextSpawnY -= Random.Range(minSpawnInterval, maxSpawnInterval);
            spawnDistance = 0;
        }

        spawnDistance += Time.deltaTime * speed;
        
    }

    void SpawnCoins() {
        Debug.Log("Spawn Coin"); 
        int coinCount = Random.Range(1, 4); 

        for (int i = 0; i < coinCount; i++) {
            float posX = Random.Range(minX, maxX); 
            
            UnityEngine.Vector3 spawnPos = new UnityEngine.Vector3(posX, mapYPosition - (i *0.5f), player.transform.position.z); 

            GameObject treasure = Instantiate(treasurePrefab, spawnPos, UnityEngine.Quaternion.identity); 

            treasure.transform.SetParent(current.transform, worldPositionStays: true); 

            shark treasureScript = treasure.GetComponent<shark>();
            if (treasureScript != null)
            {
                treasureScript.player = player;
            }
            else
            {
                Debug.LogWarning("shark component not found on spawned treasure!");
            }


        }

        mapYPosition = nextSpawnY; 
    }

    public void increaseSpeed(float speed) {
        minSpawnInterval += speed;
        maxSpawnInterval += speed;
        this.speed = speed;
    }
}
