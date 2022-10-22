using System;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class HogeHoge : MonoBehaviour
{
    /*    public PlayerCore playerCore;
        private void Start()
        {
            playerCore.hp.Subscribe(_ => UpdateHoge());
        }

        public void UpdateHoge()
        {
            Debug.Log("UpdateHoge");
        }*/

    //�����̽� ��Ÿ ���� : 2�ʰ� ������ �αװ� ����.
    private void Start()
    {
        TimeSpan time = TimeSpan.FromSeconds(2);
        this.UpdateAsObservable()
            .Where(_ => Input.GetKeyDown(KeyCode.D) && Input.GetKeyDown(KeyCode.S)) //���� : �����̽� ������
            .ThrottleFirst(time) //1�� ������ �ð�2�ʴ� �������� �ʴ´�.
            .Subscribe(_ => Hoge());
    }

    void Hoge()
    {
        Debug.Log("Hoge0");
    }

}
