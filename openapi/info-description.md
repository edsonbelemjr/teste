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

## PicSel SUSEP 

### Mapa Sandbox Sinistro
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

### Mapa Cancelar Sinistros

Campo | Equivalente Picsel | Descrição | Obrigatorio | Mascara | Tamanho | Tipo Preenchimento | Exemplo
--- | --- | --- | --- | --- | --- | --- | --- |
nrApolice | seguros.id | Número da apólice | Sim | N.A. | 20 | Alfanumérico sem caracter especial - AS | -
idSinistro |  | Identificador/código gerado pelo MAPA (Ao enviar sinistro) | Sim | N.A. | 9 | Numérico - NU | -

### Mapa Sandbox Premio

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

### Mapa Sandbox Reclamação

Campo | Equivalente Picsel | Descrição | Obrigatorio | Mascara | Tamanho | Tipo Preenchimento | Exemplo | Referencia
--- | --- | --- | --- | --- | --- | --- | --- | --- |
cnpj | inexistente | CNPJ da sociedade seguradora  | sim |  | 14 | Alfanumerico - AN | 01234567891011' | 
reclamacoes.dataMovimento | inexistente | Corresponde à data referente ao lançamento do movimento. O formato do campo deve ser: AAAA-MM-DD HH:MM:SS | sim | AAAA-MM-DD HH:MM:SS | 19 | Data e Hora | """2020-04-11 00:01:03""" | 
reclamacoes.identificacaoCobertura | inexistente | Corresponde ao tipo de cobertura contratada. Tabela de Referência 05 | sim |  | 3 | Alfanumerico - AN | """011""" | "TABELA 05 – TIPOS DE COBERTURA |  pg 10"
reclamacoes.identificacaoObjetoSegurado | inexistente | Corresponde ao tipo de objeto coberto. Tabela de Referência 06  | sim |  | 3 | Alfanumerico - AN | """007""" | "TABELA 06 – TIPOS DE OBJETO |  pg 11"
reclamacoes.dataReclamacao | inexistente | Data em que a reclamação foi feita na seguradora contra a seguradora _x000D_ | sim | AAAA-MM-DD |  | Data - DT | """2020-04-11""" | 
reclamacoes.tipoReclamacao | inexistente | Tipo de reclamação efetuada pelo segurado de acordo com a tabela da referência. Tabela de Referência 12 | sim |  | 2 | Alfanumerico - AN | """04""" | "TABELA 12 – TIPO DA RECLAMAÇÃO |  pg 12"
reclamacoes.statusReclamacao. | inexistente | Corresponde à situação da reclamação no momento do registro da informação. Tabela de Referência 11 | sim |  | 2 | Alfanumerico - AN | """04""" | "TABELA 11 – STATUS DA RECLAMAÇÃO _x000D_ |  pg 12"
reclamacoes.identificacaoSegurado | inexistente | Corresponde ao CPF ou CNPJ do Segurado | sim |  | 11 ou 14 | Alfanumerico - AN | 01234567891011' | 
reclamacoes.identificacaoReclamante | inexistente | Corresponde ao CPF ou CNPJ do Reclamante | sim |  | 11 ou 14 | Alfanumerico - AN | 01234567891011' | 
reclamacoes.numeroApolice | inexistente | "Corresponde ao número/código do contrato do seguro |  preenchido de acordo com a legislação vigente |  incluindo o dígito verificador se houver" | sim |  |  | Alfanumerico - AN | """APOLICE-PREMIO-01""" | 

### Mapa Sandbox Contabil

