using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
using System.Collections.ObjectModel;
using ListaDeComprasXamarin.Model.Entities;

namespace ListaDeComprasXamarin.Model.Services
{
    public class AzureClient
    {
        private IMobileServiceClient _client;
		private IMobileServiceSyncTable<Produto> _table;
		const string dbPath = "produtoDb";
		private const string serviceUri= "http://listadecomprasxamarin.azurewebsites.net";
        
		public AzureClient()
        {
			_client = new MobileServiceClient(serviceUri);
			var store = new MobileServiceSQLiteStore(dbPath);
            store.DefineTable<Produto>();

			_client.SyncContext.InitializeAsync(store);
			_table = _client.GetSyncTable<Produto>();
        }

        public async Task<IEnumerable<Produto>> GetProdutos()
        {
            var empty = new Produto[0];
            try
            {
				if (Plugin.Connectivity.CrossConnectivity.Current.IsConnected)
					await SyncAsync();

                return await _table.ToEnumerableAsync();
            }
            catch (Exception ex)
            {
                return empty;
            }
        }

		public async void AddContact(Produto produto) 
		{
			await _table.InsertAsync(produto);

		}

		public async Task SyncAsync() 
		{ 
			ReadOnlyCollection<MobileServiceTableOperationError> syncErrors = null;
			try
			{
				await _client.SyncContext.PushAsync();

				await _table.PullAsync("allProdutos", _table.CreateQuery());
			}
			catch (MobileServicePushFailedException pushEx)
			{
				if (pushEx.PushResult != null)
					syncErrors = pushEx.PushResult.Errors;
			}
		}


		public async Task CleanData() 
		{
			await _table.PurgeAsync("allProdutos", _table.CreateQuery(), new System.Threading.CancellationToken());
		}

    }
}
