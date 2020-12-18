using Microsoft.Extensions.DependencyInjection;

namespace WpfApp.ViewModel
{
    class ViewModelLocator
    {
        public MainViewModel MainViewModel => App.Services.GetRequiredService<MainViewModel>();
    }
}
