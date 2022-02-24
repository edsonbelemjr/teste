# Sobre a API e este documento

É um documento que mostra de forma simples como se comunicar com a API do WebAPP da Picsel. Todos os exemplos usam o CURL padrão e foram testados em um terminal Bash/Linux comum.

Existem operações de POST e GET, sendo que o login precisa ser feito via POST bem como a
conclusão da sessão. A sessão fechará automaticamente depois de um período de inatividade.

Apenas após o login será possível executar as demais requisições/operações na API, a partir do login autorizado a API aceitará as requisições/operações apenas com as informações adequadas da sessão, fornecidas com o sucesso do login.

# Middleware - MAPA e SUSEP

Esse projeto é responsável por fazer a integração da API desenvolvida pela Ponderatti, que irá consultar a base de dados da Picsel retornando os campos necessários para o envio dos dados para as APIs do MAPA e da SUSEP. A arquitetura será provisionada usando o recurso LAMBDA AWS.

# Validação

As validações dos campos são feitas após entre a consulta da API de entrada e o envio para as APIs. A validação é feita a partir do jsonschema utilizando a biblioteca do python jsonschema. Para cada caminho das APIs foram feitos jsonschemas que definem as regras de cada campo, e utilizando a função validate da biblioteca jsonschema

# Dados referente ao Mapa

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












