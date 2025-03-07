using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Range(1, 10)]
    [SerializeField] private float speed = 10f; 

    [Range(1, 10)]
    [SerializeField] private float lifetime = 3f; 

    private Rigidbody2D rb;

    private void Start(){
        rb = GetComponent<Rigidbody2D>(); 
        Destroy(gameObject, lifetime); 
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = transform.up *speed; 
        
    }


}
