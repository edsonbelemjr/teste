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
```
{
    "access_token":"eyJhbGciOiJSUzI1NiIsImtpZCI6Ijc0YTc2ZTVlODRhNjg2ZWIyZThhYzU3NmJmNDlkMjA5IiwidHlwIjoiSldUIn0.eyJuYmYiOjE1ODgyNTQ4NzUsImV4cCI6MTU4ODI1ODQ3NSwiaXNzIjoiaHR0cDovL2hvbW9sb2cyLnN1c2VwLmdvdi5ici9zYWZlL2F1dGVudGljYWNhbyIsImF1ZCI6WyJodHRwOi8vaG9tb2xvZzIuc3VzZXAuZ292LmJyL3NhZmUvYXV0ZW50aWNhY2FvL3Jlc291cmNlcyIsInNyZC53ZWIiXSwiY2xpZW50X2lkIjoic3JkLndlYiIsInN1YiI6IjNhZDkyMDIzLTBhNGMtNDdiNC1iYzIyLTEwOGRmNTM5ZDIzZSIsImF1dGhfdGltZSI6MTU4ODI1NDg3NSwiaWRwIjoibG9jYWwiLCJuYW1lIjoiVGVzdGUgU3VzZXAiLCJlbnRpZGFkZUlkIjoiMiIsImp0aSI6ImQxMGMwMmRkNGQyOTJlYzFhMDhmNzZlNDU1NDk2MTVmIiwic2NvcGUiOlsic3JkLndlYiJdLCJhbXIiOlsicHdkIl19.YdADx6qEGEjL6EvdHaeBOvo0PWjKqhu9tyIzYfUDqN2iRgOUFbW7DAfXmWl5Yb4W_nt5kPi1lSxug5O5HBFT27YrjJOyu3NkXWq9NXGzznZUuJj4WB6FtTRd82PenvbRdPo0J_4vz_eaHMk5Nqe9AuiVuDhaYxV-ocYHl9HHy0-a3F0trIm3ZfwnnVmH4ILV5Wpc6Jkr7-jZWDV78z0BdUcNior6LVLZFKAvcSBvw57Agw8GcjKwrKJQA7LRSjjUmHxCLlJX0I0T2v3UaUzXIkMgRbc O-OaYuuavG5CJInLDn7XejrYJGG8tYiw556ARAUeYtEDJDbyIYW036-CGg",
     "expires_in": 3600, 
     "token_type": "Bearer" 
}
```

## susep-sandbox-sini-pendente
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

## Mapa Cancelar Apolice

<div style="overflow-x:auto;">
    <table style='width: 1100px;'>
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
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>cdProposta</td>
                <td>Aguardando Implementação</td>
                <td>Código da proposta gerado pelo MAPA</td>
                <td>Sim</td>
                <td>N.A.</td>
                <td>9</td>
                <td>Numérico - NU</td>
                <td></td>
            </tr>
        </tbody>
    </table>
</div>

## Mapa Enviar Apolice

<div style="overflow-x:auto;">
    <table style='width: 1200px;'>
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
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>cdProposta</td>
                <td>Aguardando Implementação</td>
                <td>Código da proposta gerado pelo MAPA</td>
                <td>Sim</td>
                <td>N.A.</td>
                <td>9</td>
                <td>Numérico - NU</td>
                <td></td>
            </tr>
            <tr>
                <td>nrApolice</td>
                <td>seguros.ID</td>
                <td>Número da apólice emitida pela seguradora</td>
                <td>Sim</td>
                <td>N.A.</td>
                <td>20</td>
                <td>Alfanumérico sem caracteres especiais - AS</td>
                <td></td>
            </tr>
            <tr>
                <td>dtApolice</td>
                <td>Aguardando Implementação</td>
                <td>Data que a apolice foi gerada</td>
                <td>Sim</td>
                <td>N.A.</td>
                <td>10</td>
                <td>Data - DT</td>
                <td>20/01/2022</td>
            </tr>
        </tbody>
    </table>
</div>

## Mapa Alterar Apolice

