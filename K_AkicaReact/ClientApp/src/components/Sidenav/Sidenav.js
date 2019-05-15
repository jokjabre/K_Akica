import React, { Component } from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';

import './sidenav.css';

export class Sidenav extends Component {
    static displayName = Sidenav.name;

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

    onPooperClick = (pooperId) => (event) => {
        this.setState({ clickedPooperKey: pooperId });
        this.props.pooperClick(pooperId);
    }


    render() {
        return (

            <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white mb-4 p-1 sidenav position-fixed" light>
                <Container className="d-flex flex-column p-0">
                    <NavbarBrand>Poopers</NavbarBrand>
                    <NavbarToggler onClick={this.toggleNavbar} className="mr-2" />
                    <Collapse className="d-flex flex-column" isOpen={!this.state.collapsed} navbar>
                        <ul className="navbar-nav flex-grow flex-column">
                            {this.props.poopers.map(pooper =>

                                <NavItem key={pooper.id.toString()} className="hoverable">
                                    <NavLink
                                        className={(this.state.clickedPooperKey === pooper.id ? "clicked" : "") + " text-dark"}
                                        onClick={this.onPooperClick(pooper.id)}>{pooper.name}
                                    </NavLink>
                                </NavItem>

                            )}
                        </ul>
                    </Collapse>
                </Container>
            </Navbar>
        );
    }
}
