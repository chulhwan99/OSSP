using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUp : Item
{
    
    public override void DestroyAfterTime()
    {
        Invoke("DestroyObject", 4.0f);
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }

    //오브젝트간의 충돌을 감지하는 함수
    public void OnCollisionEnter(Collision collision)
    {
        //충돌한 오브젝트의 tag가 "Player"면 GameManager 스크립트의 add_survivieTime(3)을 실행시키고 
        //아이템 오브젝트를 삭제함
        if (collision.gameObject.tag == "Player") {
            GameManager.GetInstance().add_surviveTime(3);
            Destroy(gameObject);
            
        }
    }
}