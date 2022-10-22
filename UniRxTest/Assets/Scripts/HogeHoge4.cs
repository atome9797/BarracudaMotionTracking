using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;
using TMPro;

public class HogeHoge4 : MonoBehaviour
{
    [SerializeField] Button Prevbutton;
    [SerializeField] Button Nextbutton;

    [SerializeField]  GameObject[] gameObject  = new GameObject[10];

    void Start()
    {
        // ù��° ����
        Prevbutton.onClick
            .AsObservable() // �̺�Ʈ�� ��Ʈ������ ����
            .Subscribe(_ =>
            {
                gameObject[0].SetActive(false);
                gameObject[1].SetActive(true);
            });

        Nextbutton.onClick
            .AsObservable() // �̺�Ʈ�� ��Ʈ������ ����
            .Subscribe(_ =>
            {
                gameObject[0].SetActive(true);
                gameObject[1].SetActive(false);
            });

    }
}
