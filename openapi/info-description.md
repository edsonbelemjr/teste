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

# Política de Segurança

A política da Segurança de Informação da Picsel é um documento formal a respeito de seu comprometimento com a segurança dos recursos que geram, proliferam ou armazenam informações. 
A definição de todos os pontos abordados neste documento, foram apoiados pela alta direção, com o objetivo de estabelecer responsabilidades, diretrizes e eficiência para implementar a gestão de segurança da informação na empresa. Estando sempre abertas as revisões periódicas, mantendo-se alinhado com a legislação pertinente, com as normas brasileiras e com os objetivos do negócio. 

## Segurança da Informação

Para reprimir o risco de ocorrências de falhas que podem prejudicar de algum modo a Picsel, as informações devem ser adequadamente utilizadas, armazenadas e protegidas. Sendo assim, as propriedades que de devem ser preservadas para garantir a segurança das informações são as seguintes:
    • Confidencialidade: garante que a informação estará disponível somente para as pessoas, entidades ou processos autorizados;
    • Integridade: garante que a informação não pode ser alterada ou destruída sem a autorização adequada;
    • Disponibilidade: possibilita que os recursos estejam sempre acessíveis, ao ser solicitado por uma entidade autorizada;

A partir da adoção de uma boa estratégia, buscamos assegurar estes princípios.

## Importância da Segurança da Informação

Com o propósito de limitar a probabilidade de uma ameaça atingir a Confidencialidade, Integridade e Disponibilidade dos ativos de informações, como fraudes, espionagem, sabotagem, códigos maliciosos, entre outros, a Picsel preocupa-se com a segurança das suas informações.
Sendo assim, por meio de esforços contínuos e gerenciados, são criados alicerces para a proteção dos ativos de informação.

## A Empresa e a Política de Segurança

Todas as normas aqui estabelecidas serão seguidas à risca por todos colaboradores, parceiros e prestadores de serviços. Ao receber essa cópia da Política de Segurança, o/a Sr./Sra. comprometeu-se a respeitar todos os tópicos aqui abordados.

## Processos de Segurança da Informação

1. **Comunicação do Sistema** 
Todas as etapas de comunicação do sistema, principalmente nos acessos externos à nuvem, deverão contar com agentes identificados. 

2. **API’s de acesso interno**
Os acessos deverão ser limitados às VPCs (Virtual Private Cloud) correspondentes de modo a não permitir acesso externo. Cada recurso para acessar uma API deve conter uma chave correspondente. 

3. **API’s de acesso externo**
Estas API’s devem ser RESTful e contar com autenticação OAUTH2.0. Cada agente externo deverá ser cadastrado e terá acesso somente aos recursos autorizados para este usuário. Além disso cada agente externo deve ter seu acesso limitado em termos de número de requisições.

4. **Roles e Policies**
Devem ser configuradas para que nenhum recurso do sistema tenha permissões que não sejam necessárias à sua função. Portanto, os componentes do sistema devem ter seus privilégios elencados e ter acesso somente aos recursos necessários para execução dos mesmos. Seguindo assim, as políticas de confiança ZERO da AWS.

4.1 **SCP (Service Control Policies)**
Criação da SCP para limitar perímetro de produtos e serviços. 
As contas de ambientes já possuem a SCP aplicada. A SCP criada permite apenas produtos e serviços nas regiões:  us-east-1, us-east-2, sa-east-1. Portanto, ao utilizar as contas de ambiente não será permitido o acesso a outras regiões que não as citadas acima. 
 		
5. **Logins e Senhas**
Ao realizar a configuração interna de logins e senhas, estes devem ser armazenados no serviço AWS Secrets Manager, ou serviço semelhante. Deve ser realizada a renovação periódica das senhas.

