using Android.Support.V4.App;
using Java.Lang;
using MvvmCross.Droid.Support.V4;
using XamarinNativePropertyManager.Droid.Fragments;
using XamarinNativePropertyManager.Droid.Views;
using System.Linq;

namespace XamarinNativePropertyManager.Droid.Adapters
{
    public class GroupViewFragmentsAdapter : MvxCachingFragmentPagerAdapter
    {
        private readonly GroupView _groupView;
        private readonly FragmentInfo[] _fragmentInfos;

        public override int Count
        {
            get { return _fragmentInfos.Length; }
        }

        public GroupViewFragmentsAdapter(GroupView groupView)
            : base(groupView.SupportFragmentManager)
        {
            _groupView = groupView;
            _fragmentInfos = new FragmentInfo[]
            {
                new FragmentInfo("Details", new DetailsFragment()),
                new FragmentInfo("Conversations", new ConversationsFragment()),
                new FragmentInfo("Files", new FilesFragment()),
                new FragmentInfo("Tasks", new TasksFragment()),
            };

            // Set view model for each fragment.
            foreach (var fragment in _fragmentInfos.Select(i => i.Fragment))
            {
                fragment.ViewModel = groupView.ViewModel;
            }
        }

        public override Fragment GetItem(int position, Fragment.SavedState fragmentSavedState = null)
        {
            return _fragmentInfos[position].Fragment;
        }

        public override ICharSequence GetPageTitleFormatted(int position)
        {
            return new String(_fragmentInfos[position].Title);
        }
    }
}