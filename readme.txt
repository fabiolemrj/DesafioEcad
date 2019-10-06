FRONTEND

O projeto de front end foi dividivo em tres modulos de componentes: musica, author e musica-autor;
O servi�o aos servi�os pode ser configurado nos compnentes responsaveis, descritos abaixo:
variavel
  private url = "http://localhost:5000/v1";

Musica:
app/musics/musics.service.ts

autor:
app/authors/services.authors/authors.service.ts

Musica Autor
app/musics.authors/service/music.author.service.ts

===========================================================================================================================
BACKEND


O projeto foi desenvolvido, utilizado a tecnologia .Net Core 
 e o ORM EntityFrameWorkCore (versao 2.1.1)


******************************************************************************
Banco de dados
********************
Esta solu��o foi desenvolvida utilizando o banco de dados MSSQL Server 2017 (community).
Dentro do projeto ecad.infra, existe a pasta "Scripts", onde est�o localizados os scripts necess�rios para rodar
no banco de dados.
Para criar o banco de dados, � preciso executar o comando de migration, localizado na pasta de ecad.infra

Configurar ConnectioString:
No projeto "ecad.api", existe um arquivo "appsettings.json", onde deve ser incluida a string de conex�o do banco de dados

******************************************************************************
Projetos
********************

Dominio do problema
N�o foi objetivo incluir muita complexidade ao projeto, e apenas atender as orienta��es solicitadas. 
Criar um cadastro de musicas e autores, com associa��o de N para N entre essas entidades.

**********************************
Estrutura do Projeto:
O projeto foi desenhado para funcionar em camadas, cada uma com sua responsabilidade e objetivo

- ecad.api
     Projeto Web API, exibe informa��es para o usu�rio

- ecad.domain
	camada de dominio da aplica��es, onde se localizam as regras de negocio e 
	processamento de informa��es relativas a este.
	Obs.: As classes (entidades), foram criadas herdando a classe "Notifiable" existente do 
	 pacote FluentValidator (vers�o 2.0.2), para ajudar na valida��o de informa��es. 
	 Este foi baixado via NuGet.

- ecad.infra
	camada de infraestrutura, onde s�o colocados a liga��o da aplica��o com o banco de 
	dados e outros servi�os possam ser necess�rios

- ecad.shared
	camadas para compartilha informcoes entre os projetos
	
- ecad.test
	camada do projeto para realiza��o dos testes da aplica��o
    

***********************************
Documenta��o

Foi instalado no projeto ecad.api, um pacote da ferramenta de documenta��o de Web API, SWAGGER!
� possivel acessar a documenta��o do projeto, tal como testar os endpoints, acessando o seguinte endere�o url:

http://host:port/swagger/

***********************************
TESTES
O projeto de testes foi dividido para realizar testes da camada de dominio do aplicativo, 
utilizando repositorios mocados e a tecnica de testes de unidades.

***********************************
Documenta��o

EndPoints Disponiveis

Foi criado uma reposta padr�o para o resultado
{
    "success": true,(indicando se a opera��o deu certo)
    "message": "mensagem", (mensagem de sucesso ou falha)
    "data": {Objeto gravado} (descri�ao do objeto gravado)
}

endpoints para tabela musica (MUSIC)

retorna uma lista de objetos do tipo musica pela descri��o do nome da musica
verbo:get
v1/musicsbyname/{id}

retorna toda lista de musicas
verbo: get
v1/musics

retorna u objeto musica pelo ID
verbo: get
v1/musics/{id}

Grava (cria) um objeto do tipo musica
verbo:Post
v1/musics

Grava (atualiza) um objeto do tipo musica
verbo: Put
v1/musics

apagar um objeto objeto do banco pelo ID
verbo: delete
v1/musics/{id}
****************************************************

endpoints para tabela autor (AUTHOR)

retorna uma lista de objetos autores filtrados pelo nome
verbo: get
v1/authorsbyname/{id}

lista de autores disponiveis para a musica selecionada, ou seja, que ainda n�o foram associados
verbo: get
v1/authorsavailable/{id}

lista todos os autores
verbo: get
v1/authors

Grava um novo objeto do tipo autor
verbo: post
v1/authors

Busca lista de autores pelo ID
verbo: get
v1/authors/{id}

Atualiza novo registro no banco
verbo: put
v1/authors

apagar registro no banco pelo ID
verbo:delete
v1/authors/{id}

****************************************************

endpoints para tabela de associa��o entre Musica e Autor (MUSICAUTHOR)


Busca todos os autores associados a uma musica
verbo:get
v1/musics/{id}/authors

busca lista de associacoes pelos IDs de musica autor
verbo: get
v1/musicsauthorsbyid/{musicid}/{authorid}

Grava um nova associa��o entre musica e autor
verbo: Post
v1/musicsauthors

apaga um registro no banco filtrados pelos IDs de musica e autor
verbo:delete
v1/deletemusicsauthors/{musicid}/{authorid}





