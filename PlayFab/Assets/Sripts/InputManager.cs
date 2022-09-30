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

    //����� ������ ����
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
        (result) => { print("�� �����"); },
        (error) => { print("�� ���� ����"); });
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
            (error) => { print("�� �ҷ����� ����"); });
    }


    void GetUserinfo()
    {
        PlayFabClientAPI.GetAccountInfo(new GetAccountInfoRequest(), OnGetUserInfoSuccess, OnGetUserInfoFailure);
    }

    void OnGetUserInfoSuccess(GetAccountInfoResult result)
    {
        UserName.text = $" User : {result.AccountInfo.Username}";
        print("���� ���� �ҷ����� ����");
    }

    void OnGetUserInfoFailure(PlayFabError error)
    {
        print("���� ���� �ҷ����� ����");
    }

    void OnSaveSuccess(UpdatePlayerStatisticsResult result)
    {
        print("���ο� ������ ����");
    }

    void OnSaveFailure(PlayFabError error)
    {
        print("������ ���� ����");
    }

    void OnGetSuccess(GetPlayerStatisticsResult result)
    {
        print("������ �ҷ����� ����");

        foreach (var eachStat in result.Statistics)
        {
            Debug.Log(eachStat.StatisticName + " : " + eachStat.Value);
        }
    }

    void OnGetFailure(PlayFabError error)
    {
        print("������ �ҷ����� ����");
    }

}
