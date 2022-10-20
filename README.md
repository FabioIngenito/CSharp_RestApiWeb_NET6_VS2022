<h1 align="left">REST API</h1>

- Este projeto é uma somatória de videos que eu assiti e tentei juntar tudo em
um projeto só. Guardei todos os vídeos dentro de cometários no topo dos arquivos
caso você queira assistí-los e até comparar as modificações que eu fiz.

<ul>
  <li>🪧 Vitrine.Dev</li>
  <li>✨ Nome	CSharp_RestApiWeb_NET6_VS2022</li>
  <li>🏷️ Tecnologias	C# TSQL</li>
</ul>

<img src="https://user-images.githubusercontent.com/24603753/197006949-f14f9770-e614-42f9-8371-3ed105d32d3a.png#vitrinedev" alt="RESP API" />

<h2 align="left">Detalhes do projeto</h2>

REST API
Web API Minimo - C# Framework .Net 6 - Visual Studio 2022

- Este projeto é uma somatória de videos que eu assiti e tentei juntar tudo em
um projeto só. Guardei todos os vídeos dentro de cometários no topo dos arquivos
caso você queira assistí-los e até comparar as modificações que eu fiz.

------------------------
1 * PARA FAZER FUNCIONAR

  É preciso configurar o Banco de Dados dentro do projeto com a SUA "Connection 
String" (string de conexão) do seu Banco de Dados.
  As "ConnectionsStrings" estão no arquivo "appsettings.json":

  Eu usei: SQL Server e MySQL, mas tenho certeza que é possível em outros BD.

  O proprio programa se encaregará de criar a base de dados e a tabela, basta 
ter acesso a isso na string de conexão (=> Database.EnsureCreated();).

  A tabela será criada automaticamente pelo Entity Framework, mas guardei a
query "Create Table" na pasta "SQL" para MS SQL Server e MySQL.

------------------------
2 * PASTA STARTUP: 

   Existe uma pasta chamada "Startup". O arquivo "startup.cs" foi DESCONTINUADO 
na versão "Framework .Net 6", mas em um vídeo o instrutor ensinou a recriá-lo. 
Apesar de NÃO ser obrigatório, tudo fica muito mais organizado.

   Eu separei dentro desta pasta os arquivos em três arquivos a saber:

   - Startup.cs;
   - IStartup.cs; (interface)
   - StartupExtensions.cs; (extensão)

   Libera o arquivo "Program.cs" de muitas responsabilidades.

------------------------
3 * Emuladores

   Eu testei três softwares para emular, a saber:

- SoupUI; 
- Postman; 
- Swagger; 

   Mas se você conhecer algum outro programa legal, tenho certeza que vai 
funcionar. Abaixo descrevo cada um.

------------------------
4 * SoupUI

  Salvei as configurações do SoapUI na PASTA "SoapUI", basta carregar.
  Este foi o primeiro programa que usei quando estudei sobre SOAP. Se NÃO
engano ele NÃO tinha REST e foi incorporado depois.

------------------------
5 * Postman

  Na MINHA opinião o programa mais fácil de trabalhar, mas tem menos recursos
que o SoapUI. Não achei um lugar para salvar as configurações.

  - Crie o POST e o GET usando o caminho: 
https://localhost:7085/api/WebAPIMinimo

  - Exemplo de JSON:
{
"id": 98,
"nome": "TESTE 98"
}

  - Passe o parâmetro para o GET desta forma: 
https://localhost:7085/api/WebAPIMinimo/1

------------------------
6 * Swagger

   Se você criar um projeto MÍNIMO ele NÃO traz o pacote Swagger. De outras 
formas, o pacote Swagger já vem junto como auxiliar.

   Caso você NÃO queira trabalhar com o Swagger, recomendo dentro do arquivo
"launchSettings.json", colocar como "FALSE" (menos a linha "launchUrl") ou 
comentar (menos os cabeçalhos) as seguintes linhas:

"profiles": {
   ...
   "dotnetRunMessages": false,
   "launchBrowser": false,
   "launchUrl": "swagger",
   ...
   }
},
"IIS Express": {
   "launchBrowser": false,
   "launchUrl": "swagger",
}

------------------------
7 * MAPPER

Ajuda a mappear os objetos. Veja mais em:

AutoMapper - A convention-based object-object mapper.
Um mapeador objeto-objeto baseado em convenção.

https://docs.automapper.org/en/stable/

------------------------
8 * EXTRA

  Dentro do arquivo "startup.cs" tem uma linha que está comentada a saber:
(MapeamentoPost(app);) estas chamadas estão fora do CONTROLLER. Veja isso depois
de fazer funcionar dentro do CONTROLLER. (pq as coisas ficam um pouco bagunçadas,
eu não gosto, mas não é nada que vai matar).

#Novidades #AspNet6 #Startup
ASP.NET 6 - O QUE ACONTECEU COM A CLASSE STARTUP?
8 de dez. de 2021
desenvolvedor.io
https://youtu.be/VgjHQvprRy0

------------------------ 
9 * DOCUMENTAÇÃO MICROSOFT

Novidades no EF Core 5.0
Artigo - 04/05/2022 - 13 minutos para o fim da leitura

A lista a seguir inclui os principais novos recursos no EF Core 5.0. Para obter a lista completa de problemas na versão, consulte nosso rastreador de problemas.
Como uma versão principal, o EF Core 5.0 também contém várias alterações interruptivas, que são melhorias de API ou alterações comportamentais que podem ter impacto negativo nos aplicativos existentes.

https://docs.microsoft.com/pt-br/ef/core/what-is-new/ef-core-5.0/whatsnew

------------------------ 

Boa diversão!
