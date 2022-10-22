using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HogeHoge3 : MonoBehaviour
{
    bool canPush = true;

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canPush)
            {
                StartCoroutine(CoolTime());
                Hoge();
            }
        }
    }

    IEnumerator CoolTime()
    {
        canPush = false;
        yield return new WaitForSeconds(2);
        canPush = true;
    }

    void Hoge()
    {
        Debug.Log("Hoge3");
    }
}
