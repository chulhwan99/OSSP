using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Item의 추상클래스
public abstract class Item : MonoBehaviour
{
    public abstract void DestroyAfterTime();

    void Start()
    {
        
    }
}