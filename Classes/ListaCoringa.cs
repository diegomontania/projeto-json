using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Projeto.Json
{
    public class ListaCoringa
    {
        private List<NovaLista> _listaRetornoJson;

        //responsável por retornar tudo que vier do json
        private void LeArquivoJson(string arquivo)
        {
            //convertendo json
            string caminhoArquivo = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + @"\Jsons\" + arquivo;

            try
            {
                //lendo retorno e populando propriedade
                string textoJson = File.ReadAllText(caminhoArquivo);
                _listaRetornoJson = JsonConvert.DeserializeObject<List<NovaLista>>(textoJson);
            }
            catch (Exception)
            {
                Console.WriteLine("Arquivo para deserialização não foi encontrado! \n" +
                    "Verifique o caminho ou nome do arquivo e tente novamente!");
                throw;
            }
        }

        //Ao chamar um metodo para criar especificamente uma lista de um determinado 'tipo' (ex : acionistas),
        //o metodo deve ser responsavel por apenas trazer os resultados relacionados ao tipo solicitado.
        //passando como paramentro o arquivo onde estão as informações, nao havendo necessidade de passar novos parametros.
        public List<NovaLista> CriarListaDeAcionistas(string arquivo)
        {
            LeArquivoJson(arquivo);

            foreach (var item in _listaRetornoJson.ToList())
            {
                //se item atual não tiver o campo 'Acionista' como true, remova
                if (item.Acionista == null)
                {
                    _listaRetornoJson.Remove(item);
                }
            }

            Console.WriteLine("### Criando lista de Acionistas ###");

            return _listaRetornoJson;
        }

        public List<NovaLista> CriarListaDeAplicacoes(string arquivo)
        {
            LeArquivoJson(arquivo);

            foreach (var item in _listaRetornoJson.ToList())
            {
                if (!item.Aplicacao == null)
                {
                    _listaRetornoJson.Remove(item);
                }
            }

            Console.WriteLine("### Criando lista de aplicações ###");

            return _listaRetornoJson;
        }

        public List<NovaLista> CriarListaDeObjetos(string arquivo)
        {
            LeArquivoJson(arquivo);

            Console.WriteLine("### Criando lista de objetos ###");

            return _listaRetornoJson;
        }

        public void RetornaTodosElementos()
        {
            Console.WriteLine("Todos os elementos da lista: ");

            foreach (var item in _listaRetornoJson)
            {
                Console.WriteLine($"ID: {item.Id} Nome: {item.Nome}");
            }

            Console.WriteLine("----");
        }

        public void RetornaElementoPorID(int id)
        {
            var encontrado = false;

            foreach (var item in _listaRetornoJson)
            {
                if (item.Id == id)
                {
                    encontrado = true;
                    Console.WriteLine("Item retornado por Id: ");
                    Console.WriteLine($"ID: {item.Id} Nome: {item.Nome}");
                }
            }

            if (!encontrado)
            {
                Console.WriteLine($"O Id procurado '{id}', não foi encontrado");
            }

            Console.WriteLine("----");
        }

        public void RetornaElementoPorNome(string nome)
        {
            var encontrado = false;

            foreach (var item in _listaRetornoJson)
            {
                //testando nome procurado, utilizando 'to lower' para evitar caracteres maiusculos
                if (item.Nome.ToLower() == nome.ToLower())
                {
                    encontrado = true;
                    Console.WriteLine("Item retornado por Nome: ");
                    Console.WriteLine($"ID: {item.Id} Nome: {item.Nome}");
                }
            }

            if (!encontrado)
            {
                Console.WriteLine($"O elemento com o nome procurado '{nome}', não foi encontrado");
            }

            Console.WriteLine("----");
        }

        public void RetornaTotalElementos()
        {
            Console.WriteLine($"Contagem de elementos: ");
            Console.WriteLine(_listaRetornoJson.Count());

            Console.WriteLine("----");
        }
    }
}
