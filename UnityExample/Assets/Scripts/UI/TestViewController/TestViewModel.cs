using UniRx;

namespace Model
{
    public static class TestViewModel
    {
        public static readonly StringReactiveProperty TestText = new StringReactiveProperty();
        public static void SetTestText(string text)
        {
            TestText.Value = text;
        }
    }
}
