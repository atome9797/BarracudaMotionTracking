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
    //테스트용으로 인풋필드 4개 로그를 띄울 텍스트 1개 필요

    //키 값
    [Header("KeyValue")]
    public InputField KeyValue;

    // 변수 1, 2, 3
    [Header("InputField")]
    public InputField InputField1;
    public InputField InputField2;
    public InputField InputField3;

    [Header("Log")]
    public Text LogText;
 
    // 간단하게 Get Set 하기위해 버튼으로 만듬 각각 Get할 버튼과 Set할 버튼에 넣어주면 됨
    public void ButtonSet()
    {
        SaveJson(KeyValue.text);
    }
    public void ButtonGet()
    {
        GetUserData(KeyValue.text);
    }

    /// <summary>
    /// 플레이팹과 관련된 행동을 실패했을 때 부르는 함수
    /// </summary>
    /// <param name="error">에러의 원인을 출력</param>
    private void PlayfabError(PlayFabError error) => Debug.LogError("error : " + error.GenerateErrorReport());
    // JSON으로 저장하는 함수( KeyName을 넣으면 됨 )
    public void SaveJson(string KeyName)
    {
        // List값 들어가는지 테스트 용도로 지워도됨
        List<string> data = new List<string>();
        // 테스트 용으로 배열에 값을 5개 넣어봄
        data.Add("qwe");
        data.Add("wer");
        data.Add("ert");
        data.Add("rty");
        data.Add("tyu");
        
        GetAccountInfoRequest PD = new GetAccountInfoRequest { PlayFabId = PlayFabManager.GetID() };
        // content에 TestData에 있는 클래스에 있는 값 각각의 데이터 형식으로 바꿔서 저장함
        TestData content = new TestData(InputField1.text, Convert.ToInt32(InputField2.text), float.Parse(InputField3.text), data);
        // 데이터를 넘길 값을 만듬
        Dictionary<string, string> dataDic = new Dictionary<string, string>();
        // 데이터 이름 정해주고 추가
        dataDic.Add(KeyName, JsonUtility.ToJson(content));
        // 유저 데이터에 업데이트 하는 함수
        SetUserData(dataDic);
    }

    /// <summary>
    /// 유저 데이터에 업데이트 함
    /// </summary>
    /// <param name="data">딕셔너리에 저장된 값을 뽑아냄 </param>
    private void SetUserData(Dictionary<string, string> data)
    {
        var request = new UpdateUserDataRequest() { Data = data, Permission = UserDataPermission.Public };
        try
        {
            PlayFabClientAPI.UpdateUserData(request, (result) =>
            {
                Debug.Log("데이터 업데이트 성공함");

            }, PlayfabError);
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
        }
    }


    // JSON 파싱 ( keyName으로 파싱할 값을 정함 )
    public void GetUserData(string KeyName)
    {
        //데이터 내부의 타이틀 데이터 정보를 불러옴
        var request = new GetUserDataRequest() { PlayFabId = PlayFabManager.GetID() };
        PlayFabClientAPI.GetUserData(request, (result) =>// 호출에 성공했을 때
        {
            // 불러온 타이틀 데이터에서 같은 이름의 키값을 찾음
            foreach (var eachData in result.Data)
            {
                // 디버그 용
                string key = eachData.Key;
                // 찾은 키값을 토대로 파싱함
                if (eachData.Key.Contains(KeyName))
                {
                    // 파싱할 데이터를 불러옴
                    TestData content = JsonUtility.FromJson<TestData>(eachData.Value.Value);

                    // 아래는 테스트 용도로 불러온 데이터 하나씩 넣음 [content.값] 으로 데이터를 하나하나 불러올 수 있다.
                    // 쉽게쓰기위한 함수가 필요할듯함 
                    List<string> 파싱데이터 = new List<string>();
                    파싱데이터.Add(content.name);
                    파싱데이터.Add(Convert.ToString(content.level));// string값으로 바꿔서 저장
                    파싱데이터.Add(Convert.ToString(content.code));
                    파싱데이터.Add(Convert.ToString(content.data.Count));
                    파싱데이터.Add(content.data[0]);//배열 값
                    파싱데이터.Add(content.data[1]);
                    파싱데이터.Add(content.data[2]);
                    파싱데이터.Add(content.data[3]);
                    파싱데이터.Add(content.data[4]);

                    // 넣은 데이터 로그로 보이게 하는거
                    foreach (var dat in 파싱데이터)
                    {
                        Debug.Log(dat);
                    }
                }
            }
        }, PlayfabError);// 호출에 실패했을 때
    }
    
}

// JSON으로 값을 저장하고 부르는 용도
public class TestData
{
    // JSON에 들어갈 데이터 형식을 넣어줌
    public string name;
    public int level;
    public float code;
    public List<string> data;
    
    // 쓰기 쉽게 TestData를 바로 불러서 사용하도록 함수로 만들어 둠 위쪽과 데이터 형식이 똑같아야 함
    public TestData(string name, int level, float code, List<string> data)
    {
        this.name = name;
        this.level = level;
        this.code = code;
        this.data = data;
    }
}