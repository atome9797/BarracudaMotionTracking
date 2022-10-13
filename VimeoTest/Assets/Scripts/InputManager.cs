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


    //유저 정보 가져오기
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

   

}
