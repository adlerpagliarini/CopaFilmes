import { GET_MOVIES, POST_SELECTED_MOVIES, MOVIES_LOADING, MOVIES_CUP_RESULT } from '../movies/movie-types';
import axios from 'axios';
import { config, history } from '../../helpers';

const url = config.apiUrl;

export const setMoviesLoading = () => {
    return { type: MOVIES_LOADING };
}

export const getMovies = () => dispatch => { //dispatch can be used here because we've thunk, and allow us to use async requests with dispatch
    dispatch(setMoviesLoading());
    axios.get(url + '/api/movies')
        .then( res => dispatch({ type: GET_MOVIES, payload: res.data }));
}

export const postSelectedMovies = (selecetedIds) => dispatch => {
    axios.post(url + '/api/movies', selecetedIds).then(res => {
        dispatch({ type: POST_SELECTED_MOVIES, payload: res.data});
        history.push('/moviescup');
    });
}

export const getMoviesCupResult = () => {
    return { type: MOVIES_CUP_RESULT };
}