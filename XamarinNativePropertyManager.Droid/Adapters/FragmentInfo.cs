using MvvmCross.Droid.Support.V4;

namespace XamarinNativePropertyManager.Droid.Adapters
{
    public class FragmentInfo
    {
        public string Title { get; set; }

        public MvxFragment Fragment { get; set; }

        public FragmentInfo(string title, MvxFragment fragment)
        {
            Title = title;
            Fragment = fragment;
        }
    }
}