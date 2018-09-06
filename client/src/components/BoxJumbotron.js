import React from 'react';
import { Jumbotron } from 'reactstrap';

const BoxJumbotron = ({props}) => {
         return (
            <div>
                <Jumbotron>
                    <h1 className="display-5">Copa de Filmes</h1>
                    <p>Selecione os filmes de sua preferência para realizar a competição e depois pressione o botão Gerar Campeonato.</p>
                    <b>Confira abaixo as etapas e regras da competição.</b>
                    <ul>
                        <li>Selecione ao menos 4 filmes de sua preferência.</li>
                        <li>Para mais filmes continue selecionando até que a quantidade seja uma potência de 2 (4, 8, 16...).</li>
                        <li>A lista de filmes selecionados será ordenada em ordem alfabética.</li>
                        <li>A primeira fase da disputa será uma batalha entre o primeiro e o último da lista ordenada e assim por diante.</li>
                        <li>As demais fases da disputa serão batalhas entre a sequência de ganhadores da fase anterior.</li>
                    </ul>
                    <h1 className="display-6">{props.title}</h1>
                </Jumbotron>
            </div>
         )
}

export default BoxJumbotron;