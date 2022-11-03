using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayFabManager : SingletonBehaviour<PlayFabManager>
{
    public TMP_InputField EmailInput, PasswordInput, UsernameInput;
    public string UserId;

    //InfoRequestParameters asd;

    //�α���
    public void LoginBtn()
    {

        EmailInput.text = "hungame@naver.com";
        PasswordInput.text = "kyh970807*";

        var request = new LoginWithEmailAddressRequest {  Email = EmailInput.text , Password = PasswordInput.text , InfoRequestParameters = new GetPlayerCombinedInfoRequestParams()
        {
            GetPlayerProfile = true,
            ProfileConstraints = new PlayerProfileViewConstraints()
            {
                ShowDisplayName = true
            },
            GetTitleData = true,
            GetUserData = true
        }
        };

        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginFailure);
    }

    //ȸ������
    public void RegisterBtn()
    {
        var request = new RegisterPlayFabUserRequest { Email = EmailInput.text, Password = PasswordInput.text , Username = UsernameInput.text};

        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnRegisterFailure);
    }




    void OnLoginSuccess(LoginResult result)
    {
        print("�α��� ����");
        UserId = result.PlayFabId;

        SceneManager.LoadScene("Main");
    }

    void OnLoginFailure(PlayFabError error)
    {
        print("�α��� ����");
    }

    void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        print("ȸ������ ����");
    }

    void OnRegisterFailure(PlayFabError error)
    {
        print("ȸ������ ����");
    }






}
