import React, { useState } from 'react';
import './App.css';
import Dropzone from 'react-dropzone';
import { formatDistance } from "date-fns";
import pt from "date-fns/locale/pt";
import api from "../server/api";

import { ReactComponent as Logo } from '../assets/logo.svg';

function App() {
  const [itemFiles, setItemFiles] = useState<Array<any>>([]);
  const [download, setDownload] = useState("");

  const handleUpload = (files: any[]) => {

    const fetchFiles = async (file: any) => {
      const data = new FormData();
      data.append('XML', file);

      const response = await api.post('/ValidarXML', data);
      setItemFiles(itemFiles => ([response.data, ...itemFiles]));
    }

    files.forEach(async file => {
      await fetchFiles(file);
    });
  }

  return (
    <>
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
                  <li key={file.data}>
                    <a className="fileInfo" download={file.nome} href={file.url} target="_blank">
                      <span>{file.nome}</span>
                    </a>
                    <span>{file.transacao}</span>
                    <span>{file.versao}</span>
                    <span>{file.situacao}</span>
                    <span>há{" "}{formatDistance(Date.parse(file.data), new Date(), { locale: pt })}</span>
                  </li>
                ))
              }
            </ul>

            <button type="button">Downloads dos arquivo modificados</button>
          </div>
        </main>

        <footer>
          <p>Copyright © {new Date().getFullYear()} <a target='_blank' rel="noopener noreferrer" href="https://github.com/WandersonAFreitas">Freitas</a></p>
        </footer>
      </div>
    </>
  );
}

export default App;
