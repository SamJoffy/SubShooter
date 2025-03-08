using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy;

    public void spawn(GameObject player) {
        GameObject e = Instantiate(enemy, transform.position, Quaternion.identity);
        e.transform.SetParent(transform);
        e.GetComponent<Squid>().player = player;
    }
}
