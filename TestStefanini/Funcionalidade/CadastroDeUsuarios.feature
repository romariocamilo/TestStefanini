#language: pt-br

Funcionalidade: Cadastro de Usuários
	Tela para cadastro de novos usuários

Cenário: Acessar pagina de cadastro
	Dado que eu tenha a url destino
	Quando eu acessei a url
	Entao a pagina é aberta com titulo Cadastro de Usuários
	E exibe o texto informativo Para realizar o cadastro de um usuário, insira dados válidos no formulário e acione a opção Cadastrar :)
	E exibe o formulario de cadastro com titulo Formulário
	E exibe o campo Nome
	E exibe o E-mail
	E exibe o campo Senha
	E exibe o botão Cadastrar
	E não exibe a tabela de usuarios cadastrados

Cenário: Validar cadastro sem nome
	Dado que eu esteja na tela de cadastro
	Quando preenchi o campo Email
	E preenchi o campo Senha
	E cliquei no botao Cadastrar
	Entao entao um aviso de campo obrigatório é exibido para o campo nome

Cenário: Validar cadastro com nome invalido
	Dado que eu esteja na tela de cadastro
	Quando eu preenchi o campo nome somente com primeiro nome
	E preenchi o campo Email
	E preenchi o campo Senha
	E cliquei no botao Cadastrar
	Entao entao um aviso de nome invalido é exibido para o campo nome

Cenário: Validar cadastro sem email
	Dado que eu esteja na tela de cadastro
	Quando eu preenchi o campo Nome
	E preenchi o campo Senha
	E cliquei no botao Cadastrar
	Entao entao um aviso de campo obrigatório é exibido para o campo email

Cenário: Validar cadastro com email invalido
	Dado que eu esteja na tela de cadastro
	Quando eu preenchi o campo Nome
	E eu preenchi o campo Email com email invalido
	E preenchi o campo Senha
	E cliquei no botao Cadastrar
	Entao entao um aviso de email invalido é exibido para o campo email

Cenário: Validar cadastro sem senha
	Dado que eu esteja na tela de cadastro
	Quando eu preenchi o campo Nome
	E preenchi o campo Email
	E cliquei no botao Cadastrar
	Entao entao um aviso de campo obrigatório é exibido para o campo senha

Cenário: Validar cadastro com senha invalida
	Dado que eu esteja na tela de cadastro
	Quando eu preenchi o campo Nome
	E preenchi o campo Email
	E preenchi o campo Senha com uma senha invalida
	E cliquei no botao Cadastrar
	Entao entao um aviso de senha invalida é exibido para o campo senha

Cenário: Validar cadastro valido
	Dado que eu esteja na tela de cadastro
	Quando eu preenchi o campo Nome
	E preenchi o campo Email
	E preenchi o campo Senha
	E cliquei no botao Cadastrar
	Entao entao o sistema exibe da tabela de usuarios cadasdtrados
	E exibe o usuario com os dados informados no cadastro

Cenário: Validar cadastro em massa
	Dado que eu esteja na tela de cadastro
	Quando eu executei o cadastro em massa
	Entao entao o sistema exibe da tabela de usuarios cadasdtrados
	E exibe os usuarios com os dados informados no cadastro

Cenário: Remover usuarios cadastrados
	Dado que eu esteja na tela de cadastro
	E tenha usuarios cadastrados
	Quando eu clicar em Exlcuir
	Entao então o sistema remove usuarios da lista
	E não exibe a tabela de usuarios cadastrados