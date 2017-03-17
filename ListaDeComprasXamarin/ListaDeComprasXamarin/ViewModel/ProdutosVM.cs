using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ListaDeComprasXamarin.Model.Entities;
using Xamarin.Forms;
using ListaDeComprasXamarin.Model.Services;

namespace ListaDeCompras.ViewModel
{
	public class ProdutosVM: ObservableBaseObject
	{
		public ObservableCollection<Produto> Produtos { get; set; }
		private AzureClient _client;
		public Command RefreshCommand { get; set; }
		public Command GenerateProdutosCommand { get; set; }
		public Command CleanLocalDataCommand
		{
			get;
			set;
		}
		private bool isBusy;
		public bool IsBusy
		{
			get { return isBusy; }
			set { isBusy = value; OnPropertyChanged(); }
		}


		public ProdutosVM()
		{
			RefreshCommand = new Command(() => Load());
			GenerateProdutosCommand = new Command(() => generateProdutos());
			CleanLocalDataCommand = new Command(() => cleanLocalData());
			Produtos = new ObservableCollection<Produto>();
			_client = new AzureClient();

		}

		async Task cleanLocalData()
		{
			await _client.CleanData();
		}

		async void generateProdutos()
		{
			if (IsBusy)
				return;

			IsBusy = true;
            string[] descricoes = { "Arroz", "Feijão", "Macarrão", "Farinha",
                                "Chocolate em Pó", "Leite", "Aveia", "Refrigerante", "Bombom"};
            string[] marcas = { "Nestlé", "Ceolin", "Quaker", "Parmalat", "Coca Cola" };

            Random rdn = new Random(DateTime.Now.Millisecond);
			for (int i = 0; i < 10; i++)
			{
				var produto = new Produto() { Descricao = $"{descricoes[rdn.Next(0, 8)]}", Marca1 = $"{marcas[rdn.Next(0, 4)]}", Quantidade1 = rdn.Next(1, 10).ToString()};
				_client.AddContact(produto);
			}

			IsBusy = false;
		}


		public async void Load()
		{
			var result = await _client.GetProdutos();

			Produtos.Clear();

			foreach (var item in result)
			{
				Produtos.Add(item);
			}
			IsBusy = false;
		}
	}
}
