using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Game : MonoBehaviour
{
    // ["SerializeField"]
    public int floorCount = 4;
    public GameObject floorPrefab;

    public List<GameObject> floors;
    // Start is called before the first frame update
    void Start()
    {
        // TODO: Instantiate number of floors at z = 0/10/20/..
        // Set the Floor's activeFloors variable to the amount of instantiated floors
        for (int i = 0; i < floorCount; i++)
        {
            print("init floor");
            GameObject newFloor = Instantiate(floorPrefab, new Vector3(0, 0, i * 10), Quaternion.identity);
            floors.Add(newFloor);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void death()
    {
        print(floors.Count);
        foreach (GameObject g in floors)
        {   
            g.GetComponent<Floor>().stop();

        }
        GameObject.Find("Player").GetComponent<Rigidbody>().useGravity = true;
    }
}
