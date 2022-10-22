using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UniRx;

public class PlayerUI : MonoBehaviour
{
    //playercore�� hp�� ��ȭ �ؽ�Ʈ�� ǥ���Ѵ�.
    public TextMeshProUGUI hpText;
    public PlayerCore playerCore;

    private void Start()
    {
        //�����Ѵ�. (hp�� ��ȭ�� ������ ������ �޴´�.)
        playerCore.hp.Subscribe(hp => UpdateHP(hp));
    }


    public void UpdateHP(int hp)
    {
        hpText.text = "HP : " + hp;
    }

}
