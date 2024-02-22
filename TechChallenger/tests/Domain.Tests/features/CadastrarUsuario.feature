Funcionalidade: Cadastro de Usuário

Como um novo usuário
Eu quero me cadastrar no sistema
Para poder acessar os recursos exclusivos

    Cenário: Cadastro bem-sucedido de um novo usuário
        Dado que estou na página de cadastro
        Quando preencho o formulário com as seguintes informações: nome: "Jonatas", cpf: "11111", email: "teste@gmail.com"
        E clico no botão de cadastrar
        Então devo ser redirecionado para a página inicial
        E vejo uma mensagem de boas-vindas