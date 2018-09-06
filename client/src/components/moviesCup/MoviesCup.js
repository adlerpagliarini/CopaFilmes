import React, { Component } from 'react';
import { Container } from 'reactstrap';
import BoxJumbotron from '../BoxJumbotron';
import "./MoviesCup.css";

import MoviesMatchs from './MoviesMatchs';

import { connect } from 'react-redux';
import { getMoviesCupResult } from '../../actions/movies/movie-actions';
import PropTypes from 'prop-types';

class MoviesCup extends Component {

    state = {
        moviescup: [],
        winner: { id: 0, Titulo: '', Ano: 0, Nota: 0},
        second: { id: 0, Titulo: '', Ano: 0, Nota: 0}
    }

    componentDidMount(){        
        this.props.getMoviesCupResult(); //console.log('did mount old: ', this.props.moviesList.movieCupResult);
    }
    componentWillReceiveProps(nextProps){
       //console.log('old: ', this.props, 'nextProps: ', nextProps);
        this.setState({
            moviescup: nextProps.moviesList.movieCupResult,
            winner: nextProps.moviesList.movieCupResult.winner ? nextProps.moviesList.movieCupResult.winner : { id: 0, Titulo: '', Ano: 0, Nota: 0},
            second: nextProps.moviesList.movieCupResult.second ? nextProps.moviesList.movieCupResult.second : { id: 0, Titulo: '', Ano: 0, Nota: 0}});
    }

    renderFirstStageOfMatchs() {
        if(!this.state.moviescup || !this.state.moviescup.firstGroupStage) {
          return null;
        } else {
          return (            
            <div className="listOfMatchs">
                <MoviesMatchs props={{listOfMacths: this.state.moviescup.firstGroupStage.matchs, index: 1, counter: 1}} />
            </div>
          );
        }
    }

    renderSecondStageOfMatchs() {
        var counter = 2;
        if(!this.state.moviescup || !this.state.moviescup.nextGroupStages) {
          return null;
        } else {//console.log(this.state.moviescup.nextGroupStages.map(stage => { stage.matchs.map((match, i) => console.log(match, i)); } ))
          return (            
            <div className="listOfMatchs">
                {this.state.moviescup.nextGroupStages.map((stage, index) => (
                    <MoviesMatchs key={index} props={{listOfMacths: stage.matchs, index: index, counter: counter++}} />
                ))}                                
            </div>
          );
        }
    }

    render(){
        return (
            <Container>
                <BoxJumbotron props={{ title: "Resultado da competição!" }} />                
                <div className="listMoviesCup">
                    <div className="item">
                        <div className="selected">
                            <img src="images/gold.png" alt="winner"/>
                        </div>
                        <div className="details">
                            <div className="title">{this.state.winner.Titulo}</div>
                            <div className="year">Ano: {this.state.winner.Ano} - Score: {this.state.winner.Nota}</div>
                        </div>
                    </div>
                    <div className="item">
                        <div className="selected">
                            <img src="images/silver.png" alt="second"/>
                        </div>
                        <div className="details">
                            <div className="title">{this.state.second.Titulo}</div>
                            <div className="year">Ano: {this.state.second.Ano} - Score: {this.state.second.Nota}</div>
                        </div>
                    </div>
                </div>
                <h2 className="matchTitle">Acompanhe abaixo o resultado de cada partida!</h2>
                {this.renderFirstStageOfMatchs()}
                {this.renderSecondStageOfMatchs()}
            </Container>
        )
    }
}

MoviesCup.propTypes = {
    getMoviesCupResult: PropTypes.func.isRequired,
    moviesList: PropTypes.object.isRequired
}
const mapStateToProps = (state) => ({
    moviesList: state.MovieReducer
});

export default connect(mapStateToProps, {getMoviesCupResult})(MoviesCup);