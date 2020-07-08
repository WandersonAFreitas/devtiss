import React from 'react';

import './Modal.css';

type cTitle = {
    title?: String;
    closed?: any;
}

const Modal: React.FC<cTitle> = ({ title, closed }: cTitle) => {

    return (
        <>
            <div id="modal">
                <div className="content">
                    <div className="header">
                        <h1>Aviso</h1>
                        {/* <a href="#" onClick={() => handleClosed}>Fechar</a> */}
                        <a href="/#" onClick={() => closed()}>Fechar</a>
                    </div>
                    <form action="">
                        <span>{title}</span>
                    </form>
                </div>
            </div>
        </>
    );
}

export default Modal;