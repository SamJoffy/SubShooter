using UnityEngine;

public class Squid : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject player; 

    private float speed = 1.0f; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, transform.position.y + speed * Time.deltaTime * Vector3.Normalize(player.transform.position - transform.position).y, 0);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") {
            Debug.Log("balls");
        }
    }
}
