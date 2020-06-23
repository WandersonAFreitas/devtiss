<h1>Dev Tiss</h1>
<p>Esse projeto permitirá que todos os Devs tenha o conhecimento do desenvolvimento do padrão Tiss.</p>

<h4>Tecnlogias utilizadas</h4>
<ul>
    <li>React</li>
    <li>React-Native</li>
    <li>Node.js</li>
    <li>C#</li>
</ul>

<h4>Estapas do Projeto</h4>
<ul>
    <li>Configuração da estrutura do Projeto</li>
    <li>Desenvolvimento do FrontEnd</li>
    <li>Desenvolvimento do BackEnd</li>
</ul>


heroku 
    frontned
$ heroku login

$ cd frontend/
$ git init
$ heroku git:remote -a devtiss-backend

$ git add .
$ git commit -am "make it better"
$ git push heroku master

    backend
$ heroku login

$ docker ps

$ heroku container:login

$ heroku container:push web -a devtiss-backend

$ heroku container:release web -a devtiss-backend