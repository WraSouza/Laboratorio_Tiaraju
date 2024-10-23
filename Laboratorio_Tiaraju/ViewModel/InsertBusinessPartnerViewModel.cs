using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Laboratorio_Tiaraju.Helpers;
using Laboratorio_Tiaraju.Model.Entities;
using Laboratorio_Tiaraju.Repositories.Implementations.WriteServices.WriteBPRepository;
using Laboratorio_Tiaraju.Validators;
using System.Text;

namespace Laboratorio_Tiaraju.ViewModel
{
    public partial class InsertBusinessPartnerViewModel(BPRepository bpRepository) : ObservableObject
    {
        [ObservableProperty]
        string nome = string.Empty;

        [ObservableProperty]
        string telefone = string.Empty;

        [ObservableProperty]
        string email = string.Empty;

        [ObservableProperty]
        string cpf = string.Empty;

        [ObservableProperty]
        string rua = string.Empty;

        [ObservableProperty]
        string numero = string.Empty;

        [ObservableProperty]
        string uf = string.Empty;

        [ObservableProperty]
        string cidade = string.Empty;

        [ObservableProperty]
        string cep = string.Empty;

        [ObservableProperty]
        string bairro = string.Empty;

        private List<BPAddress> bpAddresses = new();
        private List<BPFiscalTaxIDCollection> bpFiscalCollection = new();

        [RelayCommand]
        async Task AdicionarParceiroNegocio()
        {
            string fullName = RetiraAcento.RetirarAcentuacao(Nome);

            BPFiscalTaxIDCollection bpFiscal = new BPFiscalTaxIDCollection("", "", Cpf);

            BPAddress bPAddress = new BPAddress(Rua, Bairro, Cep, Cidade.ToUpper(), Uf.ToUpper(), Numero);

            bpAddresses.Add(bPAddress);

            bpFiscalCollection.Add(bpFiscal);

            BusinessPartner businessPartner = new BusinessPartner(fullName.ToUpper(), Telefone, Email, bpFiscalCollection, bpAddresses);

            var contract = new BusinessPartnerContract(businessPartner);

            if (!contract.IsValid)
            {
                var messages = contract.Notifications.Select(x => x.Message);

                var sb = new StringBuilder();

                foreach (var message in messages)
                    sb.Append($"{message}\n");

                await Shell.Current.DisplayAlert("Atenção", sb.ToString(), "OK");

                return;
            }

            bool answer = await Shell.Current.DisplayAlert("", "Gostaria de Cadastrar o Parceiro de Negócios Informado?", "Sim", "Não");

            if(answer)
            {
                bool insereBP = await bpRepository.InsertBusinessPartnerAsync(businessPartner);

                if (insereBP)
                {
                    var newtoast = Toast.Make("Parceiro de Negócio Cadastrado Com Sucesso", CommunityToolkit.Maui.Core.ToastDuration.Long);

                    await newtoast.Show();

                    return;
                }

                await Shell.Current.DisplayAlert("", "CPF Informado Já Possui Cadastro.", "OK");
            }

           
        }
    }
}
