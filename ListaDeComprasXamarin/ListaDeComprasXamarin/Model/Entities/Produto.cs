using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

namespace ListaDeComprasXamarin.Model.Entities
{
    [DataTable("Produtos")]
    public class Produto
    {
        [JsonProperty("IdProduto")]
        private string id;

        [JsonProperty("descricao")]
        private string descricao;

        [JsonProperty("marca")]
        private string Marca;

        [JsonProperty("quantidade")]
        private string Quantidade;

        [Version]
        private string version;

        
        public string Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        [JsonIgnore]
        public string Descricao
        {
            get
            {
                return descricao;
            }

            set
            {
                descricao = value;
            }
        }

        [JsonIgnore]
        public string Marca1
        {
            get
            {
                return Marca;
            }

            set
            {
                Marca = value;
            }
        }

        [JsonIgnore]
        public string Quantidade1
        {
            get
            {
                return Quantidade;
            }

            set
            {
                Quantidade = value;
            }
        }

        [JsonIgnore]
        public string Version
        {
            get
            {
                return version;
            }

            set
            {
                version = value;
            }
        }
    }
}
