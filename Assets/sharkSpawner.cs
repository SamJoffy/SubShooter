using UnityEngine;

public class sharkSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject sharkPrefab; 

    public GameObject player; 

    public float spawnDistance = 3f; 
    public float minSpawnInterval = 1f; 
    public float maxSpawnInterval = 3f;

    public float minX = -10f; 

    public float maxX = 10f; 

    public float despawnDistance = 15f; //The Area above the player in which the player despawns
    public GameObject current;

    private float nextSpawnY; 

    private float mapYPosition = 0f; //Current bottom of spawned content 

    private float speed = 2;


    void Start()
    {
        nextSpawnY = player.transform.position.y - spawnDistance; 

        mapYPosition = nextSpawnY; 
    }

    // Update is called once per frame
    void Update()
    {
        spawnDistance = spawnDistance + (speed * 0.5f); // Scale with speed

        while (player.transform.position.y - spawnDistance < nextSpawnY) {
            SpawnSharks(); 

            float speedAdjustedInterval = Mathf.Lerp(maxSpawnInterval, minSpawnInterval, speed / 15f);

            nextSpawnY -= Random.Range(minSpawnInterval, speedAdjustedInterval);
            
            spawnDistance = 0; 
            //spawnDistance = 0;
        }

        //spawnDistance += 1*speed;
    }

    void SpawnSharks() {
        int sharkCount = Random.Range(1, 4); 

        Debug.Log("Spawning Sharks"); 

        for (int i = 0; i < sharkCount; i++) {
            float posX = Random.Range(minX, maxX); 
            
            UnityEngine.Vector3 spawnPos = new UnityEngine.Vector3(posX, mapYPosition - (i *0.5f), player.transform.position.z); 

            GameObject shark = Instantiate(sharkPrefab, spawnPos, UnityEngine.Quaternion.identity); 
            shark.GetComponent<shark>().player = player;
            shark.transform.SetParent(current.transform, worldPositionStays: true); 

            shark sharkScript = sharkPrefab.GetComponent<shark>(); 

            sharkScript.player = player; 
        }

        mapYPosition = nextSpawnY; 
    }

    public void increaseSpeed(float speed) {
       
        minSpawnInterval += speed;
        maxSpawnInterval += speed;
        this.speed = speed;
    }
}
