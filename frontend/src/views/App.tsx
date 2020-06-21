import React, { useState } from 'react';
import './App.css';
import Dropzone from 'react-dropzone';
import { formatDistance } from "date-fns";
import pt from "date-fns/locale/pt";
import api from "../server/api";

import { ReactComponent as Logo } from '../assets/logo.svg';

function App() {
  const [itemFiles, setItemFiles] = useState<Array<any>>([]);

  const handleUpload = (files: any[]) => {

    const fetchFiles = async (file: any) => {
      const data = new FormData();
      data.append('XML', file);

      const response = await api.post('/ValidarXML', data);

      // 2. Crie um link de blob para baixar 
      const url = window.URL.createObjectURL(new Blob([response.data.xml]));
      // const link = document.createElement ('a'); 
      // link.href = url; 
      // link.setAttribute('download', response.data.nome);
      // 3. Anexe à página html 
      // document.body.appendChild (link);
      // 4. Force o download do 
      // link.click ();
      // 5. Limpe e remova o link 
      //link.parentNode.removeChild (link);
      if (response.data.xml)
        response.data['url'] = url;

      setItemFiles(itemFiles => ([response.data, ...itemFiles]));
    }

    files.forEach(async file => {
      await fetchFiles(file);
    });
  }

  const handleDownloads = (itemFiles: any[]) => {
    const files = itemFiles.filter(item => {
      return item.xml;
    });
    
    files.forEach(file => {
      const link = document.createElement ('a'); 
      link.href = file.url; 
      link.setAttribute('download', file.nome);
      document.body.appendChild (link);
      link.click ();
      link.parentNode?.removeChild(link);
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
                itemFiles && itemFiles.map((file, i) => (
                  <li key={i}>
                    <a className="fileInfo" href={file.url} download={file.nome} target="_blank" rel="noopener noreferrer">
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

            <button type="button" onClick={() => handleDownloads(itemFiles)}>Downloads dos arquivo modificados</button>
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
