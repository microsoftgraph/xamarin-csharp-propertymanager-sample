using Android.OS;
using Android.Views;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Binding.Droid.Views;
using XamarinNativePropertyManager.ViewModels;
using Java.Lang;

namespace XamarinNativePropertyManager.Droid.Fragments
{
    public class FilesFragment : MvxFragment
    {
        private MvxListView _filesListView;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, 
            Bundle savedInstanceState)
        {
            this.EnsureBindingContextIsSet(savedInstanceState);
            return this.BindingInflate(Resource.Layout.FilesFragment, null);
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);

            // Get the group view model.
            var viewModel = ViewModel as GroupViewModel;
            viewModel.FilesChanged += OnFilesChanged;

            // Get the list view.
            _filesListView = (MvxListView)view.FindViewById(Resource.Id.files_list_view);
        }

        private void OnFilesChanged(GroupViewModel sender)
        {
            _filesListView.Post(new Runnable(() =>
            {
                _filesListView.SetSelection(sender.Files.Count - 1);
            }));
        }
    }
}