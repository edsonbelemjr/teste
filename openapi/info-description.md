# Middleware - MAPA e SUSEP

Esse projeto é responsável por fazer a integração da API desenvolvida pela Ponderatti, que irá consultar a base de dados da Picsel retornando os campos necessários para o envio dos dados para as APIs do MAPA e da SUSEP. A arquitetura será provisionada usando o recurso LAMBDA AWS.

# Validação

As validações dos campos são feitas após entre a consulta da API de entrada e o envio para as APIs. A validação é feita a partir do jsonschema utilizando a biblioteca do python jsonschema. Para cada caminho das APIs foram feitos jsonschemas que definem as regras de cada campo, e utilizando a função validate da biblioteca jsonschema: