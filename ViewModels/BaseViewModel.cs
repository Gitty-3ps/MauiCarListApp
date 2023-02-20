using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CarListApp.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        string title;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotLoading))]
        bool isLoading;

        public bool IsNotLoading => !IsLoading;
    }
}