6. **AWS SSO (Single Sign-On)**
O AWS SSO nos permite gerenciar com rapidez e facilidade o acesso dos colaboradores as contas da AWS. É possível criar a identidade dos usuários diretamente no AWS SSO e assim foi feito na Picsel. É indicado que contas empresariais utilizem o AWS SSO por oferecer um melhor gerenciamento para múltiplas contas e também por fornecer aos colaboradores um único local para acessar contas diferentes. O serviço do AWS SSO é um serviço gratuito. 
Link para acesso ao AWS SSO: https://picsel.awsapps.com/start
Foi enviado por e-mail a forma de acesso que os colaboradores que já possuíam conta IAM na AWS da Picsel devem utilizar para realizar o acesso no AWS SSO.
Para futuros colaboradores, deve-se realizar apenas a criação da conta SSO e conceder as devidas permissões.
![Picsel](https://i.imgur.com/khcibPC.png)

7. **Disponibilidade de serviços**
A arquitetura configurada no PEPITA deve contar com gerenciamento de fila (utilizando o recurso Serverless Application Model – SAM da AWS, ou similar) e balanceamento de cargo. Para assim, garantir a escalabilidade e a continuidade da disponibilização dos serviços disponibilizados em nuvem pela Picsel. Os serviços devem manter a capacidade através de múltiplas Zonas de Disponibilidade com serviços de backup para recovery. 

8. **Gerenciamento de código fonte**
Uma ferramenta para gerenciamento de código fonte permite organizar a interação entre desenvolvedores, garantir a integridade e possibilitar o gerenciamento de versões do código, evitando equívocos quanto a versão colocada em produção. Ex de ferramentas: GitLab, GitHub, BitBucket e etc.

9. **Buckets**
Para a criação de Buckets temos algumas boas práticas a serem seguidas, boas práticas essas que são apontadas pela própria AWS. Segue o link para verificação: https://docs.aws.amazon.com/pt_br/AmazonS3/latest/userguide/security-best-practices.html. Essas boas práticas tem como objetivo melhorar a seguração do S3 e evitar assim possíveis invasões e roubos de dados.

10. **Separação de Ambientes**
Deve-se separar os ambientes de Desenvolvimento/Testes/Homologação do ambiente de Produção. Utilizar bancos de dados distintos para cada ambiente. Utilizar servidores de aplicação/web distintos para cada ambiente. Prover acesso ao ambiente de Desenvolvimento/Testes/Homologação apenas aos integrantes da equipe de desenvolvimento e aos interessados no projeto (stakeholders). Deve-se realizar testes periódicos para assegurar a segurança do ambiente de desenvolvimento/testes/homologação. Não se deve fornecer as senhas de acesso ao ambiente de produção aos desenvolvedores.

10.1 **AWS Organizations**
Aws Organization está habilitado e temos as contas de DEV, PROD e HOMOL. Desta forma iremos realizar um gerenciamento centralizado das contas da AWS e manter uma melhor organização do desenvolvimento e aplicação dos serviços e produtos sem gerar impactos no ambiente de produção. As contas de ambiente já possuem o SCP de perímetro.
![](https://i.imgur.com/LWWvMeq.png)

11. **Análise de Vulnerabilidades** 
Deve ser utilizada ferramenta de segurança para análise do código a ser entregue. Essa análise tem como objetivo encontrar possíveis vulnerabilidades no código que podem colocar em risco as informações da empresa. 
É uma boa pratica verificar sempre se as bibliotecas utilizadas possuem vulnerabilidades, na utilização do Python por exemplo, é possível utilizar o pip para verificar se há alguma biblioteca com vulnerabilidade. Caso seja encontrada deve-se verificar se há alguma atualização sem a vulnerabilidade ou a correção da mesma.
Indicamos a utilização da ferramenta Insider, a mesma pode ser executada tanto pontualmente quanto em esteiras, integrando com o CI/CD. A indicação da ferramenta Insider é por ela utilizar as tecnologias SAST (Static Application Security Testing), SCA (Software Composition Analysis) e DRA (Digital Risk Analysis) em uma única análise.
O Insider encontra vulnerabilidades em Android, Android-Java, Android-Kotlin, Java Gradle, Java Maven, Typescript, Javascript, AngularJS, Ionic, React, React Native, Swift (IOS), C#, Ruby on rails, Python e Flutter.
A ferramenta insider não é uma ferramenta open, deve-se verificar com a Picsel o interesse em adquirir a mesma ou a decisão por utilizar uma ferramenta open (Ex: Horusec) que não terá tantos recursos disponíveis.

12. **Lei Geral de Proteção de Dados – LGPD**
A LGPD (Lei nº 13.709/2018) foi sancionada em agosto de 2018 e entrou em vigor em agosto de 2020, estabelecendo como data limite para adequação o mês de maio de 2021.
O objetivo da LGPD é bem claro: proteger dados pessoais (sensíveis ou não) e garantir privacidade aos usuários da Internet. 

**O que seriam dados pessoais e dados pessoais sensíveis?**
O art. 5º, inciso I, da LGPD conceitua dados pessoais como: “informação relacionada a pessoa natural identificada ou identificável.” São esses dados cadastrais, data de nascimento, profissão, dados de GPS, identificadores eletrônicos, nacionalidade, gostos, interesses e hábitos de consumo, entre outros. 

O inciso II, do art. 5º, conceitua dados sensíveis sendo todo aquele com conteúdo “sobre origem racial ou étnica, convicção religiosa, opinião política, filiação a sindicato ou a organização de caráter religioso, filosófico ou político, dado referente à saúde ou à vida sexual, dado genético ou biométrico, quando vinculado a uma pessoa natural.” Ou seja, são aqueles dados que podem levar a discriminação de uma pessoa e, por tal motivo, devem ser considerados e tratados como dados sensíveis.

Essa diferenciação é feita pois o uso de dados pessoais sensíveis deverá ser realizado com mais cuidado, já que um possível incidente de vazamento de dados com esse tipo de dado poderia causar consequências graves. Uma boa prática é não solicitar esses dados ao cliente caso não seja extremamente necessário.
A Autoridade Nacional de Proteção de Dados (ANPD) é responsável por fiscalizar a adequação à Lei, verificar denúncias e aplicar sanções apropriadas. O descumprimento da LGPD implicará no caso de agentes públicos, punições próprias da improbidade administrativa. Já no caso das instituições privadas, a advertência e aplicação de pesadas sanções.

12.1 **Boas Práticas para inserir a LGPD no projeto**
**Crie uma política de privacidade:**  É importante informar aos usuários quais informações coletadas serão usadas e por quais motivos elas foram solicitadas. Deve ficar claro como os dados serão armazenados e os responsáveis nos casos de vazamentos e violações. Inclua as medidas de segurança e o que será adotado para inibir qualquer constrangimento. É preciso comunicar também se os dados são compartilhados com terceiros – o que não é indicado. O proprietário do site precisa informar ainda como os cookies são utilizados e em quais canais os usuários poderão entrar em contato com a empresa. Inclua o período em que essas informações ficarão armazenadas, assim como o processo utilizado para excluí-las. Não se esqueça de disponibilizar um link para que o usuário cancele o cadastro ou reveja suas opções a qualquer momento.  

**Atente-se às páginas de contato:** A maioria dos sites tem uma área padrão para que o usuário entre em contato com o proprietário da página. Para isso, esse ambiente dispõe de um formulário com campos para preenchimento do nome, e-mail e uma mensagem opcional. Nós já falamos aqui que os dados pessoais devem ser utilizados apenas mediante o claro consentimento do usuário, certo? Para garantir isso nas páginas de contato, você pode: 

- Adicionar uma caixa de seleção ao formulário de contato. O usuário deve confirmar, por meio da seleção da opção, que leu e concorda com os termos e política de privacidade do site. 
- Incluir links clicáveis facilitando para que o usuário leia os termos de consentimento e a política de privacidade. Tome cuidado para que sejam abertos em uma nova guia para que o usuário não tenha que deixar a página original. 
- Fazer com que esse campo de consentimento seja obrigatório para que o usuário prossiga. Não deixe a caixa de seleção pré-selecionada. 
- Incluir na descrição do conteúdo outras formas de contato: um número de telefone, e-mail, endereço e botões para acesso às redes sociais.
- Informar ao usuário que o acesso ao conteúdo e seu livre e pessoal consentimento podem ser executados apenas para maiores de idade. Menores de 18 anos devem receber o aval de seus responsáveis legais; 
- Parece óbvio, mas é fundamental que todos os dados coletados no formulário sejam armazenados de forma segura, como por exemplo, no sistema de gerenciamento de conteúdo do seu site. Essas informações devem ser salvas em uma página protegida por um certificado SSL, que estabelece um link criptografado entre o servidor e o navegador.

**Investir em cibersegurança:**  Não há um requisito específico na lei que obrigue a instalação de um certificado SSL em seu site (o famoso cadeado verde na barra de endereços do navegador HTML), mas é uma boa prática de cibersegurança que ele seja inserido. Certificados de segurança no site garantem maior confiabilidade e inibem mensagens de erro como “este site não é seguro”. Além disso, na prática, por meio deles, os dados preenchidos em formulários podem ser criptografados antes do envio ao servidor, o que protege as informações pessoais dos usuários. Outra vantagem de instalar certificados de segurança é o ranqueamento em ferramentas de busca, garantindo uma melhor classificação e resultados de visualização. Deve-se também realizar auditorias periódicas e gestão de vulnerabilidades nos locais em que os dados são armazenados, ter um plano de contingência para casos de violação. 

**Explique o uso de cookies (Caso utilize):** Os cookies – pequenos arquivos baixados no equipamento enquanto o usuário navega no site – bastante utilizados para listas de e-mail marketing, também entram neste manual de boas práticas. Afinal, o uso de cookies permite o acesso a dados pessoais, como reconhecimento do dispositivo, preferências e ações do usuário na Internet. Então, é importante que você se preocupe em informar os usuários sobre o uso de cookies, explicar quais os motivos desse uso e obter o consentimento da pessoa para utilizar essa estratégia.

**Tenha uma política de exclusão de dados:** Para que se torne compatível à LGPD, também é preciso criar uma política de exclusão regular desses dados. Essa política deve ser previamente documentada no processo de manipulação e coleta dos dados. Para facilitar ainda mais, você pode optar por um sistema de exclusão automática de dados sensíveis e documentos críticos após o download, para que eles não sejam armazenados no CMS (Content Management System) do site e haja a limpeza regular de dados e documentos armazenados no sistema de gerenciamento de conteúdo.
	      

# Arquitetura

## Mapa Apólice e Sinistro
![Arquitetura](https://i.imgur.com/et45dSU.jpeg)

## Susep Sandbox
![](https://i.imgur.com/9KG7Oxs.jpeg)

## Enviar Proposta
![](https://i.imgur.com/qFsgpHG.jpeg)





# Payloads SUSEP - Sandbox Regulatório

## susep-auth-token-response

## susep-sandbox-sinistro-pendente

## susep-sandbox-sinistro

## susep-sandbox-premio

## susep-sandbox-contabil-1sem

## susep-sandbox-reclamacao




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

## Mapa Sandbox Sinistro

<div style="overflow-x:auto;">
    <table style='width: 2400px;'>
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
                <td>sinistros.numeroSinistro</td>
                <td>sinistros.idsinistro</td>
                <td>Corresponde ao número dado pela seguradora à comunicação da ocorrência de um evento (sinistro). Inclui o dígito verificador, se for o caso. _x005F_x000D_</td>
                <td>sim</td>
                <td></td>
                <td></td>
                <td>Alfanumerico - AN</td>
                <td>"ABCDEF-123456"</td>
                <td></td>
            </tr>
            <tr>
                <td>sinistros.numeroApolice</td>
                <td>Aguardando Implementação</td>
                <td>Corresponde ao número/código do contrato do seguro, preenchido de acordo com a legislação vigente, incluindo o dígito verificador se houver</td>
                <td>sim</td>
                <td></td>
                <td></td>
                <td>Alfanumerico - AN</td>
                <td>"APOLICE-PREMIO-01"</td>
                <td></td>
            </tr>
            <tr>
                <td>sinistros.maxima</td>
                <td>Será implementado na API</td>
                <td>Valor monetário da maior importância segurada para cobertura de um risco isolado. Neste campo são consideradas duas casas decimais.</td>
                <td>sim</td>
                <td></td>
                <td></td>
                <td>Numérico - NU</td>
                <td>10000,00</td>
                <td></td>
            </tr>
            <tr>
                <td>sinistros.identificacaoSegurado</td>
                <td>Seguros.seguros.CPFProdutor</td>
                <td>Corresponde ao CPF ou CNPJ do Segurado</td>
                <td>sim</td>
                <td></td>
                <td>11 ou 14</td>
                <td>Alfanumerico - AN</td>
                <td>01234567891011'</td>
                <td></td>
            </tr>
            <tr>
                <td>sinistros.identificacaoBeneficiario</td>
                <td>Aguardando Implementação</td>
                <td>Corresponde ao CPF ou CNPJ do beneficiário</td>
                <td>sim</td>
                <td></td>
                <td>11 ou 14</td>
                <td>Alfanumerico - AN</td>
                <td>01234567891011'</td>
                <td></td>
            </tr>
            <tr>
                <td>sinistros.identificacaoCobertura</td>
                <td>Aguardando Implementação</td>
                <td>Corresponde ao tipo de cobertura contratado. Tabela de Referência 05 </td>
                <td>sim</td>
                <td></td>
                <td>2</td>
                <td>Alfanumerico - AN</td>
                <td>"01"</td>
                <td>TABELA 05 – TIPOS DE COBERTURA, pg 10</td>
            </tr>
            <tr>
                <td>sinistros.identificacaoObjetoSinistrado</td>
                <td>Aguardando Implementação</td>
                <td>Corresponde ao tipo de objeto sinistrado. Tabela de Referência 06</td>
                <td>sim</td>
                <td></td>
                <td>3</td>
                <td>Alfanumerico - AN</td>
                <td>"010"</td>
                <td>TABELA 06 – TIPOS DE OBJETO, pg 11</td>
            </tr>
            <tr>
                <td>sinistros.tipoSinistro</td>
                <td>Aguardando Implementação</td>
                <td>Corresponde ao tipo de sinistro que pode ser administrativo ou judicial. Tabela de Referência 07 </td>
                <td>sim</td>
                <td></td>
                <td>2</td>
                <td>Alfanumerico - AN</td>
                <td>"01"</td>
                <td>TABELA 07 – TIPOS DE SINISTRO, pg 11</td>
            </tr>
            <tr>
                <td>sinistros.tipoMovimento</td>
                <td>Aguardando Implementação</td>
                <td>Corresponde ao código do tipo de movimento do sinistro. Tabela de Referência 08</td>
                <td>sim</td>
                <td></td>
                <td>2</td>
                <td>Alfanumerico - AN</td>
                <td>"01"</td>
                <td>TABELA 08 – TIPOS DE MOVIMENTO DE SINISTRO, pg 11</td>
            </tr>
            <tr>
                <td>sinistros.valorMovimento</td>
                <td>Aguardando Implementação</td>
                <td>Corresponde ao valor monetário movimentado no sinistro de acordo com o tipo de movimento. Neste campo são consideradas duas casas decimais</td>
                <td>sim</td>
                <td></td>
                <td></td>
                <td>Numérico - NU</td>
                <td>10000,00</td>
                <td></td>
            </tr>
            <tr>
                <td>sinistros.valorMovimentoRetido</td>
                <td>Aguardando Implementação</td>
                <td>Corresponde ao valor monetário retido movimentado no sinistro de acordo com o tipo de movimento. Neste campo são consideradas duas casas decimais._x005F_x000D_</td>
                <td>sim</td>
                <td></td>
                <td></td>
                <td>Numérico - NU</td>
                <td>10000,00</td>
                <td></td>
            </tr>
            <tr>
                <td>sinistros.dataOcorrenciaSinistro</td>
                <td>Sinistros.DataSinistro</td>
                <td>Data de ocorrência do sinistro. O formato do campo deve ser: AAAA-MM-DD </td>
                <td>sim</td>
                <td>AAAA-MM-DD</td>
                <td></td>
                <td>Data - DT</td>
                <td>"2020-04-11"</td>
                <td></td>
            </tr>
            <tr>
                <td>sinistros.dataComunicacaoSinistro</td>
                <td>sinistros.DataHora</td>
                <td>Data em que a seguradora recebeu o aviso do sinistro. O formato do campo deve ser: AAAA-MMDD</td>
                <td>sim</td>
                <td>AAAA-MM-DD</td>
                <td></td>
                <td>Data - DT</td>
                <td>"2020-04-11"</td>
                <td></td>
            </tr>
            <tr>
                <td>sinistros.dataRegistroInicialSinistro</td>
                <td>sinistros.DataHora</td>
                <td>Data em que a seguradora registrou a ocorrência do sinistro. O formato do campo deve ser: AAAA-MMDD _x005F_x000D_</td>
                <td>sim</td>
                <td>AAAA-MM-DD</td>
                <td></td>
                <td>Data - DT</td>
                <td>"2020-04-11"</td>
                <td></td>
            </tr>
            <tr>
                <td>sinistros.statusSinistro</td>
                <td>Aguardando Implementação</td>
                <td>Corresponde à situação do sinistro no momento do registro da movimentação. Tabela de Referência 09 </td>
                <td>sim</td>
                <td></td>
                <td>2</td>
                <td>Alfanumerico - AN</td>
                <td>"01"</td>
                <td>TABELA 09 – STATUS DO SINISTRO, pg 11 e 12</td>
            </tr>
            <tr>
                <td>sinistros.justificativaNegativa</td>
                <td>Aguardando Implementação</td>
                <td>Corresponde à justificativa em caso de negativa de sinistro. Tabela de Referência 10</td>
                <td>sim</td>
                <td></td>
                <td>2</td>
                <td>Alfanumerico - AN</td>
                <td>"01"</td>
                <td>TABELA 10 – JUSTIFICATIVA DE NEGATIVA, pg 12</td>
            </tr>
        </tbody>
    </table>
</div>

## Mapa Sandbox Reclamação

<div style="overflow-x:auto;">
    <table style='width: 2400px;'>
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
<table style='width: 2600px;'>
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













