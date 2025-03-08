using UnityEngine;

public class SpawnTreasure : MonoBehaviour
{
    public GameObject treasure;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void spawn(GameObject player) {
        // GameObject e = Instantiate(treasure, transform.position, Quaternion.identity);
        // e.transform.SetParent(transform);
        // e.GetComponent<TreasureInstance>().player = player;
    }
}
