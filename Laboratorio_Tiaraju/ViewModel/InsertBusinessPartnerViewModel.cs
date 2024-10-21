using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Laboratorio_Tiaraju.Helpers;
using Laboratorio_Tiaraju.Model.Entities;
using Laboratorio_Tiaraju.Repositories.Implementations.WriteServices.WriteBPRepository;

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
        async void AdicionarParceiroNegocio()
        {
            string fullName = RetiraAcento.RetirarAcentuacao(Nome);

            BPFiscalTaxIDCollection bpFiscal = new BPFiscalTaxIDCollection("", "", Cpf);

            BPAddress bPAddress = new BPAddress(Rua, Bairro, Cep, Cidade, Uf, Numero);

            bpAddresses.Add(bPAddress);

            bpFiscalCollection.Add(bpFiscal);

            if(bpAddresses.Count > 1)
            {
                bpAddresses.RemoveAt(1);
            }

            if(bpFiscalCollection.Count > 1)
            {
                bpFiscalCollection.RemoveAt(1);    
            }

            BusinessPartner businessPartner = new BusinessPartner(fullName, Telefone, Email, bpFiscalCollection, bpAddresses);

            bool insereBP = await bpRepository.InsertBusinessPartnerAsync(businessPartner);

            if (insereBP)
            {
                var newtoast = Toast.Make("Parceiro de Negócio Cadastrado Com Sucesso", CommunityToolkit.Maui.Core.ToastDuration.Long);

                await newtoast.Show();
            }
        }
    }
}