Campo | Equivalente Picsel | Descrição | Obrigatorio | Mascara | Tamanho | Tipo Preenchimento | Exemplo | Referencia
--- | --- | --- | --- | --- | --- | --- | --- | --- |
cnpj |  | CNPJ da sociedade seguradora  | sim |  | 14 | Alfanumerico - AN | 01234567891011' | 
dadosContabeis.mesReferencia |  | Ano e mês do mês de referência. (AAAAMM) _x000D_ | sim | AAAAMM | 6 | Numérico - NU | "202101 - AAAA = ano |  MM= Mês" | 
dadosContabeis.premioEmitido |  | Valor monetário do prêmio total emitido no mês de referência. Neste campo são consideradas duas casas decimais.  | sim |  |  | Numérico - NU | "10000 | 00" | 
dadosContabeis.quantidadeApolicesEmitidas |  | Somatório da quantidade de apólices/bilhetes emitidos no mês de referência. | sim |  |  | Numérico - NU | 10 | 
dadosContabeis.quantidadeRiscosVigentes |  | "Somatório da quantidade de riscos que vigoraram no mês de referência. Caso o risco tenha vigorado por algum intervalo de tempo |  no mês de referência |  este deverá ser contemplado neste quantitativo. " | sim |  |  | Numérico - NU | 10 | 
dadosContabeis.quantidadeReclamacoes |  | Somatório da quantidade de reclamações recepcionadas no mês de referência. | sim |  |  | Numérico - NU | 10 | 
dadosContabeis.quantidadeSinistrosAvisados |  | Somatório da quantidade de sinistros avisados no mês de referência.  | sim |  |  | Numérico - NU | 10 | 
dadosContabeis.quantidadeSinistrosPagos |  | Somatório da quantidade de sinistros pagos no mês de referência. | sim |  |  | Numérico - NU | 10 | 
dadosContabeis.ativosFinanceiros |  | Valor monetário do ativo financeiro contabilizado no último dia do mês de referência. Neste campo são consideradas duas casas decimais.  | sim |  |  | Numérico - NU | "10000 | 00" | 
dadosContabeis.intangiveis |  | Valor monetário dos intangíveis e dos custos de aquisição diferidos contabilizados no último dia do mês de referência. Neste campo são consideradas duas casas decimais.  | sim |  |  | Numérico - NU | "10000 | 00" | 
dadosContabeis.demaisAtivos |  | Valor monetário dos demais ativos no último dia do mês de referência. Neste campo são consideradas duas casas decimais.  | sim |  |  | Numérico - NU | "10000 | 00" | 
dadosContabeis.provisaoPremiosNaoGanhos |  | Valor monetário da Provisão de Prêmios Não Ganhos (PPNG) no último dia do mês de referência. Neste campo são consideradas duas casas decimais. _x000D_ | sim |  |  | Numérico - NU | "10000 | 00" | 
dadosContabeis.provisaoSinistrosLiquidar |  | Valor monetário da Provisão de Sinistros a Liquidar (PSL) no último dia do mês de referência. Neste campo são consideradas duas casas decimais. | sim |  |  | Numérico - NU | "10000 | 00" | 
dadosContabeis.provisaoSinistrosOcorridosNaoAvisados |  | Valor monetário da Provisão de Sinistros Ocorridos e não Avisados (IBNR) no último dia do mês de referência. Neste campo são consideradas duas casas decimais.  | sim |  |  | Numérico - NU | "10000 | 00" | 
dadosContabeis.provisaoValoresRegularizar |  | Valor monetário da Provisão de Valores a Regularizar no último dia do mês de referência. Neste campo são consideradas duas casas decimais. _x000D_ | sim |  |  | Numérico - NU | "10000 | 00" | 
dadosContabeis.outrasProvisoesTecnicas |  | Valor monetário de Outras Provisões Técnicas no último dia do mês de referência. Neste campo são consideradas duas casas decimais. _x000D_ | sim |  |  | Numérico - NU | "10000 | 00" | 
dadosContabeis.valorTotalSinistrosPagosMes |  | Valor monetário dos sinistros pagos no mês de referência. Neste campo são consideradas duas casas decimais. _x000D_ | sim |  |  | Numérico - NU | "10000 | 00" | 
dadosContabeis.demaisPassivos |  | Valor monetário dos demais passivos no último dia do mês de referência. Neste campo são consideradas duas casas decimais. _x000D_ | sim |  |  | Numérico - NU | "10000 | 00" | 
dadosContabeis.valorPatrimonioLiquido |  | Valor monetário do Patrimônio Líquido no último dia do mês de referência. Neste campo são consideradas duas casas decimais. _x000D_ | sim |  |  | Numérico - NU | "10000 | 00" | 
dadosContabeis.cmr |  | Valor monetário do Capital Mínimo Requerido (CMR) no último dia do mês de referência. Neste campo são consideradas duas casas decimais | sim |  |  | Numérico - NU | "10000 | 00" | 
dadosContabeis.estruturaSimplificada |  | "Determinar a opção no qual a seguradora com autorização temporária está enquadrada em seus investimentos |  no mês de referência. " | sim |  |  | Boolean | True / False | 
dadosContabeis.valorTotalPremiosEmitidosRetidos |  | "Valor monetário de prêmio emitido retido |  líquido de cosseguro e resseguro |  no mês de referência. _x000D_" | sim |  |  | Numérico - NU | "10000 | 00" | 
dadosContabeis.valorAtivoResseguroProvisoesTecnicas |  | "Valor monetário do ativo de resseguro |  no último dia do mês de referência" | sim |  |  | Numérico - NU | "10000 | 00" | 
dadosContabeis.valorAtivoResseguroRedutor |  | "Valor oferecido no mês de referência como ativo de resseguro redutor da necessidade de cobertura de provisões técnicas |  no último dia do mês de referência. " | sim |  |  | Numérico - NU | "10000 | 00" | 
dadosContabeis.valorTotalSinistrosAvisados |  | Valor monetário dos sinistros avisados no mês de referência. _x000D_ | sim |  |  | Numérico - NU | "10000 | 00" | 
dadosContabeis.valorTotalSinistrosAvisadosRetidos |  | "Valor monetário de sinistro avisado retido |  líquido de cosseguro e resseguro |  no mês de referência." | sim |  |  | Numérico - NU | "10000 | 00" | 

