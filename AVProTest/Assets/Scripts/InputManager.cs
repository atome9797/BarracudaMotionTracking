using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{
    public void LoadScenePlay()
    {
        SceneManager.LoadScene("Play");
    }

    public void LoadSceneRecord()
    {
        SceneManager.LoadScene("SampleScene");
    }

}
