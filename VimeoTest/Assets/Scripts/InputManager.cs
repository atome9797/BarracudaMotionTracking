using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using TMPro;

public class InputManager : MonoBehaviour
{
    public TMP_InputField Input1, Input2, Input3;
    public TextMeshProUGUI UserName;

    void Start()
    {
        GetUserinfo();
    }


    //���� ���� ��������
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

   

}
