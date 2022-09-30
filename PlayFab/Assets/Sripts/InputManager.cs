using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using TMPro;

public class InputManager : MonoBehaviour
{
    public TMP_InputField Input1, Input2, Input3;
    public Text UserName;

    void Start()
    {
        GetUserinfo();
    }

    //사용자 데이터 세팅
    public void SetStat()
    {
        PlayFabClientAPI.UpdatePlayerStatistics(new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate {StatisticName = "Input_1", Value = int.Parse(Input1.text)},
                new StatisticUpdate {StatisticName = "Input_2", Value = int.Parse(Input2.text)},
                new StatisticUpdate {StatisticName = "Input_3", Value = int.Parse(Input3.text)}
            }
        },
        (result) => { print("값 저장됨"); },
        (error) => { print("값 저장 실패"); });
    }

    public void GetStat()
    {
        PlayFabClientAPI.GetPlayerStatistics(
            new GetPlayerStatisticsRequest(),
            (result) =>
            {
                foreach (var eachStat in result.Statistics)
                    print(eachStat.StatisticName + " : " + eachStat.Value);
                  
            },
            (error) => { print("값 불러오기 실패"); });
    }


    void GetUserinfo()
    {
        PlayFabClientAPI.GetAccountInfo(new GetAccountInfoRequest(), OnGetUserInfoSuccess, OnGetUserInfoFailure);
    }

    void OnGetUserInfoSuccess(GetAccountInfoResult result)
    {
        UserName.text = $" User : {result.AccountInfo.Username}";
        print("유저 정보 불러오기 성공");
    }

    void OnGetUserInfoFailure(PlayFabError error)
    {
        print("유저 정보 불러오기 실패");
    }

    void OnSaveSuccess(UpdatePlayerStatisticsResult result)
    {
        print("새로운 데이터 저장");
    }

    void OnSaveFailure(PlayFabError error)
    {
        print("데이터 저장 실패");
    }

    void OnGetSuccess(GetPlayerStatisticsResult result)
    {
        print("데이터 불러오기 성공");

        foreach (var eachStat in result.Statistics)
        {
            Debug.Log(eachStat.StatisticName + " : " + eachStat.Value);
        }
    }

    void OnGetFailure(PlayFabError error)
    {
        print("데이터 불러오기 실패");
    }

}
