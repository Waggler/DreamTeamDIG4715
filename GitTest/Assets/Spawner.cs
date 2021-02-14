using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject beaverPrefab;
    public Transform spawnPosition;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(beaverPrefab, spawnPosition);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
