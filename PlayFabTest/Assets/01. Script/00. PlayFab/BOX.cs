using Newtonsoft.Json;
using PlayFab.ClientModels;
using PlayFab;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;
using UnityEditor;
using System.Runtime.InteropServices;
using PlayFab.EconomyModels;
using Unity.VisualScripting;

public class BOX : MonoBehaviour
{
    //�׽�Ʈ������ ��ǲ�ʵ� 4�� �α׸� ��� �ؽ�Ʈ 1�� �ʿ�

    //Ű ��
    [Header("KeyValue")]
    public InputField KeyValue;

    // ���� 1, 2, 3
    [Header("InputField")]
    public InputField InputField1;
    public InputField InputField2;
    public InputField InputField3;

    [Header("Log")]
    public Text LogText;
 
    // �����ϰ� Get Set �ϱ����� ��ư���� ���� ���� Get�� ��ư�� Set�� ��ư�� �־��ָ� ��
    public void ButtonSet()
    {
        SaveJson(KeyValue.text);
    }
    public void ButtonGet()
    {
        GetUserData(KeyValue.text);
    }

    /// <summary>
    /// �÷����հ� ���õ� �ൿ�� �������� �� �θ��� �Լ�
    /// </summary>
    /// <param name="error">������ ������ ���</param>
    private void PlayfabError(PlayFabError error) => Debug.LogError("error : " + error.GenerateErrorReport());
    // JSON���� �����ϴ� �Լ�( KeyName�� ������ �� )
    public void SaveJson(string KeyName)
    {
        // List�� ������ �׽�Ʈ �뵵�� ��������
        List<string> data = new List<string>();
        // �׽�Ʈ ������ �迭�� ���� 5�� �־
        data.Add("qwe");
        data.Add("wer");
        data.Add("ert");
        data.Add("rty");
        data.Add("tyu");
        
        GetAccountInfoRequest PD = new GetAccountInfoRequest { PlayFabId = PlayFabManager.GetID() };
        // content�� TestData�� �ִ� Ŭ������ �ִ� �� ������ ������ �������� �ٲ㼭 ������
        TestData content = new TestData(InputField1.text, Convert.ToInt32(InputField2.text), float.Parse(InputField3.text), data);
        // �����͸� �ѱ� ���� ����
        Dictionary<string, string> dataDic = new Dictionary<string, string>();
        // ������ �̸� �����ְ� �߰�
        dataDic.Add(KeyName, JsonUtility.ToJson(content));
        // ���� �����Ϳ� ������Ʈ �ϴ� �Լ�
        SetUserData(dataDic);
    }

    /// <summary>
    /// ���� �����Ϳ� ������Ʈ ��
    /// </summary>
    /// <param name="data">��ųʸ��� ����� ���� �̾Ƴ� </param>
    private void SetUserData(Dictionary<string, string> data)
    {
        var request = new UpdateUserDataRequest() { Data = data, Permission = UserDataPermission.Public };
        try
        {
            PlayFabClientAPI.UpdateUserData(request, (result) =>
            {
                Debug.Log("������ ������Ʈ ������");

            }, PlayfabError);
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
        }
    }


    // JSON �Ľ� ( keyName���� �Ľ��� ���� ���� )
    public void GetUserData(string KeyName)
    {
        //������ ������ Ÿ��Ʋ ������ ������ �ҷ���
        var request = new GetUserDataRequest() { PlayFabId = PlayFabManager.GetID() };
        PlayFabClientAPI.GetUserData(request, (result) =>// ȣ�⿡ �������� ��
        {
            // �ҷ��� Ÿ��Ʋ �����Ϳ��� ���� �̸��� Ű���� ã��
            foreach (var eachData in result.Data)
            {
                // ����� ��
                string key = eachData.Key;
                // ã�� Ű���� ���� �Ľ���
                if (eachData.Key.Contains(KeyName))
                {
                    // �Ľ��� �����͸� �ҷ���
                    TestData content = JsonUtility.FromJson<TestData>(eachData.Value.Value);

                    // �Ʒ��� �׽�Ʈ �뵵�� �ҷ��� ������ �ϳ��� ���� [content.��] ���� �����͸� �ϳ��ϳ� �ҷ��� �� �ִ�.
                    // ���Ծ������� �Լ��� �ʿ��ҵ��� 
                    List<string> �Ľ̵����� = new List<string>();
                    �Ľ̵�����.Add(content.name);
                    �Ľ̵�����.Add(Convert.ToString(content.level));// string������ �ٲ㼭 ����
                    �Ľ̵�����.Add(Convert.ToString(content.code));
                    �Ľ̵�����.Add(Convert.ToString(content.data.Count));
                    �Ľ̵�����.Add(content.data[0]);//�迭 ��
                    �Ľ̵�����.Add(content.data[1]);
                    �Ľ̵�����.Add(content.data[2]);
                    �Ľ̵�����.Add(content.data[3]);
                    �Ľ̵�����.Add(content.data[4]);

                    // ���� ������ �α׷� ���̰� �ϴ°�
                    foreach (var dat in �Ľ̵�����)
                    {
                        Debug.Log(dat);
                    }
                }
            }
        }, PlayfabError);// ȣ�⿡ �������� ��
    }
    
}

// JSON���� ���� �����ϰ� �θ��� �뵵
public class TestData
{
    // JSON�� �� ������ ������ �־���
    public string name;
    public int level;
    public float code;
    public List<string> data;
    
    // ���� ���� TestData�� �ٷ� �ҷ��� ����ϵ��� �Լ��� ����� �� ���ʰ� ������ ������ �Ȱ��ƾ� ��
    public TestData(string name, int level, float code, List<string> data)
    {
        this.name = name;
        this.level = level;
        this.code = code;
        this.data = data;
    }
}