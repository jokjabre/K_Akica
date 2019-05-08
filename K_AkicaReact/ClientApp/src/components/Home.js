import React, { Component } from 'react';
import { NavMenu } from './NavMenu';

export class Home extends Component {
    static displayName = Home.name;

    constructor(props) {
        super(props);
        this.state = { poopers: [] };


    }

    componentDidMount() {
        fetch('Home/Poopers')
            .then(response => response.json())
            .then(data => {
                this.setState({ poopers: data });
            });
    }

    render() {
        return (
            <div className="d-flex flex-row bg-info">
                <NavMenu poopers={this.state.poopers} />
                <h1 className="flex-fill bg-danger">Hello, world!</h1>

            </div>
        );
    }
}
