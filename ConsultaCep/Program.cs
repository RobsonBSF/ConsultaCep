using ConsultaCep.Services;
using ConsultaCep.Views;

namespace ConsultaCep
{
    class Program
    {
        static async Task Main(string[] args)
        {
            ViaCepService service = new ViaCepService();
            
            await Menu.ExibirMenu(service);
        }
    }
}