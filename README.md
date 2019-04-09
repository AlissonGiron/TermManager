# TermManager

## INTEGRANTES
- 163011	Alisson Henrique dos Santos Giron
- 160060	Gabriel Acosta Belchior
- 160068	Guilherme Proença Cravo da Costa

## INSTRUÇÕES

O projeto é dividido em duas partes:
- Back End (ASP.NET Web API)
- Front End (Aplicação Vue.js)
	
Para rodar o Back End:
- Edite o arquivo `WebApi\Api.EndPoint\appsettings.json`, e coloque uma ConnectionString válida na configuração "Default". O banco de dados será criado automaticamente.
- Abra a solução `WebApi\TermManager.sln` com o Visual Studio e rode o projeto.
	
Para rodar o Front End:
- Abra um terminal dentro da pasta `App`, e rode os comandos `npm install`, `npm run dev`. Um site será aberto em http://localhost:8080/, na página de login.
- Existe um usuário previamente criado, com permissão de Administrador, Coordenador e Professor.
- Usuário: `masteradmin`
- Senha: `admin`
