import React, { Component } from 'react';
import { NavMenu } from './NavMenu';
import { TimelineNode } from "./Timeline/TimelineNode";


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

    pooperClicked = id => {
        alert("aaa");
    }

    render() {
        return (
            <div className="d-flex flex-row">
                <NavMenu poopers={this.state.poopers} pooperClick={this.pooperClicked} />
                <TimelineNode />

            </div>
        );
    }
}
