using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUp : Item
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

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") {
            GameManager.GetInstance().add_surviveTime(3);
            Destroy(gameObject);
            
        }
    }
}