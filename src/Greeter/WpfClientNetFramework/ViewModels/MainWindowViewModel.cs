using Greet;
using Grpc.Net.Client;
using Prism.Commands;
using Prism.Mvvm;

namespace WpfClientNetFramework.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public string Text1 { get => _text1; set => SetProperty(ref _text1, value); }

        private string _text2;
        public string Text2
        {
            get { return _text2; }
            set { SetProperty(ref _text2, value); }
        }

        private string _text1 = "name";

        public MainWindowViewModel()
        {
            OnClickButton1 = new DelegateCommand(ClickButton1);
        }

        public void ClickButton1()
        {
            using (var channel = GrpcChannel.ForAddress("https://localhost:5001"))
            {
                var client = new Greeter.GreeterClient(channel);

                var reply = client.SayHelloAsync(new HelloRequest { Name = Text1 }).GetAwaiter().GetResult();
                Text2 = reply.Message;

            }
        }

        public DelegateCommand OnClickButton1 { get; private set; }
    }
}
