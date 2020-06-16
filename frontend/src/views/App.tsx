import React, { useState } from 'react';
import './App.css';
import Dropzone from 'react-dropzone';
import { formatDistance } from "date-fns";
import pt from "date-fns/locale/pt";
import api from "../server/api";

import { ReactComponent as Logo } from '../assets/logo.svg';

interface Files {
  id: number,
  name: string,
  transacao?: string,
  versao?: string,
  situacao: string,
  createdAt: Date
}

function App() {
  const [itemFiles, setItemFiles] = useState<Array<Files>>([]);

  const handleUpload = (files: any[]) => {
    let _files: any[] = [];

    files.forEach(file => {
      _files = _files.concat({
        id: Math.floor(Math.random() * 100),
        name: file.name,
        situacao: 'Validando...',
        createdAt: new Date()
      });

      const data = new FormData();
      data.append('XML', file);

      api.post('/ValidarXML', data).then((resp) => {
        console.log(resp.data);
      })
    });

    setItemFiles(_files.concat(itemFiles));
  }

  return (
    <div className="App">
      <header>
        <div>
          <Logo />
          <h1>DevTiss</h1>
        </div>
        <a target="_blank" rel="noopener noreferrer" href="http://www.ans.gov.br/prestadores/tiss-troca-de-informacao-de-saude-suplementar">
          <span></span>
          Tiss Ans
        </a>
      </header>

      <main>
        <div id="form">
          <legend>
            <h2>Validar XML</h2>
          </legend>

          <Dropzone onDropAccepted={handleUpload}>
            {
              ({ getRootProps, getInputProps }) => (
                <div className="upload" {...getRootProps()}>
                  <input {...getInputProps()} />
                  <p>Arraste o arquivo ou clique aqui</p>
                </div>
              )
            }
          </Dropzone>

          <ul>
            <li>
              <span>Arquivo</span>
              <span>Transação</span>
              <span>Versão</span>
              <span>Situação</span>
              <span>Data/Hora</span>
            </li>
            {
              itemFiles && itemFiles.map((file) => (
                <li key={file.id}>
                  <a className="fileInfo" href="/">
                    <span>{file.name}</span>
                  </a>
                  <span>{file.transacao}</span>
                  <span>{file.versao}</span>
                  <a className="situacao" href="/">
                    <span>{file.situacao}</span>
                  </a>
                  <span>há{" "}{formatDistance(file.createdAt, new Date(), { locale: pt })}</span>
                </li>
              ))
            }
          </ul>

          <button type="button">Downloads dos arquivo modificados</button>
        </div>
      </main>

      <footer>
          <p>Copyright © { new Date().getFullYear() } <a target='_blank' rel="noopener noreferrer" href="https://github.com/WandersonAFreitas">Freitas</a></p>
      </footer>
    </div>
  );
}

export default App;
