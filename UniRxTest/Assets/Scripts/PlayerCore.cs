using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerCore : MonoBehaviour
{
    //hp관리한다
    //스페이스를 눌르면 hp가 줄어듬

    /*    int hp = 100;
        public PlayerUI ui;

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                hp -= 10;
                //UI에 반영
                ui.UpdateHP(hp);
            }
        }*/

    //구독된다. (변화하면 통지한다.)
    public ReactiveProperty<int> hp = new ReactiveProperty<int>(100);
    
    //hp의 변화가 있을때 어떠한 이벤트를 발생시키고 싶을때 새로이 구독 모델을 등록하면 한번에 변화를 일으킬수 있다.


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            hp.Value -= 10;
        }
    }

}
