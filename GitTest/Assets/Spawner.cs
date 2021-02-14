using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject beaverPrefab;
    public Transform spawnPosition;
    public ParticleSystem killParticle;
    public Transform particlePosition;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(beaverPrefab, spawnPosition);
    }
    public void Dead()
    {
        Instantiate(killParticle, particlePosition.transform.position, particlePosition.transform.rotation);
        //Destroy(gameObject);
    }
}
