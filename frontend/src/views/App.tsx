import React, { useState, useEffect } from 'react';
import './App.css';
import Dropzone from 'react-dropzone';
import { formatDistance } from "date-fns";
import pt from "date-fns/locale/pt";
import api from "../server/api";

import { MdWarning } from "react-icons/md";
import { ReactComponent as Logo } from '../assets/logo.svg';
import Modal from './modal/Modal';

function App() {
  const [itemFiles, setItemFiles] = useState<Array<any>>([]);
  const [versao, setVersao] = useState('Não identificada');
  const [ocorrencia, setOcorrencia] = useState('');


  const handleUpload = (files: any[]) => {

    const fetchFiles = async (file: any) => {
      const data = new FormData();
      data.append('XML', file);

      const response = await api.post('/ValidarXML/Validar', data);
      const url = window.URL.createObjectURL(new Blob([response.data.xml]));

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
      const link = document.createElement('a');

      link.href = file.url;
      link.setAttribute('download', file.nome);

      document.body.appendChild(link);

      link.click();
      link.parentNode?.removeChild(link);
    });
  }

  const handleCloseOcorrenica = () => {
    console.log('entro');
    setOcorrencia('');
  }

  useEffect(() => {
    api.get('/ValidarXML/VersaoSuportada').then(resp => {
      setVersao(resp.data)
    })
  })

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
              <span>Ultima versão suportada {versao}</span>
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
                    <a href={file.url} download={file.nome} target="_blank" rel="noopener noreferrer">
                      {/* <MdWarning size={12} color="#AF5F"/> */}
                      <span>{file.nome}</span>
                    </a>
                    <span>{file.transacao}</span>
                    <span>{file.versao}</span>
                    {file.ocorrencia ? <a href="#" onClick={() => setOcorrencia(file.ocorrencia)}>
                      <span>{file.situacao}</span>
                    </a> : <a onClick={() => setOcorrencia(file.ocorrencia)}>
                        <span>{file.situacao}</span>
                      </a>}
                    <span>há{" "}{formatDistance(Date.parse(file.data), new Date(), { locale: pt })}</span>
                  </li>
                ))
              }
            </ul>
            <button type="button" onClick={() => handleDownloads(itemFiles)}>Downloads todos</button>
          </div>
        </main>

        <footer>
          <p>Copyright © {new Date().getFullYear()} <a target='_blank' rel="noopener noreferrer" href="https://github.com/WandersonAFreitas">Freitas</a></p>
        </footer>
      </div>

      {ocorrencia ? <Modal title={ocorrencia} closed={handleCloseOcorrenica} /> : null}

    </>
  );
}

export default App;
