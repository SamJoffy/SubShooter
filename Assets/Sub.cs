using System.Numerics;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Scripting.APIUpdating;

public class Sub : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float speed; 

    private float movement; 

    private Rigidbody2D rb; 



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        UnityEngine.Vector3 mousePos = Input.mousePosition; 

        mousePos = Camera.main.ScreenToWorldPoint(mousePos); 

        UnityEngine.Vector3 target = new UnityEngine.Vector3(-mousePos.x, this.transform.position.y, this.transform.position.z); 

        this.transform.position = UnityEngine.Vector3.Lerp(this.transform.position,target, 5f*Time.deltaTime); 

        if (Input.GetMouseButton(0)) {
            this.transform.position -= UnityEngine.Vector3.down*10.0f*Time.deltaTime; 
        } else {
            this.transform.position += UnityEngine.Vector3.down*1.0f*Time.deltaTime; 
        }
        
    }
}
