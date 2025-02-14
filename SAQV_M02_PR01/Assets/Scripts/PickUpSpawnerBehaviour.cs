using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickUpSpawnerBehaviour : MonoBehaviour
{
    public int restockTimer = 100;
    public int spawnTimer = 0;
    public GameObject pickUp;
    public bool itemTaken = false;

    // Start is called before the first frame update
    void Start()
    {
        spawnPickUp();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (itemTaken)
        {
            spawnTimer = restockTimer;
            itemTaken = true;
        }

        spawnTimer--;

        if (spawnTimer == 0)
        {
            spawnPickUp();
        }
    }

    void spawnPickUp()
    {
        GameObject newPickUp = Instantiate(pickUp, this.transform.position + this.transform.up, this.transform.rotation) as GameObject;
    }
}
