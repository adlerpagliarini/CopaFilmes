import React, { Component } from 'react';
import { Container, Button } from 'reactstrap'
import "./MoviesList.css";

import Counter from '../counter/Counter';
import BoxJumbotron from '../BoxJumbotron';

import { connect } from 'react-redux';
import { getMovies, postSelectedMovies } from '../../actions/movies/movie-actions';
import PropTypes from 'prop-types';

class MoviesList extends Component {

    state = {
        selectedMovies: [],
        countSelectedMovies: 0,
        isSubmitButtonEnabled: false
    }

    componentDidMount(){
        this.props.getMovies(); // will go to actions to perfom it
    }

    onPostClick = ()  => {
        this.props.postSelectedMovies(this.state.selectedMovies);
    }

    onSelectedMovie = (id)  => {
        let updateSelectedMovies = this.state.selectedMovies;
        let updateCountSelectedMovies = this.state.countSelectedMovies;

        const index = updateSelectedMovies.findIndex(item => item === id);
        if(index > -1) {
            updateCountSelectedMovies--;
            updateSelectedMovies = updateSelectedMovies.filter(item => item !== id);
        } else {
            updateCountSelectedMovies++;
            updateSelectedMovies.push(id);
        }
        
        this.enableSubmitButton(updateCountSelectedMovies);

        this.setState({
                    selectedMovies: [...updateSelectedMovies],
                    countSelectedMovies: updateCountSelectedMovies,
                });
    }

    enableSubmitButton = (amountOfSelectedItems) => {
        if(this.isPowerOfTwoAndBiggerThanFour(amountOfSelectedItems)) // if(amountOfSelectedItems === 8) //

            this.setState({ isSubmitButtonEnabled : true });
        else
            this.setState({ isSubmitButtonEnabled : false });
    }

    isPowerOfTwoAndBiggerThanFour(value){
        return ((value >= 4) && ((value) & (value - 1)) === 0);
    }

    render(){
        const { movies } = this.props.moviesList;
        const styleLoad = this.props.moviesList.loading ? {color: '#fff', padding: '20px 0'} : {display: 'none'};
        return(
            <Container>
                <BoxJumbotron props={{ title: "Aposte no seu filme preferido e confira o resultado!"  }} />
                <Container>
                    <Counter props={{ selected: this.state.countSelectedMovies, amount: movies.length  }} />
                    <Button className="postBtn" color="warning" size="sm"
                        onClick={this.onPostClick.bind(this)} disabled={!this.state.isSubmitButtonEnabled}>
                        Gerar Campeonato
                    </Button>
                </Container>
                <h2 style={styleLoad}>Os dados estão sendo carregados por favor, aguarde...</h2>
                <div className="listOfMovies">
                    {movies.map(m => (
                        <div key={m.id} className="item">
                            <div className="selected">
                                <input type="checkbox" onClick={this.onSelectedMovie.bind(this, m.id)} />
                            </div>
                            <div className="details">
                                <div className="title">{m.Titulo}</div>
                                <div className="year">Ano: {m.Ano}</div>
                            </div>
                        </div>
                    ))}
                </div>
            </Container>
        )
    }
}

MoviesList.propTypes = { //when a action is imported from redux it's add to your class as a prop
    getMovies: PropTypes.func.isRequired,
    postSelectedMovies: PropTypes.func.isRequired,
    moviesList: PropTypes.object.isRequired
}
const mapStateToProps = (state) => ({
    moviesList: state.MovieReducer
});

export default connect(mapStateToProps, {getMovies, postSelectedMovies})(MoviesList);