<div style="overflow-x:auto;">
    <table style='width: 1500px;'>
        <thead>
            <tr>
                <th>Campo</th>
                <th>Equivalente Picsel</th>
                <th>Descrição</th>
                <th>Obrigatorio</th>
                <th>Editável</th>
                <th>Mascara</th>
                <th>Tamanho</th>
                <th>Tipo Preenchimento</th>
                <th>Exemplo</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>cdProposta</td>
                <td>Aguardando Implementação</td>
                <td>Código da proposta gerado pelo MAPA</td>
                <td>Sim</td>
                <td>Não</td>
                <td>N.A.</td>
                <td>9</td>
                <td>Numérico - NU</td>
                <td></td>
            </tr>
            <tr>
                <td>nrApolice</td>
                <td>seguros.ID</td>
                <td>Número da apólice emitida pela seguradora</td>
                <td>Sim</td>
                <td>Não</td>
                <td>N.A.</td>
                <td>10</td>
                <td>Numérico - NU</td>
                <td></td>
            </tr>
            <tr>
                <td>dtApolice</td>
                <td>Aguardando Implementação</td>
                <td>Data que a apolice foi gerada</td>
                <td>Não</td>
                <td>Sim</td>
                <td>N.A.</td>
                <td>11</td>
                <td>Data - DT</td>
                <td>20/01/2022</td>
            </tr>
            <tr>
                <td>nrProcessoSusep</td>
                <td>Aguardando Implementação</td>
                <td>Número do processo enviado à SUSEP</td>
                <td>Não</td>
                <td>Sim</td>
                <td>N.A.</td>
                <td>17</td>
                <td>Numérico - NU</td>
                <td></td>
            </tr>
            <tr>
                <td>nmSegurado</td>
                <td>seguros.NomeProdutor</td>
                <td>Nome do Segurado. Ex.: Jóse Joaquim da Silva</td>
                <td>Não</td>
                <td>Sim</td>
                <td>N.A.</td>
                <td>100</td>
                <td>Alfanumérico - AN</td>
                <td></td>
            </tr>
            <tr>
                <td>nrTelefoneSegurado</td>
                <td>Aguardando Implementação</td>
                <td>Número do telefone do segurado</td>
                <td>Não</td>
                <td>Sim</td>
                <td>N.A.</td>
                <td>11</td>
                <td>Numérico - NU</td>
                <td>11960707070</td>
            </tr>
            <tr>
                <td>nrCepSegurado</td>
                <td>seguros.CEPProdutor</td>
                <td>CEP do segurado, apenas os numeros.</td>
                <td>Não</td>
                <td>Sim</td>
                <td>N.A.</td>
                <td>8</td>
                <td>Numérico - NU</td>
                <td>8773000</td>
            </tr>
            <tr>
                <td>txComplementoEnderecoSegurado</td>
                <td>Aguardando Implementação</td>
                <td>Complemento do endereço do segurado</td>
                <td>Não</td>
                <td>Sim</td>
                <td>N.A.</td>
                <td>50</td>
                <td>Alfanumérico - AN</td>
                <td></td>
            </tr>
            <tr>
                <td>nrComplementoSegurado</td>
                <td>Aguardando Implementação</td>
                <td>Número do complemento do endereço do segurado</td>
                <td>Não</td>
                <td>Sim</td>
                <td>N.A.</td>
                <td>10</td>
                <td>Alfanumérico - AN</td>
                <td></td>
            </tr>
            <tr>
                <td>nmPropriedade</td>
                <td>Aguardando Implementação</td>
                <td>Nome da propriedade</td>
                <td>Não</td>
                <td>Sim</td>
                <td>N.A.</td>
                <td>60</td>
                <td>Alfanumérico - AN</td>
                <td></td>
            </tr>
            <tr>
                <td>txComplementoEnderecoPropriedade</td>
                <td>seguros.EnderecoProdutor</td>
                <td>Descrição do complemento da propriedade</td>
                <td>Não</td>
                <td>Sim</td>
                <td>N.A.</td>
                <td>50</td>
                <td>Alfanumérico - AN</td>
                <td></td>
            </tr>
            <tr>
                <td>nrComplementoPropriedade</td>
                <td>seguros.BairroProdutor</td>
                <td>Número do complemento da propriedade</td>
                <td>Não</td>
                <td>Sim</td>
                <td>N.A.</td>
                <td>10</td>
                <td>Alfanumérico - AN</td>
                <td></td>
            </tr>
            <tr>
                <td>csFormatoCoordenada</td>
                <td>Aguardando Implementação</td>
                <td>Formato das coordenadas da propriedade</td>
                <td>Sim</td>
                <td>Sim</td>
                <td>N.A.</td>
                <td>2</td>
                <td>Char - CH</td>
                <td></td>
            </tr>
            <tr>
                <td>nrDecimalLatitude</td>
                <td>Aguardando Implementação</td>
                <td>Número em decimal da latitude da propriedade</td>
                <td>Não</td>
                <td>Sim</td>
                <td>N.A.</td>
                <td>30</td>
                <td>Numérico - NU</td>
                <td></td>
            </tr>
            <tr>
                <td>nrDecimalLongitude</td>
                <td>Aguardando Implementação</td>
                <td>Número em decimal da longitude da propriedade</td>
                <td>Não</td>
                <td>Sim</td>
                <td>N.A.</td>
                <td>30</td>
                <td>Numérico - NU</td>
                <td></td>
            </tr>
            <tr>
                <td>nrGrauLatitude</td>
                <td>Aguardando Implementação</td>
                <td>Número em grau da latitude da propriedade</td>
                <td>Não</td>
                <td>Sim</td>
                <td>N.A.</td>
                <td>2</td>
                <td>Numérico - NU</td>
                <td></td>
            </tr>
            <tr>
                <td>nrMinutoLatitude</td>
                <td>Aguardando Implementação</td>
                <td>Número em minuto da latitude da propriedade</td>
                <td>Não</td>
                <td>Sim</td>
                <td>N.A.</td>
                <td>2</td>
                <td>Numérico - NU</td>
                <td></td>
            </tr>
            <tr>
                <td>nrSegundoLatitude</td>
                <td>Aguardando Implementação</td>
                <td>Número em segundo da latitude da propriedade</td>
                <td>Não</td>
                <td>Sim</td>
                <td>N.A.</td>
                <td>2</td>
                <td>Numérico - NU</td>
                <td></td>
            </tr>
            <tr>
                <td>csOrientacaoLatitude</td>
                <td>Aguardando Implementação</td>
                <td>Orientação da latitude da propriedade</td>
                <td>Não</td>
                <td>Sim</td>
                <td>N.A.</td>
                <td>1</td>
                <td>Char - CH</td>
                <td></td>
            </tr>
            <tr>
                <td>nrGrauLongitude</td>
                <td>Aguardando Implementação</td>
                <td>Número em grau da longitude da propriedade</td>
                <td>Não</td>
                <td>Sim</td>
                <td>N.A.</td>
                <td>2</td>
                <td>Numérico - NU</td>
                <td></td>
            </tr>
            <tr>
                <td>nrMinutoLongitude</td>
                <td>Aguardando Implementação</td>
                <td>Número em minuto da longitude da propriedade</td>
                <td>Não</td>
                <td>Sim</td>
                <td>N.A.</td>
                <td>2</td>
                <td>Numérico - NU</td>
                <td></td>
            </tr>
            <tr>
                <td>nrSegundoLongitude</td>
                <td>Aguardando Implementação</td>
                <td>Número em segundo da longitude da propriedade</td>
                <td>Não</td>
                <td>Sim</td>
                <td>N.A.</td>
                <td>2</td>
                <td>Numérico - NU</td>
                <td></td>
            </tr>
            <tr>
                <td>csOrientacaoLongitude</td>
                <td>Aguardando Implementação</td>
                <td>Orientação da longitude da propriedade</td>
                <td>Não</td>
                <td>Sim</td>
                <td>N.A.</td>
                <td>1</td>
                <td>Numérico - NU</td>
                <td></td>
            </tr>
            <tr>
                <td>nrAreaTotal</td>
                <td>seguros.AreaSegurada</td>
                <td>Número da área total segurada</td>
                <td>Não</td>
                <td>Sim</td>
                <td>N.A.</td>
                <td>9,2</td>
                <td>Numérico - NU</td>
                <td></td>
            </tr>
            <tr>
                <td>nrPe</td>
                <td>Aguardando Implementação</td>
                <td>Número de pés</td>
                <td>Não</td>
                <td>Sim</td>
                <td>N.A.</td>
                <td>7</td>
                <td>Numérico - NU</td>
                <td></td>
            </tr>
            <tr>
                <td>nrVolume</td>
                <td>Aguardando Implementação</td>
                <td>Número do volume</td>
                <td>Não</td>
                <td>Sim</td>
                <td>N.A.</td>
                <td>9,2</td>
                <td>Numérico - NU</td>
                <td></td>
            </tr>
            <tr>
                <td>nrProdutividadeSegurada</td>
                <td>seguros.ProdutividadeGarantida</td>
                <td>Número de produtividade a ser sergurada (kg/ha)</td>
                <td>Não</td>
                <td>Sim</td>
                <td>N.A.</td>
                <td>12,2</td>
                <td>Numérico - NU</td>
                <td></td>
            </tr>
            <tr>
                <td>nrProdutividadeEstimada</td>
                <td>seguros.Produtividade</td>
                <td>Número de produtividade estimada (kg/ha)</td>
                <td>Não</td>
                <td>Sim</td>
                <td>N.A.</td>
                <td>12,2</td>
                <td>Numérico - NU</td>
                <td></td>
            </tr>
            <tr>
                <td>nrAnimal</td>
                <td>Aguardando Implementação</td>
                <td>Número de animais</td>
                <td>Não</td>
                <td>Sim</td>
                <td>N.A.</td>
                <td>5</td>
                <td>Numérico - NU</td>
                <td></td>
            </tr>
            <tr>
                <td>vlLimiteGarantia</td>
                <td>Aguardando Implementação</td>
                <td>Valor do limite de garantia (LMGA)</td>
                <td>Não</td>
                <td>Sim</td>
                <td>N.A.</td>
                <td>14,2</td>
                <td>Numérico - NU</td>
                <td></td>
            </tr>
            <tr>
                <td>vlPremio</td>
                <td>Aguardando Implementação</td>
                <td>Valor do prêmio líquido</td>
                <td>Não</td>
                <td>Sim</td>
                <td>N.A.</td>
                <td>14,2</td>
                <td>Numérico - NU</td>
                <td></td>
            </tr>
            <tr>
                <td>vlSubvencaoFederal</td>
                <td>Aguardando Implementação</td>
                <td>Valor da subvenção federal</td>
                <td>Não</td>
                <td>Sim</td>
                <td>N.A.</td>
                <td>14,2</td>
                <td>Numérico - NU</td>
                <td></td>
            </tr>
            <tr>
                <td>peNivelCobertura</td>
                <td>Aguardando Implementação</td>
                <td>Informa a porcentagem do nível de cobertura</td>
                <td>Não</td>
                <td>Sim</td>
                <td>N.A.</td>
                <td>2</td>
                <td>Numérico - NU</td>
                <td></td>
            </tr>
            <tr>
                <td>cdClassificacaoProduto</td>
                <td>Aguardando Implementação</td>
                <td>Código da classificação do produto</td>
                <td>Não</td>
                <td>Sim</td>
                <td>N.A.</td>
                <td>2</td>
                <td>Numérico - NU</td>
                <td></td>
            </tr>
            <tr>
                <td>idItemUnidadeSegurada</td>
                <td>Aguardando Implementação</td>
                <td>Identificador da Unidade Segurada</td>
                <td>Não</td>
                <td>Sim</td>
                <td>N.A.</td>
                <td>10</td>
                <td>Numérico - NU</td>
                <td></td>
            </tr>
            <tr>
                <td>nrArea</td>
                <td>seguros.AreaSegurada</td>
                <td>Área – área da unidade segurada</td>
                <td>Não</td>
                <td>Sim</td>
                <td>N.A.</td>
                <td>9,2</td>
                <td>Numérico - NU</td>
                <td></td>
            </tr>
            <tr>
                <td>idCobertura</td>
                <td>Aguardando Implementação</td>
                <td>Identificador da cobertura</td>
                <td>Não</td>
                <td>Sim</td>
                <td>N.A.</td>
                <td>10</td>
                <td>Numérico - NU</td>
                <td></td>
            </tr>
            <tr>
                <td>cdEventoCobertura</td>
                <td>Aguardando Implementação</td>
                <td>Cobertura - Tipo de cobertura garantida pela proposta.</td>
                <td>Não</td>
                <td>Sim</td>
                <td>N.A.</td>
                <td>3</td>
                <td>Numérico - NU</td>
                <td></td>
            </tr>
            <tr>
                <td>peFranquia</td>
                <td>Aguardando Implementação</td>
                <td>Franquia - Percentual da Franquia.</td>
                <td>Não</td>
                <td>Sim</td>
                <td>N.A.</td>
                <td>2</td>
                <td>Numérico - NU</td>
                <td></td>
            </tr>
            <tr>
                <td>vlLimiteMaximoIndenizacao</td>
                <td>Aguardando Implementação</td>
                <td>LMI - Limite máximo de Indenização</td>
                <td>Não</td>
                <td>Sim</td>
                <td>N.A.</td>
                <td>14,2</td>
                <td>Numérico - NU</td>
                <td></td>
            </tr>
            <tr>
                <td>itensUnidadeSegurada.idItemUnidadeSegurada</td>
                <td>Aguardando Implementação</td>
                <td>Identificador da Unidade Segurada</td>
                <td>Não</td>
                <td>Sim</td>
                <td>N.A.</td>
                <td>10</td>
                <td>Numérico - NU</td>
                <td></td>
            </tr>
            <tr>
                <td>itensUnidadeSegurada.nrArea</td>
                <td>Aguardando Implementação</td>
                <td>Área – área da unidade segurada</td>
                <td>Não</td>
                <td>Sim</td>
                <td>N.A.</td>
                <td>9,2</td>
                <td>Numérico - NU</td>
                <td></td>
            </tr>
            <tr>
                <td>cobertura.idCobertura</td>
                <td>Aguardando Implementação</td>
                <td>Identificador da cobertura</td>
                <td>Não</td>
                <td>Sim</td>
                <td>N.A.</td>
                <td>10</td>
                <td>Numérico - NU</td>
                <td></td>
            </tr>
            <tr>
                <td>cobertura.cdEventoCobertura</td>
                <td>Aguardando Implementação</td>
                <td>Cobertura - Tipo de cobertura garantida pela proposta.</td>
                <td>Não</td>
                <td>Sim</td>
                <td>N.A.</td>
                <td>3</td>
                <td>Numérico - NU</td>
                <td></td>
            </tr>  
            <tr>
                <td>cobertura.peFranquia</td>
                <td>Aguardando Implementação</td>
                <td>Franquia - Percentual da Franquia.</td>
                <td>Não</td>
                <td>Sim</td>
                <td>N.A.</td>
                <td>2</td>
                <td>Numérico - NU</td>
                <td></td>
            </tr>  
            <tr>
                <td>cobertura.vlLimiteMaximoIndenizacao</td>
                <td>Aguardando Implementação</td>
                <td>LMI - Limite máximo de Indenização</td>
                <td>Não</td>
                <td>Sim</td>
                <td>N.A.</td>
                <td>14,2</td>
                <td>Numérico - NU</td>
                <td></td>
            </tr>  
        </tbody>
    </table>
