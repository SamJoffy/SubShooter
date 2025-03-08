using UnityEngine;


public class TreasureInstance : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject player; 
    private CapsuleCollider2D myCollider; 
    private CapsuleCollider2D playerCollider; 

    void Start()
    {
        myCollider = GetComponent<CapsuleCollider2D>(); 
        playerCollider = player.GetComponent<CapsuleCollider2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (myCollider.bounds.Intersects(playerCollider.bounds)) {
            Destroy(gameObject); 

            //Update UI 
            ScoreManager.instance.AddPoint(); 

        }
    }

    void OnCollisionEnter(Collision collision)
    {
        
    }
}
