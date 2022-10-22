using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UniRx;

public class PlayerUI : MonoBehaviour
{
    //playercore의 hp의 변화 텍스트를 표시한다.
    public TextMeshProUGUI hpText;
    public PlayerCore playerCore;

    private void Start()
    {
        //구독한다. (hp의 변화가 있으면 통지를 받는다.)
        playerCore.hp.Subscribe(hp => UpdateHP(hp));
    }


    public void UpdateHP(int hp)
    {
        hpText.text = "HP : " + hp;
    }

}
