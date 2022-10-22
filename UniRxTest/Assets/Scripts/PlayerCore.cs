using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerCore : MonoBehaviour
{
    //hp�����Ѵ�
    //�����̽��� ������ hp�� �پ��

    /*    int hp = 100;
        public PlayerUI ui;

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                hp -= 10;
                //UI�� �ݿ�
                ui.UpdateHP(hp);
            }
        }*/

    //�����ȴ�. (��ȭ�ϸ� �����Ѵ�.)
    public ReactiveProperty<int> hp = new ReactiveProperty<int>(100);
    
    //hp�� ��ȭ�� ������ ��� �̺�Ʈ�� �߻���Ű�� ������ ������ ���� ���� ����ϸ� �ѹ��� ��ȭ�� ����ų�� �ִ�.


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            hp.Value -= 10;
        }
    }

}
