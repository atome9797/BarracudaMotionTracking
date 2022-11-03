using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestViewController : ViewController
{
    private TestView _testView;
    private TestViewPresenter _testViewPresenter = new TestViewPresenter();

    private void Awake()
    {
        _testView = transform.Find("TestView").GetComponent<TestView>();        
        Debug.Assert(_testView != null);
    }

    private void Start()
    {
        _testViewPresenter.OnInitialize(_testView);
    }

    private void OnDestroy()
    {
        _testViewPresenter.OnRelease();    
    }
}
