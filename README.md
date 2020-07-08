<h1>DevTiss<h1>

<h2>O que seria esse projeto?</h2>
<p>Esse projeto surgiu de uma necessidade das operadoras de plano de saúde validar e atualizar hash de arquivo XML do padrão Tiss (ANS). No primeiro momento foi desenvolvido somente a parte da validação e a atualização do hash de arquivo</p>

<p>É uma semana para adquirir o conhecimento de desenvolvimento Web, a Rocketseat disponibilizou um curso para os devs aprenderem a desenvolver uma aplicação por completo, desde o frontend ao backend. Essa semana se inicia com nível Starter, permitindo que os devs aprenderem as tecnologias como HTML, CSS, Javascript, Node.js e SQLite.</p>

<h2>Sobre</h2>
<p>
O projeto desenvolvido nessa semana, foi um marketplace para coleta de resíduos recicláveis. Neste projeto as empresas de pontos de coleta, poderão se cadastrar para que seja disponibilizado na busca das suas informações. Também o usuário final permitirá encontrar um local mais próximo para levar os tipos de resíduos.
</p>

<h2>Tecnologias Utilizadas</h2>
<p>Para a realização do projeto, foram utilizadas as seguintes tecnologias</p>

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

<h2>Step</h2>
 
<h4>Pré-requisitos</h4>
<ul><li>É necessário possuir o Node.js, Git, Yarn instalado na máquina</li></ul>

<h5>Faça um clone do projeto</h5>
<ul><li>git clone https://github.com/WandersonAFreitas/next-level-week</li></ul>

<h5>Execução da aplicação</h5>
<ul>
  <li>Selecione a pasta Web/</li>
  <li>Execute o comando “yarn install” para instalar as dependências</li>
  <li>Execute o comando “yarn start” para iniciar a aplicação.</li>
</ul>

heroku 

frontned

    $ heroku login

    $ cd frontend/
    $ git init
    $ cd ba

    $ git add .
    $ git commit -am "make it better"
    $ git push heroku master

backend
    
    docker build -t devtiss-backend .
    local: docker run -d -p 80:80 devtiss/devtiss-backend

    $ heroku login

    $ docker ps

    $ heroku container:login

    $ heroku container:push web -a devtiss-backend

    $ heroku container:release web -a devtiss-backend


<h2>Apresentação</h2>
<img src="https://user-images.githubusercontent.com/14041111/83968224-088d5280-a89e-11ea-860e-7e95770985c4.gif">

<h2>Pontos de Refatoração</h2>
<ul>
  <li>Serparar aplicação em FrontEnd e BackEnd/</li>
  <li>Incluir a localização por Map</li>
  <li>Permitir que seja realizar o upload de imagem</li>
  <li>Criçaõ de app mobile</li>
</ul>

<h2>Agradecimentos</h2>
<p>Agradecimento especial para equipe @rocketseat e @maykbrito por disponibilizar os seus talentos, obrigado Jedis.<p>

