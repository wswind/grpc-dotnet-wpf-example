using WpfClientNetFramework.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;

namespace WpfClientNetFramework
{
    /// <summary>
    /// https://docs.microsoft.com/zh-cn/aspnet/core/grpc/netstandard?view=aspnetcore-5.0#net-framework
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}
