using UnityEngine;

public class MapPart : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 5.0F * Time.deltaTime, 0);
    }

    
}
