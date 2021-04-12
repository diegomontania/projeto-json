using System;

namespace Projeto.Json
{
    class Program
    {
        static void Main(string[] args)
        {
            //criando listas de acordo com seu 'tipo'
            var listaAcionistas = new ListaCoringa();
            listaAcionistas.CriarListaDeAcionistas("AcionistaOuAplicacao.json");
            listaAcionistas.RetornaTodosElementos();
            listaAcionistas.RetornaElementoPorID(341);
            listaAcionistas.RetornaElementoPorNome("Jose dos Santos");
            listaAcionistas.RetornaTotalElementos();

            var listaAplicacao = new ListaCoringa();
            listaAplicacao.CriarListaDeAplicacoes("AcionistaOuAplicacao.json");
            listaAplicacao.RetornaTodosElementos();
            listaAplicacao.RetornaElementoPorID(1);
            listaAplicacao.RetornaElementoPorNome("Banco do Brasil acao");
            listaAplicacao.RetornaTotalElementos();

            var listaObjeto = new ListaCoringa();
            listaObjeto.CriarListaDeObjetos("Objeto.json");
            listaObjeto.RetornaTodosElementos();
            listaObjeto.RetornaElementoPorID(1);
            listaObjeto.RetornaElementoPorNome("Notebook");
            listaObjeto.RetornaTotalElementos();

            Console.ReadLine();
        }
    }
}