### Mapa Sandbox Sinistro Pendente

Campo | Equivalente Picsel | Descrição | Obrigatorio | Mascara | Tamanho | Tipo Preenchimento | Exemplo | Referencia
cnpj |  | CNPJ da sociedade seguradora  | sim |  | 14 | Alfanumerico - AN | 01234567891011' | 
sinistrosPendentes.mesReferencia | sinistros.DataHora | Ano e mês do mês de referência. | sim | AAAASS | 6 | Numérico - NU | "201601 - AAAA = ano |  SS = semestre" |  
sinistrosPendentes.ramo |  | Código do ramo a que se refere o movimento e que se encontra no edital de seleção no qual a supervisionada se submeteu. _x000D_ | sim |  | 3 | Alfanumerico - AN | 002' | "TABELA 04 – RAMOS (DE ACORDO COM O EDITAL)  |  pg 9 e 10"
sinistrosPendentes.numeroSinistro | sinistros.ID | "Corresponde ao número dado pela seguradora à comunicação da ocorrência de um evento (sinistro). Inclui o dígito verificador |  se houver" | sim |  |  | Alfanumerico - AN | """ABCDEF-123456""" | 
sinistrosPendentes.numeroApolice | sinistros.IDSeguros | "Corresponde ao número/código do contrato do seguro |  preenchido de acordo com a legislação vigente |  incluindo o dígito verificador se houver" | sim |  |  | Alfanumerico - AN | """APOLICE-PREMIO-01""" | 
sinistrosPendentes.dataOcorrenciaSinistro | sinistros.DataHora | Data de ocorrência do sinistro. O formato do campo deve ser: AAAA-MM-DD _x000D_ | sim | AAAA-MM-DD |  | Data - DT | """2021-06-01"" - AAAA = ano |  MM = mês |  DD = dia" | 
sinistrosPendentes.dataComunicacaoSinistro |  | Data em que a seguradora recebeu o aviso do sinistro. O formato do campo deve ser: AAAA-MM-DD  | sim | AAAA-MM-DD |  | Data - DT | """2021-05-30"" - AAAA = ano |  MM = mês |  DD = dia" | 
sinistrosPendentes.dataRegistroInicialSinistro | "Sinistros.DataSinistro
" | Data em que a seguradora registrou a ocorrência do sinistro. O formato do campo deve ser: AAAA-MM-DD _x000D_ | sim | AAAA-MM-DD |  | Data - DT | """2021-05-30"" - AAAA = ano |  MM = mês |  DD = dia" | 
sinistrosPendentes.valorSinistroPendente |  | Valor do Sinistro pendente no mês de referência. Neste campo são consideradas duas casas decimais. _x000D_ | sim |  |  | Numérico - NU | "1111 | 02" | 
sinistrosPendentes.valorSinistroPendenteRetido |  | Valor de Sinistro pendente retido no mês de referência. Neste campo são consideradas duas casas decimais.  |  |  |  | Numérico - NU | "1111 | 02" | 