</div>

## Mapa Cancelar Apolice

<div style="overflow-x:auto;">
    <table style='width: 1500px;'>
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
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>cdProposta</td>
                <td>Aguardando Implementação</td>
                <td>Código da proposta gerado pelo MAPA</td>
                <td>Sim</td>
                <td>N.A.</td>
                <td>9</td>
                <td>Numérico - NU</td>
                <td></td>
            </tr>
        </tbody>
    </table>
</div>


## Mapa Enviar Sinistro

<div style="overflow-x:auto;">
    <table style='width: 1300px;'>
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
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>cdProposta</td>
                <td>Aguardando Implementação</td>
                <td>Código da proposta gerado pelo MAPA</td>
                <td>Sim</td>
                <td>N.A.</td>
                <td>9</td>
                <td>Numérico - NU</td>
                <td></td>
            </tr>
            <tr>
                <td>nrApolice</td>
                <td>seguros.id</td>
                <td>Número da apólice</td>
                <td>Sim</td>
                <td>N.A.</td>
                <td>20</td>
                <td>Alfanumérico sem caracteres especiais - AS</td>
                <td></td>
            </tr>
            <tr>
                <td>cdEventoCobertura</td>
                <td>Aguardando Implementação</td>
                <td>Código do evento/Cobetura do sinistro</td>
                <td>Sim</td>
                <td>N.A.</td>
                <td>4</td>
                <td>Numérico - NU</td>
                <td></td>
            </tr>
            <tr>
                <td>dtAvisoSinistro</td>
                <td>sinistro.DataSinistro</td>
                <td>Data do aviso do sinistro</td>
                <td>Sim</td>
                <td>dd/MM/yyyy</td>
                <td>10</td>
                <td>Data - DT</td>
                <td>20/01/2022</td>
            </tr>
            <tr>
                <td>vlReservaTecnica</td>
                <td>Aguardando Implementação</td>
                <td>Valor da Reserva Técnica</td>
                <td>Sim</td>
                <td>N.A.</td>
                <td>12,2</td>
                <td>Numérico - NU</td>
                <td></td>
            </tr>
        </tbody>
    </table>
