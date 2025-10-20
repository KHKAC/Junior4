using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    public delegate void MineHandler();
    public static event MineHandler OnMineReady;
    int catched = 0;
    
    public void AddCatch()
    {
        catched++;
        if(catched >= 3)
        {
            // Player에게 mine을 설치 가능하다고 알려줘야함.
            // GameObject.Find("Player").GetComponent<PlayerController>().MineIsReady();
            OnMineReady();
            // 자기 자신은 삭제
            Destroy(gameObject);
        }
    }
}
