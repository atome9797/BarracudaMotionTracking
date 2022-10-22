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

    //스페이스 연타 방지 : 2초간 눌러도 로그가 없다.
    private void Start()
    {
        TimeSpan time = TimeSpan.FromSeconds(2);
        this.UpdateAsObservable()
            .Where(_ => Input.GetKeyDown(KeyCode.D) && Input.GetKeyDown(KeyCode.S)) //조건 : 스페이스 눌리면
            .ThrottleFirst(time) //1번 눌르면 시간2초는 통지하지 않는다.
            .Subscribe(_ => Hoge());
    }

    void Hoge()
    {
        Debug.Log("Hoge0");
    }

}
