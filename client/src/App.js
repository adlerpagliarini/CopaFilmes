import React, { Component } from 'react';
import AppNavbar from './components/AppNavbar';

import MoviesList from './components/movies/Index';
import MoviesCup from './components/moviesCup/Index';

import { Provider } from 'react-redux';
import store from './store/store';

import { Container } from 'reactstrap';
import 'bootstrap/dist/css/bootstrap.min.css';
import './App.css';

//import { BrowserRouter as Router, Route } from 'react-router-dom'; // BrowserRouter <Router> || <Router history={history}> 
import { Router, Route } from 'react-router-dom';
import { history } from './helpers';


class App extends Component {
  render() {
    return ( //provider provide a way to share states between components
      <Provider store={store}>
        <Router history={history}> 
          <div className="App">
              <AppNavbar />
              <Container>
                  <Route exact path="/" component={MoviesList} />
                  <Route path="/movies" component={MoviesList} />
                  <Route path="/moviescup" component={MoviesCup} />                
              </Container>
          </div>
        </Router>
      </Provider>
    );
  }
}

export default App;
