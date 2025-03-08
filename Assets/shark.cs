using UnityEngine;

public class shark : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject player; 

    private float speed = 1.0f; 

    private Rigidbody2D rb; 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = (player.transform.position - transform.position).normalized; 
        
        movePlayer(direction); 
    }

     void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") {
            Debug.Log("balls");
        }
    }

    void movePlayer(Vector2 direction) {
        rb.linearVelocity = new Vector2(direction.x, direction.y) * speed; 
    }
}
