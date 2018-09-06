import React, { Component } from 'react';
import {
    Collapse, Navbar, NavbarToggler, 
    NavbarBrand, Nav, NavItem, NavLink, Container 
} from 'reactstrap';

import {NavLink as NavLinkReact} from 'react-router-dom';

class AppNavbar extends Component {
    state = { isOpen: false }
    constructor(props) {
        super(props);
        this.toggleHavToBeenBined = this.toggleHavToBeenBined.bind(this);
    }

    toggleHavToBeenBined() {
        console.log('Binded function because Im using arrow function');
     }
     
     toggle = () => {
        this.setState({
           isOpen: !this.state.isOpen 
        });
     }

     render(){
         return (
             <div>
                <Navbar color="dark" dark expand="sm" className="mb-5">
                    <Container>
                        <NavbarBrand href="/">
                            Copa Filmes
                        </NavbarBrand>
                        <NavbarToggler onClick={this.toggle} />
                        <Collapse isOpen={this.state.isOpen} navbar>
                            <Nav className="ml-auto" navbar>
                                <NavItem>
                                    <NavLinkReact to="/movies" exact activeStyle={{ color:'blank' }} className="nav-link">Home</NavLinkReact>
                                </NavItem>    
                                <NavItem>
                                    <NavLinkReact to="/moviescup" exact activeStyle={{ color:'blank' }} className="nav-link">Resultado</NavLinkReact>
                                </NavItem>
                                <NavItem>
                                    <NavLink href="https://github.com/adlerpagliarini/CopaFilmes">GitHub</NavLink>
                                </NavItem>
                            </Nav>
                        </Collapse>
                    </Container>
                </Navbar>
            </div>
         );
     }
}



export default AppNavbar;