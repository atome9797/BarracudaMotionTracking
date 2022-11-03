using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TestView : MonoBehaviour, IView
{
    public TextMeshProUGUI FirstText { get; private set; }
    public TextMeshProUGUI SecondText { get; private set; }
    public TMP_InputField InputField { get; private set; }
    
    private void Awake()
    {
        FirstText = transform.Find("FirstText").GetComponent<TextMeshProUGUI>();
        Debug.Assert(FirstText != null);

        SecondText = transform.Find("SecondText").GetComponent<TextMeshProUGUI>();
        Debug.Assert(SecondText != null);

        InputField = transform.Find("InputField").GetComponent<TMP_InputField>();
        Debug.Assert(InputField != null);
    }
}
