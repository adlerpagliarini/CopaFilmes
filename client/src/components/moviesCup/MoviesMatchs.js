import React from "react";
import { Container, Row, Col } from 'reactstrap';

const MoviesMatchs = ({props}) => {
    return (
        <Container key={props.index}>                    
            <h2 className="matchTitle">Eliminatórias Fase {props.counter}</h2>
            <Row>
                {props.listOfMacths.map((matchs, ii) => (
                    <Col key={ii}>
                        <div className="details">
                            <div className="title">{matchs.movieOne.Titulo}</div>
                            <div className="text"><span>Score: {matchs.movieOne.Nota}</span>  {matchs.movieOne.id === matchs.winner.id ? <img src="images/win.png" alt="winner"/> : null }</div>
                        </div>
                        <div className="details">
                            <div className="title">{matchs.movieTwo.Titulo}</div>
                            <div className="text"><span>Score: {matchs.movieTwo.Nota}</span>  {matchs.movieTwo.id === matchs.winner.id ? <img src="images/win.png" alt="winner"/> : null }</div>
                        </div>
                    </Col>
                ))}
            </Row>
        </Container>
    )
}

export default MoviesMatchs;