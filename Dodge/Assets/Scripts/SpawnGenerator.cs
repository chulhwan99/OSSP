using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGenerator : MonoBehaviour
{
    //Prefabs를 저장하기 위한 GameObject배열
    public GameObject [] propPrefabs;
    public BoxCollider area;
    private int cubeCount;


    private void Start()
    {
        area = GetComponent<BoxCollider>(); 
        Spawn_Sphere();
        cubeCount = 0;
    }

    void Update()
    {
        //Sphere(Clone)이 존재하지 않으면 Spawn하고 cubeCount를 늘려줌
        if(!GameObject.Find("Sphere(Clone)"))
        {
            Spawn_Sphere();
            cubeCount++;
        }
        //Cube(Clone)이 존재하지 않고 cubeCount가 2면 Spawn하고 cubeCount를 0으로 만듦
        if(!GameObject.Find("Cube(Clone)") && cubeCount == 2)
        {
            Spawn_Cube();
            cubeCount = 0;
        }


    }

    private void Spawn_Sphere()
    {
        //Prefabs배열의 0번째(Sphere)를 가져옴
        GameObject selectedPrefab = propPrefabs[0];
        //아이템이 생성될 좌표
        Vector3 spawnPos = GetRandomPosition();
        //이미 만들어진 게임 오브젝트(Sphere)를 찍어내는 함수
        GameObject Instance = Instantiate(selectedPrefab, spawnPos, Quaternion.identity);

        
    }

    private void Spawn_Cube()
    {

        GameObject selectedPrefab1 = propPrefabs[1];
        Vector3 spawnPos1 = GetRandomPosition();
        //이미 만들어진 게임 오브젝트(Cube)를 찍어내는 함수
        GameObject Instance1 = Instantiate(selectedPrefab1, spawnPos1, Quaternion.identity);
    }
    //랜덤한 위치를 return하는 함수
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


