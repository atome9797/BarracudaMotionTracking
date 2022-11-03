using UniRx;
using UniRx.Triggers;
using UniRx.TMPro;

public sealed class TestViewPresenter : IPresenter
{
    private TestView _testView;
    private CompositeDisposable _compositeDisposable = new CompositeDisposable();

    public void OnInitialize(IView view)
    {
        _testView = view as TestView;
        _testView.FirstText.text = "";
        _testView.SecondText.text = "";

        InitializeRx();
    }
    public void OnRelease()
    {
        _testView = default;
        _compositeDisposable.Dispose();
    }

    private void InitializeRx()
    {
        _testView.InputField.OnValueChangedAsObservable()
                .Subscribe(ChangeText).AddTo(_compositeDisposable);
        

        Model.TestViewModel.TestText.Subscribe(ApplyToUi).AddTo(_compositeDisposable);
    }

    private void ChangeText(string text)
    {
        Model.TestViewModel.SetTestText(text);
    }

    private void ApplyToUi(string text)
    {
        _testView.FirstText.text = text;
        _testView.SecondText.text = text;
    }

}