</div>

## Mapa Alterar Sinistro

<div style="overflow-x:auto;">
    <table style='width: 1500px;'>
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
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>idSinistro</td>
                <td>sinistros.idsinistro ou algo similar</td>
                <td>Identificador/código gerado pelo MAPA (Ao enviar sinistro)</td>
                <td>Sim</td>
                <td>N.A.</td>
                <td>9</td>
                <td>Numérico - NU</td>
                <td></td>
            </tr>
            <tr>
                <td>cdProposta</td>
                <td>Aguardando Implementação</td>
                <td>Código da proposta gerado pelo MAPA</td>
                <td>Sim</td>
                <td>N.A.</td>
                <td>9</td>
                <td>Numérico - NU</td>
                <td></td>
            </tr>
            <tr>
                <td>nrApolice</td>
                <td>Aguardando Implementação</td>
                <td>Número da apólice</td>
                <td>Sim</td>
                <td>N.A.</td>
                <td>20</td>
                <td>Alfanumérico sem caracter especial - AS</td>
                <td></td>
            </tr>
            <tr>
                <td>csSinistro</td>
                <td>Será implementado na API</td>
                <td>Código da situação do sinistro</td>
                <td>Sim</td>
                <td>N.A.</td>
                <td>1</td>
                <td>Char - CH</td>
                <td></td>
            </tr>
            <tr>
                <td>cdEventoCobertura</td>
                <td>Aguardando Implementação</td>
                <td>Código do evento/Cobetura do sinistro</td>
                <td>Sim</td>
                <td>N.A.</td>
                <td>3</td>
                <td>Numérico - NU</td>
                <td></td>
            </tr>
            <tr>
                <td>dtAvisoSinistro</td>
                <td>sinistros.DataSinistro</td>
                <td>Data do aviso do sinistro</td>
                <td>Sim</td>
                <td>dd/MM/yyyy</td>
                <td>10</td>
                <td>Data - DT</td>
                <td>20/01/2022</td>
            </tr>
            <tr>
                <td>nrAreaSinistrada</td>
                <td>Será implementado na API</td>
                <td>Tamanho da área sinistrada</td>
                <td>Não</td>
                <td>N.A.</td>
                <td>7</td>
                <td>Numérico - NU</td>
                <td></td>
            </tr>
            <tr>
                <td>pePerda</td>
                <td>Aguardando Implementação</td>
                <td>Percentual de perda</td>
                <td>Não</td>
                <td>N.A.</td>
                <td>3</td>
                <td>Numérico - NU</td>
                <td></td>
            </tr>
            <tr>
                <td>qtProdutividadeObtida</td>
                <td>Aguardando Implementação</td>
                <td>Produtividade Obtida (kg/ha)</td>
                <td>Não</td>
                <td>N.A.</td>
                <td>8</td>
                <td>Numérico - NU</td>
                <td></td>
            </tr>
            <tr>
                <td>dtPagamentoIndenizacao</td>
                <td>Aguardando Implementação</td>
                <td>Data do Pagamento da Indenização (Data do pagamento ao segurado)</td>
                <td>Sim/Não</td>
                <td>dd/MM/yyyy</td>
                <td>10</td>
                <td>Data - DT</td>
                <td>20/01/2022</td>
            </tr>
            <tr>
                <td>vlReservaTecnica</td>
                <td>Será implementado na API</td>
                <td>Valor da Reserva Técnica (R$) (Valor inicial do aviso do sinistro)</td>
                <td>Sim</td>
                <td>N.A.</td>
                <td>12,2</td>
                <td>Numérico - NU</td>
                <td></td>
            </tr>
            <tr>
                <td>vlPagamentoIndenizacao</td>
                <td>Será implementado na API</td>
                <td>Valor do Pagamento da Indenização(R$) (Valor final pago ao segurado)</td>
                <td>Sim</td>
                <td>N.A.</td>
                <td>12,2</td>
                <td>Numérico - NU</td>
                <td></td>
            </tr>
            <tr>
                <td>nrCnpjCpfVistoriador</td>
                <td>Será implementado na API</td>
                <td>CNPJ/CPF do Vistoriador</td>
                <td>Sim</td>
                <td>N.A.</td>
                <td>11~14</td>
                <td>Numérico - NU</td>
                <td></td>
            </tr>
            <tr>
                <td>dtVisitaPerito</td>
                <td>pericias.DataHora</td>
                <td>Data da Visita do Perito</td>
                <td>Sim</td>
                <td>dd/MM/yyyy</td>
                <td>10</td>
                <td>Data - DT</td>
                <td>20/01/2022</td>
            </tr>
        </tbody>
    </table>
