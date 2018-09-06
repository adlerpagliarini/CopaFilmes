import React from "react";
import "./Counter.css"

const Counter = ({props}) => {
    return (
        <div className="counter">
            <span>Filmes selecionados</span><br/>
            <span>{props.selected} de {props.amount}</span>
        </div>
    )
}

export default Counter;