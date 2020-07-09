# DevTiss

## Sobre
> Esse projeto surgiu com a necessidade de validar e calcular hash de XML do padrão Tiss (ANS). Atualmente trabalhem com software de Plano de Saúde e em vários momentos tenho a necessidade de validar um XML ou calcular o hash.

## Links
 * FrontEnd - https://devtiss-frontend.herokuapp.com
 * BackEnd - https://devtiss-backend.herokuapp.com/index.html

## Tecnologias Utilizadas
> Para a realização do projeto, foram utilizadas as seguintes tecnologias
  
  <h4>FrontEnd</h4>
  <ul>
    <li>HTML</li>
    <li>CSS</li>
    <li>JavaScript</li>
    <li>ReactJs</li>
  </ul>

  <h4>BackEnd</h4>
  <ul>
    <li>DotNet Core</li>
    <li>Restful</li>
  </ul>

## Step
### Pré-requisitos
* É necessário possuir o Node.js, Git, Yarn, DotNet Core e Docker instalado na máquina

### Faça um clone do projeto
* git clone https://github.com/WandersonAFreitas/devtiss

#### Iniciando a aplicação
  * BackEnd
    * Selecione a pasta BackEnd/WebApi
    * Execute o comando "dotnet restore"
    * Execute o comando "dotnet build"
    * EXecute o coamndo "dotnet run"
    
  * FrontEnd
    * Selecione a pasta FrontEnd
    * Execute o comando "yarn install"
    * Execute o comando "yarn start"

### Publicando no Heroku

  * BackEnd
    * Selecione a pasta BackEnd
    * Execute os comandos abaixo 
      * heroku login
      * docker build -t devtiss-backend .
      * heroku container:login
      * heroku container:push web -a devtiss-backend
      * heroku container:release web -a devtiss-backend
      
   * FrontEnd
    * Selecione a pasta FrontEnd
    * Execute os comandos abaixo
      * git add .
      * git commit -am "Comentário"
      * git push heroku master
 
## Apresentação
 <img src="https://user-images.githubusercontent.com/14041111/86984100-04d24180-c164-11ea-8a87-efa4e696bdd6.gif">
