import { GET_MOVIES, POST_SELECTED_MOVIES, MOVIES_LOADING, MOVIES_CUP_RESULT } from '../../actions/movies/movie-types';

const initialState = {
  movies: [],
  moviesSelected: [],
  movieCupResult: {},
  loading: false
}

export default function(state = initialState, {type, payload}){
    switch(type){
        case GET_MOVIES:
            return{
                ...state,
                movies: [...payload],
                loading: false
            };
        case POST_SELECTED_MOVIES:
            return{
                ...state,
                movieCupResult: payload
            };
        case MOVIES_LOADING:
            return{
                ...state,
                loading: true
            };
        case MOVIES_CUP_RESULT:
            return{
              ...state
            }
        default:
            return state;
        
    }
}