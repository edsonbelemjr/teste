![Picsel](https://i.imgur.com/yfb6p5q.jpeg)

# Sobre a API e este documento

É um documento que mostra de forma simples como se comunicar com a API do WebAPP da Picsel. Todos os exemplos usam o CURL padrão e foram testados em um terminal Bash/Linux comum.

Existem operações de POST e GET, sendo que o login precisa ser feito via POST bem como a
conclusão da sessão. A sessão fechará automaticamente depois de um período de inatividade.

Apenas após o login será possível executar as demais requisições/operações na API, a partir do login autorizado a API aceitará as requisições/operações apenas com as informações adequadas da sessão, fornecidas com o sucesso do login.

# Middleware - MAPA e SUSEP

Esse projeto é responsável por fazer a integração da API desenvolvida pela Ponderatti, que irá consultar a base de dados da Picsel retornando os campos necessários para o envio dos dados para as APIs do MAPA e da SUSEP. A arquitetura será provisionada usando o recurso LAMBDA AWS.

# Validação

As validações dos campos são feitas após entre a consulta da API de entrada e o envio para as APIs. A validação é feita a partir do jsonschema utilizando a biblioteca do python jsonschema. Para cada caminho das APIs foram feitos jsonschemas que definem as regras de cada campo, e utilizando a função validate da biblioteca jsonschema

# Arquitetura

## Mapa Apólice e Sinistro
![Arquitetura](https://i.imgur.com/et45dSU.jpeg)

## Susep Sandbox
![](https://i.imgur.com/9KG7Oxs.jpeg)

## Enviar Proposta
![](https://i.imgur.com/qFsgpHG.jpeg)





# Payloads SUSEP - Sandbox Regulatório
## susep-auth-token-response
```
{
    "access_token":"eyJhbGciOiJSUzI1NiIsImtpZCI6Ijc0YTc2ZTVlODRhNjg2ZWIyZThhYzU3NmJmNDlkMjA5IiwidHlwIjoiSldUIn0.eyJuYmYiOjE1ODgyNTQ4NzUsImV4cCI6MTU4ODI1ODQ3NSwiaXNzIjoiaHR0cDovL2hvbW9sb2cyLnN1c2VwLmdvdi5ici9zYWZlL2F1dGVudGljYWNhbyIsImF1ZCI6WyJodHRwOi8vaG9tb2xvZzIuc3VzZXAuZ292LmJyL3NhZmUvYXV0ZW50aWNhY2FvL3Jlc291cmNlcyIsInNyZC53ZWIiXSwiY2xpZW50X2lkIjoic3JkLndlYiIsInN1YiI6IjNhZDkyMDIzLTBhNGMtNDdiNC1iYzIyLTEwOGRmNTM5ZDIzZSIsImF1dGhfdGltZSI6MTU4ODI1NDg3NSwiaWRwIjoibG9jYWwiLCJuYW1lIjoiVGVzdGUgU3VzZXAiLCJlbnRpZGFkZUlkIjoiMiIsImp0aSI6ImQxMGMwMmRkNGQyOTJlYzFhMDhmNzZlNDU1NDk2MTVmIiwic2NvcGUiOlsic3JkLndlYiJdLCJhbXIiOlsicHdkIl19.YdADx6qEGEjL6EvdHaeBOvo0PWjKqhu9tyIzYfUDqN2iRgOUFbW7DAfXmWl5Yb4W_nt5kPi1lSxug5O5HBFT27YrjJOyu3NkXWq9NXGzznZUuJj4WB6FtTRd82PenvbRdPo0J_4vz_eaHMk5Nqe9AuiVuDhaYxV-ocYHl9HHy0-a3F0trIm3ZfwnnVmH4ILV5Wpc6Jkr7-jZWDV78z0BdUcNior6LVLZFKAvcSBvw57Agw8GcjKwrKJQA7LRSjjUmHxCLlJX0I0T2v3UaUzXIkMgRbc O-OaYuuavG5CJInLDn7XejrYJGG8tYiw556ARAUeYtEDJDbyIYW036-CGg",
     "expires_in": 3600, 
     "token_type": "Bearer" 
}
```

## susep-sandbox-sinistropendente
```
{
    "cnpj": "12345678901234",
  	"sinistrosPendentes": [
      {
        "mesReferencia": 202106,
		"ramo": "002",
		"numeroSinistro": "ABCDEF-123456",
		"numeroApolice": "APOLICE-PREMIO-01",
		"dataOcorrenciaSinistro": "2021-06-01",
		"dataComunicacaoSinistro": "2021-06-02",
		"dataRegistroInicialSinistro": "2021-06-03",
		"valorSinistroPendente": 1111.02,
		"valorSinistroPendenteRetido": 1111.01
      },
	  {
        "mesReferencia": 202106,
		"ramo": "029",
		"numeroSinistro": "GHIJK-78901",
		"numeroApolice": "APOLICE-PREMIO-02",
		"dataOcorrenciaSinistro": "2021-06-11",
		"dataComunicacaoSinistro": "2021-06-11",
		"dataRegistroInicialSinistro": "2021-06-13",
		"valorSinistroPendente": 2222.02,
		"valorSinistroPendenteRetido": 2222.01
      },
	  {
        "mesReferencia": 202106,
		"ramo": "081",
		"numeroSinistro": "LMNOP-234567",
		"numeroApolice": "APOLICE-PREMIO-03",
		"dataOcorrenciaSinistro": "2021-06-21",
		"dataComunicacaoSinistro": "2021-06-22",
		"dataRegistroInicialSinistro": "2021-06-22",
		"valorSinistroPendente": 3333.02,
		"valorSinistroPendenteRetido": 3333.01
      }]
}
```

## susep-sandbox-sinistro
```
{
    "cnpj": "12345678901234",
  	"sinistros": [
      {
        "dataMovimento": "2020-04-11 00:01:01",
        "numeroSinistro": "ABCDEF-123456",
        "numeroApolice": "APOLICE-PREMIO-01",
        "maxima": 20000.00,
        "identificacaoSegurado": "72035596000176",
        "identificacaoBeneficiario": "72035596000176",
        "identificacaoCobertura": "005",
        "identificacaoObjetoSinistrado": "002",
        "tipoSinistro": "01",
        "tipoMovimento": "01",
        "valorMovimento": 1200.50,
        "valorMovimentoRetido": 1200.25,
        "dataOcorrenciaSinistro": "2020-04-11",
        "dataComunicacaoSinistro": "2020-04-12",
		    "dataRegistroInicialSinistro": "2020-04-12",
        "statusSinistro": "02",
        "justificativaNegativa": "01"
      },
	  {
        "dataMovimento": "2020-04-21 00:01:02",
        "numeroSinistro": "GHIJK-78901",
        "numeroApolice": "APOLICE-PREMIO-02",
        "maxima": 15000.00,
        "identificacaoSegurado": "74764252007",
        "identificacaoBeneficiario": "74764252007",
        "identificacaoCobertura": "012",
        "identificacaoObjetoSinistrado": "999",
        "tipoSinistro": "02",
        "tipoMovimento": "06",
        "valorMovimento": 10500.25,
        "valorMovimentoRetido": 100.25,
        "dataOcorrenciaSinistro": "2020-04-21",
        "dataComunicacaoSinistro": "2020-04-22",
		"dataRegistroInicialSinistro": "2020-04-22",
        "statusSinistro": "01",
        "justificativaNegativa": null
      }]
}
```

## susep-sandbox-premio 
```
{
  "cnpj": "12345678901234",
  "premios": [
    {
      "numeroApolice": "APOLICE-PREMIO-01",
      "naturezaMovimento": "01",
      "tipoMovimento": "01",
      "iof": 50,
      "valorCorretagem": 500,
      "dataInicioApolice": "2020-04-10 00:00:06",
      "dataFimApolice": "2020-06-10 00:00:05",
      "dataInicioCobertura": "2020-04-11 00:00:05",
      "dataFimCobertura": "2020-05-10 00:00:05",
      "identificacaoSegurado": "83992703002",
      "identificacaoBeneficiario": "83992703002",
      "seguroIntermitente": "01",
      "dataMovimento": "2020-02-10 00:01:01",
	  "coberturas": [
        {
          "identificacaoCobertura": "005",
          "ramo": "002",
          "maxima": 19999.99,
          "identificacaoObjetoSegurado": "002",
          "premioBruto": 10000.00,
          "premioComercial": 50.05,
          "premioRetido": 120
        },
        {
          "identificacaoCobertura": "004",
          "ramo": "002",
          "maxima": 19999.99,
          "identificacaoObjetoSegurado": "003",
          "premioBruto": 20000.0,
          "premioComercial": 60.05,
          "premioRetido": 200
        }
      ]
    },
	{
      "numeroApolice": "APOLICE-PREMIO-02",
      "naturezaMovimento": "01",
      "tipoMovimento": "01",
      "iof": 50.10,
      "valorCorretagem": 500.00,
      "dataInicioApolice": "2020-04-20 00:00:06",
      "dataFimApolice": "2020-06-20 00:00:05",
      "dataInicioCobertura": "2020-04-21 00:00:05",
      "dataFimCobertura": "2020-05-20 00:00:05",
      "identificacaoSegurado": "83992703002",
      "identificacaoBeneficiario": "83992703002",
      "seguroIntermitente": "02",
      "dataMovimento": "2020-02-10 00:01:02",
	  "coberturas": [
        {
          "identificacaoCobertura": "002",
          "ramo": "014",
          "maxima": 24999.99,
          "identificacaoObjetoSegurado": "005",
          "premioBruto": 10000.0,
          "premioComercial": 50.05,
          "premioRetido": 122
        },
        {
          "identificacaoCobertura": "003",
          "ramo": "001",
          "maxima": 34999.99,
          "identificacaoObjetoSegurado": "001",
          "premioBruto": 20000.0,
          "premioComercial": 60.05,
          "premioRetido": 201
        }
      ]
    }	
  ]
}
```

## susep-sandbox-contabil-1sem
```
{
	"cnpj": "12345678901234",
	"dadosContabeis": [{
		"mesReferencia": 202101,
		"premioEmitido": 10000.00, 
		"quantidadeApolicesEmitidas": 10,
		"quantidadeRiscosVigentes": 11,
		"quantidadeReclamacoes": 12,
		"quantidadeSinistrosAvisados": 13,
		"quantidadeSinistrosPagos": 14,
		"ativosFinanceiros": 1111.01,
		"intangiveis": 1111.02,
		"demaisAtivos": 1111.03,
		"provisaoPremiosNaoGanhos": 1111.04,
		"provisaoSinistrosLiquidar": 1111.05,
		"provisaoSinistrosOcorridosNaoAvisados": 1111.06,
		"provisaoValoresRegularizar": 1111.07,
		"outrasProvisoesTecnicas": 1111.08,
		"valorTotalSinistrosPagosMes": 1111.09,
		"demaisPassivos": 1111.10,
		"valorPatrimonioLiquido": 1111.11,
		"cmr": 21.82,
		"estruturaSimplificada": true,
		"valorTotalPremiosEmitidosRetidos": 111,
		"valorAtivoResseguroProvisoesTecnicas": 1111.13,
		"valorAtivoResseguroRedutor": 1111.14,
		"valorTotalSinistrosAvisados": 1111.15,
		"valorTotalSinistrosAvisadosRetidos": 11
	}]
}
```

## susep-sandbox-reclamacao
```
{
	"cnpj": "12345678901234",
	"reclamacoes": [
	{
		"dataMovimento": "2020-04-11 00:01:03",
		"identificacaoCobertura": "011",
		"identificacaoObjetoSegurado": "007",
		"dataReclamacao": "2020-04-11",
		"tipoReclamacao": "04",
		"statusReclamacao": "02",
		"identificacaoSegurado": "04260283090",
		"identificacaoReclamante": "04260283090",
		"numeroApolice": "APOLICE-PREMIO-01"
	},
	{
		"dataMovimento": "2020-04-21 00:01:04",
		"identificacaoCobertura": "002",
		"identificacaoObjetoSegurado": "002",
		"dataReclamacao": "2020-04-22",
		"tipoReclamacao": "07",
		"statusReclamacao": "01",
		"identificacaoSegurado": "32419859000126",
		"identificacaoReclamante": "32419859000126",
		"numeroApolice": "APOLICE-PREMIO-02"
	}
	]
}
```






# Payloads MAPA

## Picsel - MAPA - payload - 2.2 - Consultar Culturas Subvencionáveis
```
{
    "cdAtiviadeBacen": 11111111111111,                            //Código da Cultura no Banco Central. Tamanho: 14. Formato: Numerico.
    "nmCulturaSubvencao": "Nome da cultura01",                    //Nome da Cultura subvenção (Descrição da atividade BACEN). Tamanho: 200. Formato: AlfaNumerico
    "dsTipoLavoura": "Descricao da cultura subvencao",            //Descrição do tipo da lavoura cadastrada no SISSER. Formato: Alfa. P-Permanente, T-Temporária, O-Outros
    "dsGrupoCultura": "Descricao dos tipos de grupo de cultura",  //Descrição dos tipos de grupo de cultura. Tamanho: 20. Formato: AlfaNumerico
    "microregiao": [
        {
            "sgUF": "SP",                                         //Unidade Federativa da Microrregião. Tamanho: 2. Formato: Alfa
            "nmMicroregiao": "Microrregião",                      //Microrregião vinculada a cultura. Tamanho: 100. Formato: Alfa.
            "peSubvencao": 50                                     //Percentual vinculado a cultura. Tamanho: 3. Formato: Numerico
        }
    ]
}
```

## Picsel - MAPA - payload - 2.3 - Consultar Covertura-Eventos de Sinistro
Não possue parâmetros

## Picsel - MAPA - payload - 2.4 - Consultar Classificacao do Produto
```
//Apenas um dos parâmetros é obrigatório
{
    "cdClassificacaoProduto": 1111,                     //Código de classificação do produto. Tamanho: 4. Formato: Numerico.
    "nmClassificacaoProduto": "Classificacao Produto"   //Nome da classificação do produto. Tamanho: 20. Formato: Alfa.
}
```

## Picsel - MAPA - payload - 2.5 - Consultar Limite Financeiro do Segurado
```
{
    "nrCpfCnpjSegurado": 11111111111111,                //CPF ou CNPJ do segurado. Tamanho: 14(CNPJ) ou 11(CPF). Formato: Numerico.
    "anPeriodoExercicio": 2022,                         //Ano do período de exercício. Tamanho: 4. Formato: Numerico.
    "limiteSegurado": [
        {
            "dsModalidade": "Descricao da modalidade",  //Descrição da modalidade. Tamanho: 40. Formato: AlfaNumerico
            "vlSaldoComprometido": "10000,00",          //Valor do saldo comprometido. Tamanho: 10. Decimal: 2. Formato: Numerico.
            "vlSaldoDisponivel": "1000000,00"           //Valor do saldo disponível. Tamanho: 10. Decimal: 2. Formato: Numerico.
        }
    ]
}
```

## Picsel - MAPA - payload - 2.6 - Consultar Programa
Não possue parâmetros

## Picsel - MAPA - payload - 2.8 - Enviar Proposta
```
{
    "nrProposta": "Proposta01",                                     //Número da proposta. Tamanho: 20. Formato: AlfaNumerico.
    "dtProposta": "20/01/2022",                                     //Data da proposta. Tamanho:10. Formato: dd/MM/yyyy
    "dtInicioVigencia": "10/01/2022",                               //Data início da vigência do seguro. Tamanho: 10. Formato: dd/MM/yyyy
    "dtFimVigencia": "20/06/2022",                                  //Data término da vigência do seguro. Tamanho: 10. Formato: dd/MM/yyyy
    "nrProcessoSusep": 11111111111111111,                           //Número do processo SUSEP. Tamanho: 17. Formato: Numerico.
    "nmSegurado": "Segurado01",                                     //Nome do segurado. Tamanho: 100. Formato: AlfaNumerico.
    "nrCpfCnpjSegurado": 11111111111111,                            //CPF ou CNPJ do segurado. Tamanho: 14(CNPJ) ou 11(CPF). Formato: Numerico.
    "nrTelefoneSegurado": 11111111111,                              //Número do telefone do segurado. Tamamho: 11. Formato: Numerico.
    "nrCepSegurado": 11111111,                                      //Número do CEP do segurado
    "txComplementoEnderecoSegurado": "Proximo ao xxxxxx",           //Complemento do endereço do segurado. Tamanho: 50. Formato: AlfaNumerico.
    "nrComplementoSegurado": "Segurado01",                          //Número do complemento do endereço do segurado. Tamanho:10. Formato: AlfaNumerico.
    "nmPropriedade": "Propriedade01",                               //Nome da propriedade. Tamanho: 60. Formato: AlfaNumerico.
    "nrCepPropriedade": 11111111,                                   //CEP da propriedade. Tamanho: 8. Formato: Numerico.
    "txComplementoEnderecoPropriedade": "Descricao complemento",    //Descrição do complemento da propriedade. Tamanho: 50. Formato: AlfaNumerico.
    "nrComplementoPropriedade": "Complemento01",                    //Número do complemento da propriedade. Tamanho: 10. Formato: AlfaNumerico.
    "csFormatoCoordenada": "D",                                     //Formato das coordenadas da propriedade. Tamanho: 2. Formato: Caractere. Dominio: D-Decimal, G-Grau.
    "nrDecimalLatitude": "50,232345",                               //Número em decimal da latitude da propriedade. Tamanho: 30. Formato: Numerico. Dominio: Até - 70,056449833945
    "nrDecimalLongitude":"50,232345",                               //Número em decimal da longitude da propriedade. Tamanho: 30. Formato: Numerico. Dominio: Até - 70,056449833945
    "nrGrauLatitude": 30,                                           //Número em grau da latitude da propriedade. Tamanho: 2. Formato: Numerico. Dominio: S=0 a 33, N=0 a 5.
    "nrMinutoLatitude": 50,                                         //Número em minuto da latitude da propriedade. Tamanho: 2. Formato: Numerico. Dominio: 0 a 59.
    "nrSegundoLatitude": 50,                                        //Número em segundo da latitude da propriedade. Tamanho: 2. Formato: Numerico. Dominio: 0 a 59.
    "csOrientacaoLatitude": "S",                                    //Orientação da latitude da propriedade. Tamanho: 1.Formato: Caractere. Dominio: S-Sul, N-Norte.
    "nrGrauLongitude": 40,                                          //Número em grau da longitude da propriedade. Tamanho: 2. Formato: Numerico. Dominio: W=33 a 73.
    "nrMinutoLongitude": 50,                                        //Número em minuto da longitude da propriedade. Tamanho: 2.Formato: Numerico. Dominio: 0 a 59.
    "nrSegundoLongitude": 50,                                       //Número em segundo da longitude da propriedade. Tamanho: 2. Formato: Numerico. Dominio: 0 a 59.
    "csOrientacaoLongitude": "E",                                   //Orientação da longitude da propriedade. Tamanho: 1. Formato: Caractere. Dominio: E-Leste, W-Oeste. 
    "cdAtividadeBacen": 11111111111111,                             //Código da cultura emitido pelo BACEN. Tamanho: 14. Formato: Numerico.
    "nrAreaTotal": "1562,23",                                       //Número da área total segurada. Tamanho: 9. Decimal: 2. Formato: Numerico.
    "nrPe": 1111111,                                                //Número de pés. Tamanho: 7. Formato: Numerico.
    "nrVolume": "45645,23",                                         //Número de volume. Tamanho: 9. Decimal: 2. Formato: Numerico.
    "nrProdutividadeSegurada": "4561231,12",                        //Número de produtividade a ser segurada(kg/ha). Tamanho: 12. Decimal: 2. Formato: Numerico.
    "nrProdutividadeEstimada": "1231312,12",                        //Número de produtividade estimada(kg/ha). Tamanho: 12. Decimal: 2. Formato: Numerico.
    "nrAnimal": 1520,                                               //Número de animais. Tamanho: 5. Formato: Numerico.
    "vlLimiteGarantia": "1231456,12",                               //Valor do limite de garantia(LMGA). Tamanho: 14. Decimal: 2. Formato: Numerico.
    "vlPremio": "123131231,12",                                     //Valor do prêmio líquido. Tamanho: 14. Decimal: 2. Formato: Numerico.
    "vlSubvencaoFederal": "1564564,12",                             //Valor da subvenção federal. Tamanho: 14. Decimal: 2. Formato: Numerico.
    "peNivelCobertura": 50,                                         //Informa a porcentagem do nível de cobertura. Tamanho: 2. Formato: Numerico.
    "cdClassificacaoProduto": 40,                                   //Código da classificação do produto. Tamanho: 2. Formato: Numerico.
    "programas": {
        "programa": [{
            "idProgramaSubvencao": 120                              //Identificador do programa subvenção. Tamanho: 3. Formato: Numerico.
        }]
    },
    "unidadesSeguradas": {
        "itensUnidadeSegurada": [{
            "nrArea": "45621,12",                                   //Área - área da unidade segurada. Tamanho: 9. Decimal: 2. Formato: Numerico.
            "coberturas": {
                "cobertura": [{
                    "cdEventoCobertura": 120,                       //Cobertura - Tipo de cobertura garantida pela proposta. Tamanho: 3. Formato: Numerico.
                    "peFranquia": 50,                               //Franquia - Percentual da Franquia. Tamanho: 2. Formato: Numerico.
                    "vlLimiteMaximoIndenizacao": "123123112,21"     //LMI - Limite máximo de Indenização. Tamamho: 14. Decimal: 2. Formato: Numerico.
                }],
                "areasSeguradas": {
                    "coordenadasAreaSegurada": [
                        "coordenada": [
                            "nrDecimalLatitude":"-70,056449833945", //Número em decimal da latitude da propriedade. Tamanho: 30. Formato: Numerico.
                            "nrDecimalLongitude":"-70,056449833945",//Número em decimal da longitude da propriedade. Tamanho: 30. Formato: Numerico.                
                            "csOrientacaoLatitude": "S",            //Orientação da latitude da propriedade. Tamanho: 1.Formato: Caractere. Dominio: S-Sul, N-Norte.
                            "nrGrauLatitude": 30,                   //Número em grau da latitude da propriedade. Tamanho: 2. Formato: Numerico. Dominio: S=0 a 33, N=0 a 5.
                            "nrMinutoLatitude": 50,                 //Número em minuto da latitude da propriedade. Tamanho: 2. Formato: Numerico. Dominio: 0 a 59.v
                            "nrSegundoLatitude": 50,                //Número em segundo da latitude da propriedade. Tamanho: 2. Formato: Numerico. Dominio: 0 a 59.
                            "csOrientacaoLongitude": "E",           //Orientação da longitude da propriedade. Tamanho: 1. Formato: Caractere. Dominio: E-Leste, W-Oeste.
                            "nrGrauLongitude": 40,                  //Número em grau da longitude da propriedade. Tamanho: 2. Formato: Numerico. Dominio: W=33 a 73.
                            "nrMinutoLongitude": 50,                //Número em minuto da longitude da propriedade. Tamanho: 2.Formato: Numerico. Dominio: 0 a 59.
                            "nrSegundoLongitude": 50                //Número em segundo da longitude da propriedade. Tamanho: 2. Formato: Numerico. Dominio: 0 a 59.
                        ]
                    ]
                }
            }
        ]}
    }
}
```

## Picsel - MAPA - payload - 2.9 - Consultar Proposta
```
//É necessário passar apenas o "cdProposta" ou o "nrCpfCnpjSegurado" OU passar a "dtInicio" e "dtFim"
{
    "cdProposta": 111111111,             //Código da proposta gerado pelo MAPA. Tamanho: 9. Formato: Numerico.
    "nrCpfCnpjSegurado": 11111111111111, //CPF ou CNPJ do segurado. Tamanho: 14(CNPJ) ou 11(CPF). Formato: Numerico.
    "dtInicio": "20/01/2021",            //Data início do período de envio da proposta. Tamanho: 10. Formato: dd/MM/yyyy.
    "dtFim": "20/01/2022"                //Data fim do período de envio da proposta. Tamanho: 10. Formato: dd/MM/yyyy.
}
```

## Picsel - MAPA - payload - 2.10 - Alterar Proposta
```
{
    "cdProposta": "Proposta01",                                     //Código da proposta gerado pelo MAPA. Tamanho: 9. Formato: Numerico.
    "dtProposta": "20/01/2022",                                     //Data da proposta. Tamanho:10. Formato: dd/MM/yyyy.
    "dtInicioVigencia": "10/01/2022",                               //Data início da vigência do seguro. Tamanho: 10. Formato: dd/MM/yyyy.
    "dtFimVigencia": "20/06/2022",                                  //Data término da vigência do seguro. Tamanho: 10. Formato: dd/MM/yyyy.
    "nrProcessoSusep": 11111111111111111,                           //Número do processo SUSEP. Tamanho: 17. Formato: Numerico.
    "nmSegurado": "Segurado01",                                     //Nome do segurado. Tamanho: 100. Formato: AlfaNumerico.
    "nrTelefoneSegurado": 11111111111,                              //Número do telefone do segurado. Tamamho: 11. Formato: Numerico.
    "nrCepSegurado": 11111111,                                      //Número do CEP do segurado
    "txComplementoEnderecoSegurado": "Proximo ao xxxxxx",           //Complemento do endereço do segurado. Tamanho: 50. Formato: AlfaNumerico.
    "nrComplementoSegurado": "Segurado01",                          //Número do complemento do endereço do segurado. Tamanho:10. Formato: AlfaNumerico.
    "nmPropriedade": "Propriedade01",                               //Nome da propriedade. Tamanho: 60. Formato: AlfaNumerico.
    "nrCepPropriedade": 11111111,                                   //CEP da propriedade. Tamanho: 8. Formato: Numerico.
    "txComplementoEnderecoPropriedade": "Descricao complemento",    //Descrição do complemento da propriedade. Tamanho: 50. Formato: AlfaNumerico.
    "nrComplementoPropriedade": "Complemento01",                    //Número do complemento da propriedade. Tamanho: 10. Formato: AlfaNumerico.
    "csFormatoCoordenada": "D",                                     //Formato das coordenadas da propriedade. Tamanho: 2. Formato: Caractere. Dominio: D-Decimal, G-Grau.
    "nrDecimalLatitude": "50,232345",                               //Número em decimal da latitude da propriedade. Tamanho: 30. Formato: Numerico. Dominio: Até - 70,056449833945
    "nrDecimalLongitude":"50,232345",                               //Número em decimal da longitude da propriedade. Tamanho: 30. Formato: Numerico. Dominio: Até - 70,056449833945
    "nrGrauLatitude": 30,                                           //Número em grau da latitude da propriedade. Tamanho: 2. Formato: Numerico. Dominio: S=0 a 33, N=0 a 5.
    "nrMinutoLatitude": 50,                                         //Número em minuto da latitude da propriedade. Tamanho: 2. Formato: Numerico. Dominio: 0 a 59.
    "nrSegundoLatitude": 50,                                        //Número em segundo da latitude da propriedade. Tamanho: 2. Formato: Numerico. Dominio: 0 a 59.
    "csOrientacaoLatitude": "S",                                    //Orientação da latitude da propriedade. Tamanho: 1.Formato: Caractere. Dominio: S-Sul, N-Norte.
    "nrGrauLongitude": 40,                                          //Número em grau da longitude da propriedade. Tamanho: 2. Formato: Numerico. Dominio: W=33 a 73.
    "nrMinutoLongitude": 50,                                        //Número em minuto da longitude da propriedade. Tamanho: 2.Formato: Numerico. Dominio: 0 a 59.
    "nrSegundoLongitude": 50,                                       //Número em segundo da longitude da propriedade. Tamanho: 2. Formato: Numerico. Dominio: 0 a 59.
    "csOrientacaoLongitude": "E",                                   //Orientação da longitude da propriedade. Tamanho: 1. Formato: Caractere. Dominio: E-Leste, W-Oeste. 
    "nrAreaTotal": "1562,23",                                       //Número da área total segurada. Tamanho: 9. Decimal: 2. Formato: Numerico.
    "nrPe": 1111111,                                                //Número de pés. Tamanho: 7. Formato: Numerico.
    "nrVolume": "45645,23",                                         //Número de volume. Tamanho: 9. Decimal: 2. Formato: Numerico.
    "nrProdutividadeSegurada": "4561231,12",                        //Número de produtividade a ser segurada(kg/ha). Tamanho: 12. Decimal: 2. Formato: Numerico.
    "nrProdutividadeEstimada": "1231312,12",                        //Número de produtividade estimada(kg/ha). Tamanho: 12. Decimal: 2. Formato: Numerico.
    "nrAnimal": 1520,                                               //Número de animais. Tamanho: 5. Formato: Numerico.
    "vlLimiteGarantia": "1231456,12",                               //Valor do limite de garantia(LMGA). Tamanho: 14. Decimal: 2. Formato: Numerico.
    "vlPremio": "123131231,12",                                     //Valor do prêmio líquido. Tamanho: 14. Decimal: 2. Formato: Numerico.
    "vlSubvencaoFederal": "1564564,12",                             //Valor da subvenção federal. Tamanho: 14. Decimal: 2. Formato: Numerico.
    "peNivelCobertura": 50,                                         //Informa a porcentagem do nível de cobertura. Tamanho: 2. Formato: Numerico.
    "cdClassificacaoProduto": 40,                                   //Código da classificação do produto. Tamanho: 2. Formato: Numerico.
    "unidadesSeguradas": {
        "itensUnidadeSegurada": [{
            "nrArea": "45621,12",                                   //Área - área da unidade segurada. Tamanho: 9. Decimal: 2. Formato: Numerico.
            "coberturas": {
                "cobertura": [{
                    "cdEventoCobertura": 120,                       //Cobertura - Tipo de cobertura garantida pela proposta. Tamanho: 3. Formato: Numerico.
                    "peFranquia": 50,                               //Franquia - Percentual da Franquia. Tamanho: 2. Formato: Numerico.
                    "vlLimiteMaximoIndenizacao": "123123112,21"     //LMI - Limite máximo de Indenização. Tamamho: 14. Decimal: 2. Formato: Numerico.
                }],
                "areasSeguradas": {
                    "coordenadasAreaSegurada": [
                        "coordenada": [
                            "nrDecimalLatitude":"-70,056449833945", //Número em decimal da latitude da propriedade. Tamanho: 30. Formato: Numerico.
                            "nrDecimalLongitude":"-70,056449833945",//Número em decimal da longitude da propriedade. Tamanho: 30. Formato: Numerico.                
                            "csOrientacaoLatitude": "S",            //Orientação da latitude da propriedade. Tamanho: 1.Formato: Caractere. Dominio: S-Sul, N-Norte.
                            "nrGrauLatitude": 30,                   //Número em grau da latitude da propriedade. Tamanho: 2. Formato: Numerico. Dominio: S=0 a 33, N=0 a 5.
                            "nrMinutoLatitude": 50,                 //Número em minuto da latitude da propriedade. Tamanho: 2. Formato: Numerico. Dominio: 0 a 59.v
                            "nrSegundoLatitude": 50,                //Número em segundo da latitude da propriedade. Tamanho: 2. Formato: Numerico. Dominio: 0 a 59.
                            "csOrientacaoLongitude": "E",           //Orientação da longitude da propriedade. Tamanho: 1. Formato: Caractere. Dominio: E-Leste, W-Oeste.
                            "nrGrauLongitude": 40,                  //Número em grau da longitude da propriedade. Tamanho: 2. Formato: Numerico. Dominio: W=33 a 73.
                            "nrMinutoLongitude": 50,                //Número em minuto da longitude da propriedade. Tamanho: 2.Formato: Numerico. Dominio: 0 a 59.
                            "nrSegundoLongitude": 50                //Número em segundo da longitude da propriedade. Tamanho: 2. Formato: Numerico. Dominio: 0 a 59.
                        ]
                    ]
                }
            }
        ]}
    }
}
```

## Picsel - MAPA - payload - 2.11 - Cancelar Proposta
```
{
    "cdProposta": 111111111  //Código da proposta gerado pelo MAPA. Tamanho: 9. Formato: Numerico.
}
```

## Picsel - MAPA - payload - 2.12 - Enviar Apolice
```
{
    "cdProposta": 111111111,     //Código da proposta gerado pelo MAPA. Tamanho: 9. Formato: Numerico.
    "nrApolice": "Apolice01231", //Número da apólice emitida pela seguradora. Tamanho: 20. Formato: AlfaNumerico sem caracteres especiais.
    "dtApolice": "10/01/2022"    //Data da apólice. Tamanho: 10. Formato: dd/MM/yyyy.
}
```

# PicSel SUSEP 

## Mapa Sandbox Sinistro
Campo                               | Equivalente Picsel   | Descrição                                                                                                | Obrigatorio  | Mascara             | Tamanho | Tipo Preenchimento | Exemplo                   | Referencia
----------------------------------- | -------------------- | -------------------------------------------------------------------------------------------------------- | ------------ | ------------------- | ------- | ------------------ | ------------------------- | --------- 
cnpj                                | inexistente          | CNPJ da sociedade seguradora                                                                             | sim          |                     | 14      | Alfanumerico - AN  | 01234567891011'           |           
sinistros.dataMovimento             | sinistros.DataHora   | Corresponde à data referente ao lançamento do movimento. O formato do campo deve ser: AAAAMM-DD HH:MM:SS | sim          | AAAA-MM-DD HH:MM:SS | 19      | Data e Hora        | """2020-04-11 00:01:03""" | 
sinistros.numeroSinistro            | sinistros.idsinistro | "Corresponde ao número dado pela seguradora à comunicação da ocorrência de um evento (sinistro). Inclui o dígito verificador |  se for o caso. _x000D_" | sim |  |  | Alfanumerico - AN | """ABCDEF-123456""" | 
sinistros.numeroApolice             | inexistente | "Corresponde ao número/código do contrato do seguro |  preenchido de acordo com a legislação vigente |  incluindo o dígito verificador se houver" | sim |  |  | Alfanumerico - AN | """APOLICE-PREMIO-01""" | 
sinistros.maxima                    | checar base | Valor monetário da maior importância segurada para cobertura de um risco isolado. Neste campo são consideradas duas casas decimais. | sim |  |  | Numérico - NU | "10000 | 00" | 
sinistros.identificacaoSegurado     | Seguros.seguros.CPFProdutor | Corresponde ao CPF ou CNPJ do Segurado | sim |  | 11 ou 14 | Alfanumerico - AN | 01234567891011' | 
sinistros.identificacaoBeneficiario | inexistente | Corresponde ao CPF ou CNPJ do beneficiário | sim |  | 11 ou 14 | Alfanumerico - AN | 01234567891011' | 
sinistros.identificacaoCobertura    | inexistente | Corresponde ao tipo de cobertura contratado. Tabela de Referência 05  | sim |  | 2 | Alfanumerico - AN | """01""" | "TABELA 05 – TIPOS DE COBERTURA |  pg 10"
sinistros.identificacaoObjetoSinistrado | inexistente | Corresponde ao tipo de objeto sinistrado. Tabela de Referência 06 | sim |  | 3 | Alfanumerico - AN | """010""" | "TABELA 06 – TIPOS DE OBJETO |  pg 11"
sinistros.tipoSinistro | inexistente | Corresponde ao tipo de sinistro que pode ser administrativo ou judicial. Tabela de Referência 07  | sim |  | 2 | Alfanumerico - AN | """01""" | "TABELA 07 – TIPOS DE SINISTRO |  pg 11"
sinistros.tipoMovimento | inexistente | Corresponde ao código do tipo de movimento do sinistro. Tabela de Referência 08 | sim |  | 2 | Alfanumerico - AN | """01""" | "TABELA 08 – TIPOS DE MOVIMENTO DE SINISTRO |  pg 11"
sinistros.valorMovimento | inexistente | Corresponde ao valor monetário movimentado no sinistro de acordo com o tipo de movimento. Neste campo são consideradas duas casas decimais | sim |  |  | Numérico - NU | "10000 | 00" | 
sinistros.valorMovimentoRetido | inexistente | Corresponde ao valor monetário retido movimentado no sinistro de acordo com o tipo de movimento. Neste campo são consideradas duas casas decimais._x000D_ | sim |  |  | Numérico - NU | "10000 | 00" | 
sinistros.dataOcorrenciaSinistro | "Sinistros.DataSinistro
" | Data de ocorrência do sinistro. O formato do campo deve ser: AAAA-MM-DD  | sim | AAAA-MM-DD |  | Data - DT | """2020-04-11""" | 
sinistros.dataComunicacaoSinistro | sinistros.DataHora | Data em que a seguradora recebeu o aviso do sinistro. O formato do campo deve ser: AAAA-MMDD | sim | AAAA-MM-DD |  | Data - DT | """2020-04-11""" | 
sinistros.dataRegistroInicialSinistro | sinistros.DataHora | Data em que a seguradora registrou a ocorrência do sinistro. O formato do campo deve ser: AAAA-MMDD _x000D_ | sim | AAAA-MM-DD |  | Data - DT | """2020-04-11""" | 
sinistros.statusSinistro | inexistente | Corresponde à situação do sinistro no momento do registro da movimentação. Tabela de Referência 09  | sim |  | 2 | Alfanumerico - AN | """01""" | "TABELA 09 – STATUS DO SINISTRO |  pg 11 e 12"
sinistros.justificativaNegativa | inexistente | Corresponde à justificativa em caso de negativa de sinistro. Tabela de Referência 10 | sim |  | 2 | Alfanumerico - AN | """01""" | "TABELA 10 – JUSTIFICATIVA DE NEGATIVA |  pg 12"

## Mapa Cancelar Sinistros

Campo | Equivalente Picsel | Descrição | Obrigatorio | Mascara | Tamanho | Tipo Preenchimento | Exemplo
--- | --- | --- | --- | --- | --- | --- | --- |
nrApolice | seguros.id | Número da apólice | Sim | N.A. | 20 | Alfanumérico sem caracter especial - AS | -
idSinistro |  | Identificador/código gerado pelo MAPA (Ao enviar sinistro) | Sim | N.A. | 9 | Numérico - NU | -

## Mapa Sandbox Premio

Campo | Equivalente Picsel | Descrição | Obrigatorio | Mascara | Tamanho | Tipo Preenchimento | Exemplo | Referencia
--- | --- | --- | --- | --- | --- | --- | --- | --- |
cnpj | inexistente | CNPJ da sociedade seguradora  | sim |  | 14 | Alfanumerico - AN | 01234567891011' | 
premios.numeroApolice | inexistente | "Corresponde ao número/código do contrato do seguro |  preenchido de acordo com a legislação vigente |  incluindo o dígito verificador se houver" | sim |  |  | Alfanumerico - AN | """APOLICE-PREMIO-01""" | 
premios.naturezaMovimento | inexistente | Corresponde à natureza do registro. Tabela de Referência 01  | sim |  | 2 | Alfanumerico - AN | """01""" | "TABELA 01 – NATUREZA DO PRÊMIO |  pg 9"
premios.tipoMovimento | inexistente | Corresponde ao tipo de movimento relacionado a premios. Tabela de Referência 02 | sim |  | 2 | Alfanumerico - AN | """01""" | "TABELA 02 - TIPOS DE MOVIMENTO DE PRÊMIO |  pg 9"
premios.iof | inexistente | Valor monetário do imposto – corresponde ao valor da IOF | sim |  |  | Numérico - NU | "10000 | 00" | 
premios.valorCorretagem | inexistente | Valor monetário da comissão de corretagem do seguro – corresponde ao valor total da comissão. | sim |  |  | Numérico - NU | "10000 | 00" | 
premios.dataInicioApolice | seguros.DataVigenciaInicial | Data em que a apólice/bilhete iniciou ou iniciará efetivamente a sua vigência. O formato do campo deve ser: AAAA-MM-DD HH:MM:SS | sim | AAAA-MM-DD HH:MM:SS | 19 | Data e Hora | """2020-04-11 00:01:03""" | 
premios.dataFimApolice | seguros.DataVigenciaFinal | Data em que a apólice/bilhete encerrou ou encerrará efetivamente a sua vigência. O formato do campo deve ser: AAAA-MM-DD HH:MM:SS | sim | AAAA-MM-DD HH:MM:SS | 19 | Data e Hora | """2020-04-11 00:01:03""" | 
premios.dataInicioCobertura | existente base | Data de início da cobertura. O formato do campo deve ser: AAAA-MM-DD HH:MM:SS  | sim | AAAA-MM-DD HH:MM:SS | 19 | Data e Hora | """2020-04-11 00:01:03""" | 
premios.dataFimCobertura | existente base | Data do final da cobertura. O formato do campo deve ser: AAAA-MM-DD HH:MM:SS  | sim | AAAA-MM-DD HH:MM:SS | 19 | Data e Hora | """2020-04-11 00:01:03""" | 
premios.identificacaoSegurado | seguros.CPFProdutor | Corresponde ao CPF ou CNPJ do Segurado | sim |  | 11 ou 14 | Alfanumerico - AN | 01234567891011' | 
premios.identificacaoBeneficiario | inexistente | Corresponde ao CPF ou CNPJ do Beneficiario | sim |  | 11 ou 14 | Alfanumerico - AN | 01234567891011' | 
premios.seguroIntermitente | inexistente | Corresponde à informação de se a apólice/bilhete é referente à cobertura de seguro ntermitente ou de seguro tradicional. Tabela de Referência 03  | sim |  | 2 | Alfanumerico - AN | """01""" | "TABELA 03 – SEGURO INTERMITENTE |  pg 9"
premios.dataMovimento | inexistente | Corresponde à data referente ao lançamento do movimento. O formato do campo deve ser: AAAA-MMDD HH:MM:SS | sim | AAAA-MM-DD HH:MM:SS | 19 | Data e Hora | """2020-04-11 00:01:03""" | 
premios.coberturas.identificacaoCobertura | inexistente | Corresponde ao tipo de cobertura contratado. Tabela de Referência 05 _x000D_ | sim |  | 3 | Alfanumerico - AN | """001""" | "TABELA 05 – TIPOS DE COBERTURA |  pg 10"
premios.coberturas.ramo | inexistente | Código do ramo a que se refere o movimento e que se encontra no edital de seleção no qual a supervisionada se submeteu. Tabela de Referência 04  | sim |  | 3 | Alfanumerico - AN | """001""" | "TABELA 04 – RAMOS (DE ACORDO COM O EDITAL) _x000D_ |  pg 9 e 10"
premios.coberturas.maxima | checar base | Valor monetário da maior importância segurada para cobertura de um risco isolado. Neste campo são consideradas duas casas decimais. _x000D_ | sim |  |  | Numérico - NU | "10000 | 00" | 
premios.coberturas.identificacaoObjetoSegurado | inexistente | Corresponde ao tipo de objeto que será coberto. Tabela de Referência 06  | sim |  | 3 | Alfanumerico - AN | """001""" | "TABELA 06 – TIPOS DE OBJETO |  pg 11"
premios.coberturas.premioBruto | inexistente | "Valor monetário do prêmio bruto. Prêmio bruto = prêmio comercial acrescido dos encargos e impostos |  sendo este o prêmio efetivamente que será pago pelo segurado." | sim |  |  | Numérico - NU | "10000 | 00" | 
premios.coberturas.premioComercial | checar base | Valor monetário do prêmio comercial considerando duas casas decimais | sim |  |  | Numérico - NU | "10000 | 00" | 
premios.coberturas.premioRetido | inexistente | Valor monetário do prêmio retido. Prêmio retido = prêmio emitido – prêmio de cosseguro cedido – prêmios cedidos em resseguro. _x000D_ | sim |  |  | Numérico - NU | "10000 | 00" | 

## Mapa Sandbox Reclamação

<div style="overflow-x:auto;">
    <table style='width: 2500px;'>
        <thead>
            <tr>
                <th>Campo</th>
                <th>Equivalente Picsel</th>
                <th>Descrição</th>
                <th>Obrigatorio</th>
                <th>Mascara</th>
                <th>Tamanho</th>
                <th>Tipo Preenchimento</th>
                <th>Exemplo</th>
                <th>Referencia</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>cnpj</td>
                <td>Aguardando Implementação</td>
                <td>CNPJ da sociedade seguradora </td>
                <td>sim</td>
                <td></td>
                <td>14</td>
                <td>Alfanumerico - AN</td>
                <td>01234567891011'</td>
                <td></td>
            </tr>
            <tr>
                <td>reclamacoes.dataMovimento</td>
                <td>Aguardando Implementação</td>
                <td>Corresponde à data referente ao lançamento do movimento. O formato do campo deve ser: AAAA-MM-DD HH:MM:SS</td>
                <td>sim</td>
                <td>AAAA-MM-DD HH:MM:SS</td>
                <td>19</td>
                <td>Data e Hora</td>
                <td>"2020-04-11 00:01:03"</td>
                <td></td>
            </tr>
            <tr>
                <td>reclamacoes.identificacaoCobertura</td>
                <td>Aguardando Implementação</td>
                <td>Corresponde ao tipo de cobertura contratada. Tabela de Referência 05</td>
                <td>sim</td>
                <td></td>
                <td>3</td>
                <td>Alfanumerico - AN</td>
                <td>"011"</td>
                <td>TABELA 05 – TIPOS DE COBERTURA, pg 10</td>
            </tr>
            <tr>
                <td>reclamacoes.identificacaoObjetoSegurado</td>
                <td>Aguardando Implementação</td>
                <td>Corresponde ao tipo de objeto coberto. Tabela de Referência 06 </td>
                <td>sim</td>
                <td></td>
                <td>3</td>
                <td>Alfanumerico - AN</td>
                <td>"007"</td>
                <td>TABELA 06 – TIPOS DE OBJETO, pg 11</td>
            </tr>
            <tr>
                <td>reclamacoes.dataReclamacao</td>
                <td>Aguardando Implementação</td>
                <td>Data em que a reclamação foi feita na seguradora contra a seguradora _x005F_x000D_</td>
                <td>sim</td>
                <td>AAAA-MM-DD</td>
                <td></td>
                <td>Data - DT</td>
                <td>"2020-04-11"</td>
                <td></td>
            </tr>
            <tr>
                <td>reclamacoes.tipoReclamacao</td>
                <td>Aguardando Implementação</td>
                <td>Tipo de reclamação efetuada pelo segurado de acordo com a tabela da referência. Tabela de Referência 12</td>
                <td>sim</td>
                <td></td>
                <td>2</td>
                <td>Alfanumerico - AN</td>
                <td>"04"</td>
                <td>TABELA 12 – TIPO DA RECLAMAÇÃO, pg 12</td>
            </tr>
            <tr>
                <td>reclamacoes.statusReclamacao.</td>
                <td>Aguardando Implementação</td>
                <td>Corresponde à situação da reclamação no momento do registro da informação. Tabela de Referência 11</td>
                <td>sim</td>
                <td></td>
                <td>2</td>
                <td>Alfanumerico - AN</td>
                <td>"04"</td>
                <td>TABELA 11 – STATUS DA RECLAMAÇÃO _x005F_x000D_, pg 12</td>
            </tr>
            <tr>
                <td>reclamacoes.identificacaoSegurado</td>
                <td>Aguardando Implementação</td>
                <td>Corresponde ao CPF ou CNPJ do Segurado</td>
                <td>sim</td>
                <td></td>
                <td>11 ou 14</td>
                <td>Alfanumerico - AN</td>
                <td>01234567891011'</td>
                <td></td>
            </tr>
            <tr>
                <td>reclamacoes.identificacaoReclamante</td>
                <td>Aguardando Implementação</td>
                <td>Corresponde ao CPF ou CNPJ do Reclamante</td>
                <td>sim</td>
                <td></td>
                <td>11 ou 14</td>
                <td>Alfanumerico - AN</td>
                <td>01234567891011'</td>
                <td></td>
            </tr>
            <tr>
                <td>reclamacoes.numeroApolice</td>
                <td>Aguardando Implementação</td>
                <td>Corresponde ao número/código do contrato do seguro, preenchido de acordo com a legislação vigente, incluindo o dígito verificador se houver</td>
                <td>sim</td>
                <td></td>
                <td></td>
                <td>Alfanumerico - AN</td>
                <td>"APOLICE-PREMIO-01"</td>
                <td></td>
            </tr>
        </tbody>
    </table>
</div>

## Mapa Sandbox Contabil

<div style="overflow-x:auto;">
<table style='width: 2700px;'>
    <thead>
        <tr>
            <th>Campo</th>
            <th>Equivalente Picsel</th>
            <th style='width: 1400px; !important'>Descrição</th>
            <th>Obrigatorio</th>
            <th>Mascara</th>
            <th>Tamanho</th>
            <th>Tipo Preenchimento</th>
            <th>Exemplo</th>
            <th>Referencia</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>cnpj</td>
            <td></td>
            <td>CNPJ da sociedade seguradora </td>
            <td>sim</td>
            <td></td>
            <td>14</td>
            <td>Alfanumerico - AN</td>
            <td>01234567891011</td>
            <td></td>
        </tr>
        <tr>
            <td>dadosContabeis.mesReferencia</td>
            <td></td>
            <td>Ano e mês do mês de referência. (AAAAMM) _x000D_</td>
            <td>sim</td>
            <td>AAAAMM</td>
            <td>6</td>
            <td>Numérico - NU</td>
            <td>202101 - AAAA = ano, MM= Mês</td>
            <td></td>
        </tr>
        <tr>
            <td>dadosContabeis.premioEmitido</td>
            <td></td>
            <td>Valor monetário do prêmio total emitido no mês de referência. Neste campo são consideradas duas casas decimais. </td>
            <td>sim</td>
            <td></td>
            <td></td>
            <td>Numérico - NU</td>
            <td>10000,00</td>
            <td></td>
        </tr>
        <tr>
            <td>dadosContabeis.quantidadeApolicesEmitidas</td>
            <td></td>
            <td>Somatório da quantidade de apólices/bilhetes emitidos no mês de referência.</td>
            <td>sim</td>
            <td></td>
            <td></td>
            <td>Numérico - NU</td>
            <td>10</td>
            <td></td>
        </tr>
        <tr>
            <td>dadosContabeis.quantidadeRiscosVigentes</td>
            <td></td>
            <td>Somatório da quantidade de riscos que vigoraram no mês de referência. Caso o risco tenha vigorado por algum intervalo de tempo, no mês de referência, este deverá ser contemplado neste quantitativo. </td>
            <td>sim</td>
            <td></td>
            <td></td>
            <td>Numérico - NU</td>
            <td>10</td>
            <td></td>
        </tr>
        <tr>
            <td>dadosContabeis.quantidadeReclamacoes</td>
            <td></td>
            <td>Somatório da quantidade de reclamações recepcionadas no mês de referência.</td>
            <td>sim</td>
            <td></td>
            <td></td>
            <td>Numérico - NU</td>
            <td>10</td>
            <td></td>
        </tr>
        <tr>
            <td>dadosContabeis.quantidadeSinistrosAvisados</td>
            <td></td>
            <td>Somatório da quantidade de sinistros avisados no mês de referência. </td>
            <td>sim</td>
            <td></td>
            <td></td>
            <td>Numérico - NU</td>
            <td>10</td>
            <td></td>
        </tr>
        <tr>
            <td>dadosContabeis.quantidadeSinistrosPagos</td>
            <td></td>
            <td>Somatório da quantidade de sinistros pagos no mês de referência.</td>
            <td>sim</td>
            <td></td>
            <td></td>
            <td>Numérico - NU</td>
            <td>10</td>
            <td></td>
        </tr>
        <tr>
            <td>dadosContabeis.ativosFinanceiros</td>
            <td></td>
            <td>Valor monetário do ativo financeiro contabilizado no último dia do mês de referência. Neste campo são consideradas duas casas decimais. </td>
            <td>sim</td>
            <td></td>
            <td></td>
            <td>Numérico - NU</td>
            <td>10000,00</td>
            <td></td>
        </tr>
        <tr>
            <td>dadosContabeis.intangiveis</td>
            <td></td>
            <td>Valor monetário dos intangíveis e dos custos de aquisição diferidos contabilizados no último dia do mês de referência. Neste campo são consideradas duas casas decimais. </td>
            <td>sim</td>
            <td></td>
            <td></td>
            <td>Numérico - NU</td>
            <td>10000,00</td>
            <td></td>
        </tr>
        <tr>
            <td>dadosContabeis.demaisAtivos</td>
            <td></td>
            <td>Valor monetário dos demais ativos no último dia do mês de referência. Neste campo são consideradas duas casas decimais. </td>
            <td>sim</td>
            <td></td>
            <td></td>
            <td>Numérico - NU</td>
            <td>10000,00</td>
            <td></td>
        </tr>
        <tr>
            <td>dadosContabeis.provisaoPremiosNaoGanhos</td>
            <td></td>
            <td>Valor monetário da Provisão de Prêmios Não Ganhos (PPNG) no último dia do mês de referência. Neste campo são consideradas duas casas decimais. _x000D_</td>
            <td>sim</td>
            <td></td>
            <td></td>
            <td>Numérico - NU</td>
            <td>10000,00</td>
            <td></td>
        </tr>
        <tr>
            <td>dadosContabeis.provisaoSinistrosLiquidar</td>
            <td></td>
            <td>Valor monetário da Provisão de Sinistros a Liquidar (PSL) no último dia do mês de referência. Neste campo são consideradas duas casas decimais.</td>
            <td>sim</td>
            <td></td>
            <td></td>
            <td>Numérico - NU</td>
            <td>10000,00</td>
            <td></td>
        </tr>
        <tr>
            <td>dadosContabeis.provisaoSinistrosOcorridosNaoAvisados</td>
            <td></td>
            <td>Valor monetário da Provisão de Sinistros Ocorridos e não Avisados (IBNR) no último dia do mês de referência. Neste campo são consideradas duas casas decimais. </td>
            <td>sim</td>
            <td></td>
            <td></td>
            <td>Numérico - NU</td>
            <td>10000,00</td>
            <td></td>
        </tr>
          <tr>
            <td>dadosContabeis.provisaoValoresRegularizar</td>
            <td></td>
            <td>Valor monetário da Provisão de Valores a Regularizar no último dia do mês de referência. Neste campo são consideradas duas casas decimais. _x000D_</td>
            <td>sim</td>
            <td></td>
            <td></td>
            <td>Numérico - NU</td>
            <td>10000,00</td>
            <td></td>
        </tr>
          <tr>
            <td>dadosContabeis.outrasProvisoesTecnicas</td>
            <td></td>
            <td>Valor monetário de Outras Provisões Técnicas no último dia do mês de referência. Neste campo são consideradas duas casas decimais. _x000D_</td>
            <td>sim</td>
            <td></td>
            <td></td>
            <td>Numérico - NU</td>
            <td>10000,00</td>
            <td></td>
        </tr>
          <tr>
            <td>dadosContabeis.valorTotalSinistrosPagosMes</td>
            <td></td>
            <td>Valor monetário dos sinistros pagos no mês de referência. Neste campo são consideradas duas casas decimais. _x000D_</td>
            <td>sim</td>
            <td></td>
            <td></td>
            <td>Numérico - NU</td>
            <td>10000,00</td>
            <td></td>
        </tr>
          <tr>
            <td>dadosContabeis.demaisPassivos</td>
            <td></td>
            <td>Valor monetário dos demais passivos no último dia do mês de referência. Neste campo são consideradas duas casas decimais. _x000D_</td>
            <td>sim</td>
            <td></td>
            <td></td>
            <td>Numérico - NU</td>
            <td>10000,00</td>
            <td></td>
        </tr>
          <tr>
            <td>dadosContabeis.valorPatrimonioLiquido</td>
            <td></td>
            <td>Valor monetário do Patrimônio Líquido no último dia do mês de referência. Neste campo são consideradas duas casas decimais. _x000D_</td>
            <td>sim</td>
            <td></td>
            <td></td>
            <td>Numérico - NU</td>
            <td>10000,00</td>
            <td></td>
        </tr>
          <tr>
            <td>dadosContabeis.cmr</td>
            <td></td>
            <td>Valor monetário do Capital Mínimo Requerido (CMR) no último dia do mês de referência. Neste campo são consideradas duas casas decimais</td>
            <td>sim</td>
            <td></td>
            <td></td>
            <td>Numérico - NU</td>
            <td>10000,00</td>
            <td></td>
        </tr>
          <tr>
            <td>dadosContabeis.estruturaSimplificada</td>
            <td></td>
            <td>Determinar a opção no qual a seguradora com autorização temporária está enquadrada em seus investimentos, no mês de referência. </td>
            <td>sim</td>
            <td></td>
            <td></td>
            <td>Boolean</td>
            <td>True / False</td>
            <td></td>
        </tr>
        <tr>
            <td>dadosContabeis.valorTotalPremiosEmitidosRetidos</td>
            <td></td>
            <td>Valor monetário de prêmio emitido retido, líquido de cosseguro e resseguro, no mês de referência. _x000D_</td>
            <td>sim</td>
            <td></td>
            <td></td>
            <td>Numérico - NU</td>
            <td>10000,00</td>
            <td></td>
        </tr>
        <tr>
            <td>dadosContabeis.valorAtivoResseguroProvisoesTecnicas</td>
            <td></td>
            <td>Valor monetário do ativo de resseguro, no último dia do mês de referência</td>
            <td>sim</td>
            <td></td>
            <td></td>
            <td>Numérico - NU</td>
            <td>10000,00</td>
            <td></td>
        </tr>
        <tr>
            <td>dadosContabeis.valorAtivoResseguroRedutor</td>
            <td></td>
            <td>Valor oferecido no mês de referência como ativo de resseguro redutor da necessidade de cobertura de provisões técnicas, no último dia do mês de referência. </td>
            <td>sim</td>
            <td></td>
            <td></td>
            <td>Numérico - NU</td>
            <td>10000,00</td>
            <td></td>
        </tr>
        <tr>
            <td>dadosContabeis.valorTotalSinistrosAvisados</td>
            <td></td>
            <td>Valor monetário dos sinistros avisados no mês de referência. _x000D_</td>
            <td>sim</td>
            <td></td>
            <td></td>
            <td>Numérico - NU</td>
            <td>10000,00</td>
            <td></td>
        </tr>
        <tr>
            <td>dadosContabeis.valorTotalSinistrosAvisadosRetidos</td>
            <td></td>
            <td>Valor monetário de sinistro avisado retido, líquido de cosseguro e resseguro, no mês de referência.</td>
             <td>sim</td>
            <td></td>
            <td></td>
            <td>Numérico - NU</td>
            <td>10000,00</td>
            <td></td>
        </tr>
    </tbody>
</table>
</div>

## Mapa Sandbox Sinistro Pendente

<div style="overflow-x:auto;">
<table style='width: 2800px;'>
    <thead>
        <tr>
            <th>Campo</th>
            <th>Equivalente Picsel</th>
            <th style='width: 1000px; !important'>Descrição</th>
            <th>Obrigatorio</th>
            <th>Mascara</th>
            <th>Tamanho</th>
            <th>Tipo Preenchimento</th>
            <th>Exemplo</th>
            <th>Referencia</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>cnpj</td>
            <td> </td>
            <td>CNPJ da sociedade seguradora</td>
            <td>sim</td>
            <td> </td>
            <td>14</td>
            <td>Alfanumerico - AN</td>
            <td>01234567891011'</td>
            <td> </td>
        </tr>
        <tr>
            <td>sinistrosPendentes.mesReferencia</td>
            <td>sinistros.DataHora</td>
            <td>Ano e mês do mês de referência.</td>
            <td>sim</td>
            <td>AAAASS</td>
            <td>6</td>
            <td>Numérico - NU</td>
            <td>"201601 - AAAA = ano SS = semestre"</td>
            <td></td>
        </tr>
        <tr>
            <td>sinistrosPendentes.ramo</td>
            <td></td>
            <td>Código do ramo a que se refere o movimento e que se encontra no edital de seleção no qual a supervisionada se submeteu. _x000D_</td>
            <td>sim</td>
            <td></td>
            <td>3</td>
            <td>Alfanumerico - AN</td>
            <td>002'</td>
            <td>"TABELA 04 – RAMOS (DE ACORDO COM O EDITAL) pg 9 e 10"</td>
        </tr>
        <tr>
            <td>sinistrosPendentes.numeroSinistro</td>
            <td>sinistros.ID</td>
            <td>Corresponde ao número dado pela seguradora à comunicação da ocorrência de um evento (sinistro). Inclui o dígito verificador, se houver</td>
            <td>sim</td>
            <td></td>
            <td></td>
            <td>Alfanumerico - AN</td>
            <td>"ABCDEF-123456"</td>
            <td></td>
        </tr>
        <tr>
            <td>sinistrosPendentes.numeroApolice</td>
            <td>sinistros.IDSeguros</td>
            <td>Corresponde ao número/código do contrato do seguro, preenchido de acordo com a legislação vigente, incluindo o dígito verificador se houver</td>
            <td>sim</td>
            <td></td>
            <td></td>
            <td>Alfanumerico - AN</td>
            <td>"APOLICE-PREMIO-01"</td>
            <td></td>
        </tr>
        <tr>
            <td>sinistrosPendentes.dataComunicacaoSinistro</td>
            <td></td>
            <td>Data em que a seguradora recebeu o aviso do sinistro. O formato do campo deve ser: AAAA-MM-DD </td>
            <td>sim</td>
            <td>AAAA-MM-DD</td>
            <td></td>
            <td>Data - DT</td>
            <td>"2021-05-30" - AAAA = ano, MM = mês, DD = dia</td>
            <td></td>
        </tr>
        <tr>
            <td>sinistrosPendentes.dataRegistroInicialSinistro</td>
            <td>Sinistros.DataSinistro</td>
            <td>Data em que a seguradora registrou a ocorrência do sinistro. O formato do campo deve ser: AAAA-MM-DD _x000D_</td>
            <td>sim</td>
            <td>AAAA-MM-DD</td>
            <td></td>
            <td>Data - DT</td>
            <td>"2021-05-30" - AAAA = ano, MM = mês, DD = dia</td>
            <td></td>
        </tr>
        <tr>
            <td>sinistrosPendentes.valorSinistroPendente</td>
            <td></td>
            <td>Valor do Sinistro pendente no mês de referência. Neste campo são consideradas duas casas decimais. _x000D_</td>
            <td>sim</td>
            <td></td>
            <td></td>
            <td>Numérico - NU</td>
            <td>1111,02</td>
            <td></td>
        </tr>
        <tr>
            <td>sinistrosPendentes.valorSinistroPendenteRetido</td>
            <td></td>
            <td>Valor de Sinistro pendente retido no mês de referência. Neste campo são consideradas duas casas decimais. </td>
            <td></td>
            <td></td>
            <td></td>
            <td>Numérico - NU</td>
            <td>1111,02</td>
            <td></td>
        </tr>
    </tbody>
</table>
</div>













