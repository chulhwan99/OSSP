using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGenerator : MonoBehaviour
{
    public GameObject [] propPrefabs;
    public BoxCollider area;

    private void Start()
    {
        area = GetComponent<BoxCollider>(); 
        Spawn();
    }

    void Update()
    {

        if(!GameObject.Find("Sphere(Clone)"))
        {
            Spawn();
        }


    }


    private void Spawn()
    {

        GameObject selectedPrefab = propPrefabs[0];

        Vector3 spawnPos = GetRandomPosition();

        GameObject Instance = Instantiate(selectedPrefab, spawnPos, Quaternion.identity);

    }

    private Vector3 GetRandomPosition()
    {
        Vector3 basePosition = transform.position;
        Vector3 size = area.size;

        float posX = basePosition.x + Random.Range(-size.x/2f, + size.x/2f);

        float posY = basePosition.y + Random.Range(-size.y/2f, + size.y/2f);

        float posZ = basePosition.z + Random.Range(-size.z/2f, + size.z/2f);

        Vector3 spawnPos = new Vector3(posX, posY, posZ);

        return spawnPos;

    }
}


