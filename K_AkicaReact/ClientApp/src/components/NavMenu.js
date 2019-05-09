import React, { Component } from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';

import './NavMenu.css';
import '../css/sidenav.css';

export class NavMenu extends Component {
    static displayName = NavMenu.name;

    constructor(props) {
        super(props);

        this.state = { poopers: [] };
        this.toggleNavbar = this.toggleNavbar.bind(this);
        this.state = {
            collapsed: true,
            clickedPooperKey: null
        };
    }

    toggleNavbar() {
        this.setState({
            collapsed: !this.state.collapsed
        });
    }

    onPooperClick = (elem) => (event) => {
        alert(elem);
        this.setState({ clickedPooperKey: 0 });
        this.props.pooperClick();
    }


    render() {
        return (

            <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white mb-4 p-1 sidenav" light>
                <Container className="d-flex flex-column p-0">
                    <NavbarBrand>Poopers</NavbarBrand>
                    <NavbarToggler onClick={this.toggleNavbar} className="mr-2" />
                    <Collapse className="d-flex flex-column" isOpen={!this.state.collapsed} navbar>
                        <ul className="navbar-nav flex-grow flex-column">
                            {this.props.poopers.map(pooper =>

                                <NavItem key={pooper.id.toString()} className="hoverable">
                                    <NavLink className="text-dark" onClick={this.onPooperClick(pooper.id)}>{pooper.name}</NavLink>
                                </NavItem>

                            )}
                        </ul>
                    </Collapse>
                </Container>
            </Navbar>
        );
    }
}