</div>

## Mapa Cancelar Sinistros

<div style="overflow-x:auto;">
    <table style='width: 1300px;'>
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
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>nrApolice</td>
                <td>seguros.id</td>
                <td>Número da apólice</td>
                <td>Sim</td>
                <td>N.A.</td>
                <td>20</td>
                <td>Alfanumérico sem caracter especial - AS</td>
                <td>-</td>
            </tr>
            <tr>
                <td>idSinistro</td>
                <td>Aguardando Implementação</td>
                <td>Identificador/código gerado pelo MAPA (Ao enviar sinistro)</td>
                <td>Sim</td>
                <td>N.A.</td>
                <td>9</td>
                <td>Numérico - NU</td>
                <td>-</td>
            </tr>
        </tbody>
    </table>
</div>


## Mapa Sandbox Premio

<div style="overflow-x:auto;">
    <table style='width: 2700px;'>
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
                <td>premios.numeroApolice</td>
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
                <td>premios.naturezaMovimento</td>
                <td>Aguardando Implementação</td>
                <td>Corresponde à natureza do registro. Tabela de Referência 01 </td>
                <td>sim</td>
                <td></td>
                <td>2</td>
                <td>Alfanumerico - AN</td>
                <td>"01"</td>
                <td>TABELA 01 – NATUREZA DO PRÊMIO, pg 9</td>
            </tr>
            <tr>
                <td>premios.tipoMovimento</td>
                <td>Aguardando Implementação</td>
                <td>Corresponde ao tipo de movimento relacionado a premios. Tabela de Referência 02</td>
                <td>sim</td>
                <td></td>
                <td>2</td>
                <td>Alfanumerico - AN</td>
                <td>"01"</td>
                <td>TABELA 02 - TIPOS DE MOVIMENTO DE PRÊMIO, pg 9</td>
            </tr>
            <tr>
                <td>premios.iof</td>
                <td>Aguardando Implementação</td>
                <td>Valor monetário do imposto – corresponde ao valor da IOF</td>
                <td>sim</td>
                <td></td>
                <td></td>
                <td>Numérico - NU</td>
                <td>10000,00</td>
                <td></td>
            </tr>
            <tr>
                <td>premios.valorCorretagem</td>
                <td>Aguardando Implementação</td>
                <td>Valor monetário da comissão de corretagem do seguro – corresponde ao valor total da comissão.</td>
                <td>sim</td>
                <td></td>
                <td></td>
                <td>Numérico - NU</td>
                <td>10000,00</td>
                <td></td>
            </tr>
            <tr>
                <td>premios.dataInicioApolice</td>
                <td>seguros.DataVigenciaInicial</td>
                <td>Data em que a apólice/bilhete iniciou ou iniciará efetivamente a sua vigência. O formato do campo deve ser: AAAA-MM-DD HH:MM:SS</td>
                <td>sim</td>
                <td>AAAA-MM-DD HH:MM:SS</td>
                <td>19</td>
                <td>Data e Hora</td>
                <td>"2020-04-11 00:01:03"</td>
                <td></td>
            </tr>
            <tr>
                <td>premios.dataFimApolice</td>
                <td>seguros.DataVigenciaFinal</td>
                <td>Data em que a apólice/bilhete encerrou ou encerrará efetivamente a sua vigência. O formato do campo deve ser: AAAA-MM-DD HH:MM:SS</td>
                 <td>sim</td>
                <td>AAAA-MM-DD HH:MM:SS</td>
                <td>19</td>
                <td>Data e Hora</td>
                <td>"2020-04-11 00:01:03"</td>
                <td></td>
            </tr>
            <tr>
                <td>premios.dataInicioCobertura</td>
                <td>Será implementado na API</td>
                <td>Data de início da cobertura. O formato do campo deve ser: AAAA-MM-DD HH:MM:SS </td>
                 <td>sim</td>
                <td>AAAA-MM-DD HH:MM:SS</td>
                <td>19</td>
                <td>Data e Hora</td>
                <td>"2020-04-11 00:01:03"</td>
                <td></td>
            </tr>
            <tr>
                <td>premios.dataFimCobertura</td>
                <td>Será implementado na API</td>
                <td>Data do final da cobertura. O formato do campo deve ser: AAAA-MM-DD HH:MM:SS </td>
                 <td>sim</td>
                <td>AAAA-MM-DD HH:MM:SS</td>
                <td>19</td>
                <td>Data e Hora</td>
                <td>"2020-04-11 00:01:03"</td>
                <td></td>
            </tr>
            <tr>
                <td>premios.identificacaoSegurado</td>
                <td>seguros.CPFProdutor</td>
                <td>Corresponde ao CPF ou CNPJ do Segurado</td>
                <td>sim</td>
                <td></td>
                <td>11 ou 14</td>
                <td>Alfanumerico - AN</td>
                <td>01234567891011'</td>
                <td></td>
            </tr>
            <tr>
                <td>premios.identificacaoBeneficiario</td>
                <td>Aguardando Implementação</td>
                <td>Corresponde ao CPF ou CNPJ do Beneficiario</td>
                <td>sim</td>
                <td></td>
                <td>11 ou 14</td>
                <td>Alfanumerico - AN</td>
                <td>01234567891011'</td>
                <td></td>
            </tr>
            <tr>
                <td>premios.seguroIntermitente</td>
                <td>Aguardando Implementação</td>
                <td>Corresponde à informação de se a apólice/bilhete é referente à cobertura de seguro ntermitente ou de seguro tradicional. Tabela de Referência 03 </td>
                <td>sim</td>
                <td></td>
                <td>2</td>
                <td>Alfanumerico - AN</td>
                <td>"01"</td>
                <td>TABELA 03 – SEGURO INTERMITENTE, pg 9</td>
            </tr>
            <tr>
                <td>premios.dataMovimento</td>
                <td>Aguardando Implementação</td>
                <td>Corresponde à data referente ao lançamento do movimento. O formato do campo deve ser: AAAA-MMDD HH:MM:SS</td>
                <td>sim</td>
                <td>AAAA-MM-DD HH:MM:SS</td>
                <td>19</td>
                <td>Data e Hora</td>
                <td>"2020-04-11 00:01:03"</td>
                <td></td>
            </tr>
            <tr>
                <td>premios.coberturas.identificacaoCobertura</td>
                <td>Aguardando Implementação</td>
                <td>Corresponde ao tipo de cobertura contratado. Tabela de Referência 05 _x005F_x000D_</td>
                <td>sim</td>
                <td></td>
                <td>3</td>
                <td>Alfanumerico - AN</td>
                <td>"001"</td>
                <td>TABELA 05 – TIPOS DE COBERTURA, pg 10</td>
            </tr>
            <tr>
                <td>premios.coberturas.ramo</td>
                <td>Aguardando Implementação</td>
                <td>Código do ramo a que se refere o movimento e que se encontra no edital de seleção no qual a supervisionada se submeteu. Tabela de Referência 04 </td>
                <td>sim</td>
                <td></td>
                <td>3</td>
                <td>Alfanumerico - AN</td>
                <td>"001"</td>
                <td>TABELA 04 – RAMOS (DE ACORDO COM O EDITAL) _x005F_x000D_, pg 9 e 10</td>
            </tr>
            <tr>
                <td>premios.coberturas.maxima</td>
                <td>Será implementado na API</td>
                <td>Valor monetário da maior importância segurada para cobertura de um risco isolado. Neste campo são consideradas duas casas decimais. _x005F_x000D_</td>
                <td>sim</td>
                <td></td>
                <td></td>
                <td>Numérico - NU</td>
                <td>10000,00</td>
                <td></td>
            </tr>
            <tr>
                <td>premios.coberturas.identificacaoObjetoSegurado</td>
                <td>Aguardando Implementação</td>
                <td>Corresponde ao tipo de objeto que será coberto. Tabela de Referência 06 </td>
                <td>sim</td>
                <td></td>
                <td>3</td>
                <td>Alfanumerico - AN</td>
                <td>"001"</td>
                <td>TABELA 06 – TIPOS DE OBJETO, pg 11</td>
            </tr>
            <tr>
                <td>premios.coberturas.premioBruto</td>
                <td>Aguardando Implementação</td>
                <td>Valor monetário do prêmio bruto. Prêmio bruto = prêmio comercial acrescido dos encargos e impostos, sendo este o prêmio efetivamente que será pago pelo segurado.</td>
                <td>sim</td>
                <td></td>
                <td></td>
                <td>Numérico - NU</td>
                <td>10000,00</td>
                <td></td>
            </tr>
            <tr>
                <td>premios.coberturas.premioComercial</td>
                <td>Será implementado na API</td>
                <td>Valor monetário do prêmio comercial considerando duas casas decimais</td>
                <td>sim</td>
                <td></td>
                <td></td>
                <td>Numérico - NU</td>
                <td>10000,00</td>
                <td></td>
            </tr>
            <tr>
                <td>premios.coberturas.premioRetido</td>
                <td>Aguardando Implementação</td>
                <td>Valor monetário do prêmio retido. Prêmio retido = prêmio emitido – prêmio de cosseguro cedido – prêmios cedidos em resseguro. _x005F_x000D_</td>
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













