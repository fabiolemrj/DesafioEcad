FRONTEND

O projeto de front end foi dividivo em tres modulos de componentes: musica, author e musica-autor;
O serviço aos serviços pode ser configurado nos compnentes responsaveis, descritos abaixo:
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
Esta solução foi desenvolvida utilizando o banco de dados MSSQL Server 2017 (community).
Dentro do projeto ecad.infra, existe a pasta "Scripts", onde estão localizados os scripts necessários para rodar
no banco de dados.
Para criar o banco de dados, é preciso executar o comando de migration, localizado na pasta de ecad.infra

Configurar ConnectioString:
No projeto "ecad.api", existe um arquivo "appsettings.json", onde deve ser incluida a string de conexão do banco de dados

******************************************************************************
Projetos
********************

Dominio do problema
Não foi objetivo incluir muita complexidade ao projeto, e apenas atender as orientações solicitadas. 
Criar um cadastro de musicas e autores, com associação de N para N entre essas entidades.

**********************************
Estrutura do Projeto:
O projeto foi desenhado para funcionar em camadas, cada uma com sua responsabilidade e objetivo

- ecad.api
     Projeto Web API, exibe informações para o usuário

- ecad.domain
	camada de dominio da aplicações, onde se localizam as regras de negocio e 
	processamento de informações relativas a este.
	Obs.: As classes (entidades), foram criadas herdando a classe "Notifiable" existente do 
	 pacote FluentValidator (versão 2.0.2), para ajudar na validação de informações. 
	 Este foi baixado via NuGet.

- ecad.infra
	camada de infraestrutura, onde são colocados a ligação da aplicação com o banco de 
	dados e outros serviços possam ser necessários

- ecad.shared
	camadas para compartilha informcoes entre os projetos
	
- ecad.test
	camada do projeto para realização dos testes da aplicação
    

***********************************
Documentação

Foi instalado no projeto ecad.api, um pacote da ferramenta de documentação de Web API, SWAGGER!
É possivel acessar a documentação do projeto, tal como testar os endpoints, acessando o seguinte endereço url:

http://host:port/swagger/

***********************************
TESTES
O projeto de testes foi dividido para realizar testes da camada de dominio do aplicativo, 
utilizando repositorios mocados e a tecnica de testes de unidades.

***********************************
Documentação

EndPoints Disponiveis

Foi criado uma reposta padrão para o resultado
{
    "success": true,(indicando se a operação deu certo)
    "message": "mensagem", (mensagem de sucesso ou falha)
    "data": {Objeto gravado} (descriçao do objeto gravado)
}

endpoints para tabela musica (MUSIC)

retorna uma lista de objetos do tipo musica pela descrição do nome da musica
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

lista de autores disponiveis para a musica selecionada, ou seja, que ainda não foram associados
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

endpoints para tabela de associação entre Musica e Autor (MUSICAUTHOR)


Busca todos os autores associados a uma musica
verbo:get
v1/musics/{id}/authors

busca lista de associacoes pelos IDs de musica autor
verbo: get
v1/musicsauthorsbyid/{musicid}/{authorid}

Grava um nova associação entre musica e autor
verbo: Post
v1/musicsauthors

apaga um registro no banco filtrados pelos IDs de musica e autor
verbo:delete
v1/deletemusicsauthors/{musicid}/{authorid}





