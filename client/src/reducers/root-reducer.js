import { combineReducers } from 'redux';
import MovieReducer from './movies/movie-reducer';

export default combineReducers(
	{
		MovieReducer: MovieReducer
	}
);