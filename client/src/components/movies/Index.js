import React, { Component } from 'react';
import MoviesList from './MoviesList';

import { Container } from 'reactstrap';

class Index extends Component {
  render() {
    return (
        <Container>
            <MoviesList />
        </Container>
    );
  }
}

export default Index;
