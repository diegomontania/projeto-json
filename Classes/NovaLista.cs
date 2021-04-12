namespace Projeto.Json
{
    //Foram criadas 4 propriedades para receber as informações de json.
    //encontrei um problema para deserializar o terceiro campo, pois o nome da propriedade no json,
    //mudava de acordo com resultado do elemento. Impossibilitando a criação de uma propriedade,
    //chamada "tipo" nesta classe.

    //A solução foi criar mais uma propriedade e definir as duas ultimas como "nullable".
    //assim, os elementos que forem retornados do json, irão preencher a propriedade
    //de acordo com o seu 'tipo', acionista ou aplicacao, deixando a propriedade que não possuir, vazia.

    //No caso do segundo arquivo json, os dois campos ficarão nulos.

    public class NovaLista
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public bool? Acionista { get; set; }

        public bool? Aplicacao { get; set; }
    }
}
