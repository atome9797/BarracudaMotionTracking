using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HogeHoge2 : MonoBehaviour
{
    bool canPush = true;

    float coolTime = 2f;
    float coolTimeCount = 2;

    // Update is called once per frame
    void Update()
    {
        coolTimeCount += Time.deltaTime;
        if(coolTimeCount >= coolTime)
        {
            canPush = true;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(canPush)
            {
                coolTimeCount = 0;
                canPush = false;
                Hoge();
            }
        }
    }

    void Hoge()
    {
        Debug.Log("Hoge0");
    }
}
