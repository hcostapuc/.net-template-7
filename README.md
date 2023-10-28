 # Template .NET Core

Esse template foi construido baseado em boas práticas e conceitos que trazem eficiência na hora de codificar e na sua manutenção. Nosso objetivo foi deixar **fácil de se implementar o certo e dificil de se implementar o errado**.

Nosso propósito foi desenvolver um template que aceita fácil a **Mudança** onde caso ocorra, não necessite alteração em inumeras outras partes do sistema que não fazem parte do contexto da mudança. **Robustez** caso uma alteração seja feita não quebre outras partes do sistema inesperadamente. E por último **Mobilidade** o sistema porporciona fácil reutilização de suas features/camadas, como o software é sempre evolutivo esse ponto é crucial para a facilidade da sua progressão.

Nossa princípal referência de arquitetura está na proposta por Uncle Bob em seu livro Clean Architecture segue o link de um post com uma breve introdução sobre: [Clean Architecture](https://imasters.com.br/back-end/introducao-clean-architecture).

Foi proposto para uma resolução genérica, caso seu projeto necessite de uma estrutura específica que o template não proporcione fique a vontade em adicionar ou caso tenha dúvidas sobre, basta nos contatar pelo canal de comunicação Guilda BackEnd localizado no discord. 



## Tecnologias utilizadas

* [ASP.NET Core 6](https://docs.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-6.0)
* [Entity Framework Core 6](https://docs.microsoft.com/en-us/ef/core/)
* [MediatR](https://github.com/jbogard/MediatR)
* [Swagger](https://swagger.io/)
* [AutoMapper](https://automapper.org/)
* [FluentValidation](https://fluentvalidation.net/)
* [XUnit](https://xunit.net/), [FluentAssertions](https://fluentassertions.com/) e [Moq](https://github.com/moq)
* [Docker](https://www.docker.com/)

## Instalação

O template é fácil de ser utilizado:

1. Instale o SDK do .NET caso não possua: [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
2. Clone o projeto para sua máquina utilizando o comando `gh repo clone hdntecnologiabr/.net-base-repository` para o GitHub CLI, caso queira utilizar outro método só seguir pela orientação que o github fornece na página.
3. Execute o projeto.

OBS.: Estamos com uma feature de deixa-lo instalavel igual os templates oficiais da microsoft, o que vai facilitar ainda mais a utilização.

### Configuração do Banco de dados

O template é configurado para usar um banco de dados _inMemory_ por padrão. Isso garante que todos os usuários possam executar a solução sem precisar configurar o banco.

Se você quiser utilizar o provedor SQL Server que é o escolhido por esse template basta alterar o appconfiguration no projeto desabilitando o _inMemory_ **Hdn.Core.Architecture.WebApi/appsettings.json**:

```json
  "UseInMemoryDatabase": false,
```

Adicione no **DefaultConnection** sua string de conexão com o banco no próprio arquivo **appsettings.json**. 

### Migrations

Utilize o comando `dotnet-ef` para as migrations, adicione as seguintes tags ao comando (os valores assumem que você está executando a partir da raiz do repositório).

* `--project src/Hdn.Core.Architecture.Infrastructure` (opcional se estiver nesta pasta)
* `--startup-project src/Hdn.Core.Architecture.WebApi`
* `--output-dir Migrations`

Por exemplo, para adicionar uma nova migration da pasta raiz:

 `dotnet ef migrations add "InitialMigration" --project src\Hdn.Core.Architecture.Infrastructure --startup-project src\WebUI --output-dir Migrations`

## Padrões e princípios utilizados
Todos os padrões e princípios tiveram sua importância para montar um template de fácil manutenção e implementação de novas features, segregando suas responsabilidades deixando o projeto com alta coesão e baixo aclopamento.

* **SOLID**: É o principal de todos, está relacionado diretamente a programação orientada a objeto. Ele nos ajuda a segregar nossas resposnabilidades do projeto, criar novas features coesas extendendo-as quando for necessário, definir corretamente as heranças entre os objetos, definir os contratos (Interfaces) específicos para cada classe, e desaclopamento entre as camadas e objetos. Esse é sem dúvida o maior beneficiador do nosso projeto, para entender mais quais são as suas violações e soluções basta baixar esse repositório: [SOLID](https://github.com/hcostapuc/SOLID)

* **CQRS**: (_Command Query Responsibility Segregation_) É o pattern que nos ajuda a manter a coesão do início ao fim do projeto, mantendo a facilidade e segurança de criar novas features sem afetar outros processos. Isso nos ajuda estar mais perto da arquitetura limpa proposta por uncle bob em seu livro, mantendo os _user cases_ bem separados desde a primeira camada até a última. Ele basicamente separa o que é busca de informação (queries) do que é alteração e inserção (commands). Segue a documentação oficial da microsoft falando sobre o pattern: [CQRS](https://docs.microsoft.com/en-us/azure/architecture/patterns/cqrs)

* **Mediator**: É um pattern que sugere que você deva cessar toda comunicação direta entre componentes que você quer tornar independentes um do outro. Ao invés disso, esses componentes devem colaborar indiretamente, chamando um objeto mediador especial que redireciona as chamadas para os componentes apropriados. Ele nos ajuda na comunicação entre a camada presentation e application. Ele faz a mediação da comunicação entre as camadas. Segue este artigo para mais detalhes sobre o pattern: [Mediator](https://refactoring.guru/design-patterns/mediator)

* **KISS**: (_Keep It Simple, Stupid_) Esse é um pattern bastante importante pois traz a simplicidade para o nosso dia dia, a complexidade deve estar somente onde é necessária e nada alem disso. Isso vai além dos códigos em si, na nossa análise e todo processo que engloba o desenvolvimento de software. Resolver os problemas de forma simples nós traz eficiência e rápido entendimento daquele contexto por outros profissionais da equipe. Segue um artigo onde explica bem seu propósito e diretrizes: [KISS](https://www.interaction-design.org/literature/article/kiss-keep-it-simple-stupid-a-design-principle)

* **DRY**: (_Don't Repeat Yourself_) É algo que já esta intricico e que comumente já fazemos no dia dia, e está aqui pra reforçar essa prática. Seu proósito é basicamente evitar repetição de código em seu projeto, abstraindo, extendendo, unificando alguns desses pontos. Isso denpenderá diretamente em que contexto ele se encontra, a forma como a unificação acontecerá. Segue um artigo que detalha mais sobre o pattern: [DRY](https://medium.com/@rafaelsouzaim/n%C3%A3o-se-repita-dry-dont-repeat-yourself-40da33289bcf)

* **AAA**: (_Arrange Act Assert_) Esse pattern foi feito para suportar a criação dos nossos testes de unidade. Seu benefício se da pela organização dos contextos de um teste, separando por **Arrange**: tudo que eu preciso instanciar para criar o meu teste, **Act**: a chamada do metodo em questão que irei testar passando os meus objetos criados no Arrange, e **Assert**: onde deverá ficar tudo que necessito para validar se aquele retorno foi realmente o esperado. Eles podem ser separados por comentário, isso não é algo ruim pois diferente do codigo em sí o teste de unidade possui particularidades que devem ser seguidas como deixa-lo o mais explicito possível. Segue um artigo que detalha amis sobre o pattern: [AAA](https://medium.com/@pjbgf/title-testing-code-ocd-and-the-aaa-pattern-df453975ab80)

## Camadas da aplicação

### Domain

Essa camada conterá todas as entidades, enumerações, exceções, interfaces, tipos e lógica específicos da camada de domínio.

### Application

Essa camada contém toda a lógica da aplicação. É a porta de entrada do Core. É dependente da camada de domínio, mas não tem dependências de nenhuma outra camada ou projeto. Essa camada define interfaces que são implementadas por camadas externas. Por exemplo, se a aplicação precisar acessar um serviço de notificação, uma nova interface será adicionada ao aplicativo e uma implementação será criada na infrastructure.

### Infrastructure

Essa camada contém classes para acessar recursos externos, como sistemas de arquivos, serviços da Web, banco, integrações, smtp e assim por diante. Essas classes devem ser baseadas em interfaces definidas na camada de aplicação.

### Presentation

Essa camada é onde você irá expor a sua aplicação, comumente uma aplicação Web, sendo API. Essa camada depende das camadas Application e Infrastructure, no entanto, a dependência da infrastructure é apenas para dar suporte à injeção de dependência. Portanto, apenas *Startup.cs* deve fazer referência à infrastructure.

## Suporte

Qualquer dúvida sobre o template pode nos conta-tar no canal da Guilda BackEnd localizado no discord.