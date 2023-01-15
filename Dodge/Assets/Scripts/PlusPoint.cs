using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusPoint : Item
{
    
    public override void DestroyAfterTime()
    {
        Invoke("DestroyObject", 4.0f);
    }

    public override void RunItem()
    {

    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
            GameManager.GetInstance().add_plusPoint();
            Destroy(gameObject);
        }
    }
}