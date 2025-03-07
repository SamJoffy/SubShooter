using UnityEngine;

public class Map : MonoBehaviour
{
    public GameObject mapPart;
    public GameObject newParts;
    public NewPartTrigger newPartTrigger1;
    public NewPartTrigger newPartTrigger2;
    public NewPartTrigger newPartTrigger3;

    private GameObject previousPart;
    private GameObject currentPart;
    private GameObject nextPart;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        previousPart = Instantiate(mapPart, transform.position - new Vector3(0, 10, 0), Quaternion.identity);
        currentPart = Instantiate(mapPart, transform.position - new Vector3(0, 50, 0), Quaternion.identity);
        nextPart = Instantiate(mapPart, transform.position - new Vector3(0, 90, 0), Quaternion.identity);

        previousPart.transform.SetParent(newParts.transform);
        currentPart.transform.SetParent(newParts.transform);
        nextPart.transform.SetParent(newParts.transform);

        // loop through newParts and add triggers

        newPartTrigger1.GenerateNewPart += addNewPart;
    }

    void addNewPart() {
        Destroy(previousPart);
        previousPart = currentPart;
        currentPart = nextPart;
        nextPart = Instantiate(mapPart, transform.position - new Vector3(0, 30, 0), Quaternion.identity);
    }

    private void OnDestroy()
    {
        // newPartTrigger.GenerateNewPart -= addNewPart;
    }

}
