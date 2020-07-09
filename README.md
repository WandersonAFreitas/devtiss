# DevTiss

## Sobre
Essa ferramenta permite que os devs que trabalham com XML do padrão Tiss (ANS) permita a validação e o calculo de hash dos arquivox XML.

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
* É necessário possuir o Node.js, Git, Yarn, dotnet core e Docker instalado na máquina

### Faça um clone do projeto
* git clone https://github.com/WandersonAFreitas/devtiss

#### Execução da aplicação

  * BackEnd
    * Selecione a pasta BackEnd/WebApi
    * Execute o comando "dotnet restore"
    * EXecute o coamndo "dotnet watch run"
    
  * FrontEnd
    * Selecione a pasta FrontEnd
    * Execute o comando "yarn install"
    * Execute o comando "yarn start"

### Publicação no Heroku

  * BackEnd
    * Selecione a pasta BackEnd
    * Execute os comandos abaixo 
      * heroku login
      * docker build -t devtiss-backend .
      * heroku container:login
      * heroku container:push web -a devtiss-backend
      * heroku container:release web -a devtiss-backend
      
> Obs.: Caso deseje testar BackEnd vai docker, execute o comando após o build da imagem
  * docker run -d -p 80:80 devtiss/devtiss-backend
    
   * FrontEnd
    * Selecione a pasta FrontEnd
    * Execute os comandos abaixo
      * git add .
      * git commit -am "Comentário"
      * git push heroku master
 
## Apresentação
 <img src="https://user-images.githubusercontent.com/14041111/83968224-088d5280-a89e-11ea-860e-7e95770985c4.gif">
