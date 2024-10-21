using CommunityToolkit.Mvvm.ComponentModel;
using Laboratorio_Tiaraju.Model.Entities;
using Laboratorio_Tiaraju.Repositories.Implementations.ReadServices.ReadItemsSAPServices;
using Laboratorio_Tiaraju.Repositories.Interfaces.IReadServices.IReadItemsServices;
using System.Collections.ObjectModel;

namespace Laboratorio_Tiaraju.ViewModel
{
    public partial class ItemSAPViewModel : ObservableObject
    {
        public ObservableCollection<Value> ItemsSAP { get; set; } = new ObservableCollection<Value>();
        
        bool isBusy = false;

        private readonly IRItemSAPServices _services;

        public ItemSAPViewModel(IRItemSAPServices services)
        {
            _services = services;

            GetAllItemsSAPAsync();
        }


        public async Task GetAllItemsSAPAsync()
        {
            isBusy = true;

            ItemsSAP.Clear();

            var newItems = await _services.GetAllItemsAsync();

            for(int i = 0; i < newItems.value?.Count; i++)
            {
                if(newItems.value[i].ItemName != "AMOSTRA PARA ANÁLISE")
                {
                    Value newItem = new Value(newItems.value[i].ItemCode, newItems.value[i].ItemName, newItems.value[i].BarCode, newItems.value[i].QuantityOnStock);
                    ItemsSAP.Add(newItem);
                }
               
            }

            isBusy = false;

            return;
        }
       
    }
}
