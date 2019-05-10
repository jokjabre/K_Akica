import React, { Component } from 'react';
import { Sidenav } from './Sidenav/Sidenav';
import { Timeline } from '../components/Timeline/Timeline';

export class Home extends Component {
    static displayName = Home.name;

    constructor(props) {
        super(props);
        this.state = {
            poopers: [],
            feedItems: []
        };

        this.pooperClicked = this.pooperClicked.bind(this);
    }

    componentDidMount() {
        fetch('Home/Poopers')
            .then(response => response.json())
            .then(data => {
                this.setState({ poopers: data });
            });
    }

    pooperClicked = pId => {
        fetch(`Home/FeedItems/?id=${pId}`)
            .then(response => response.json())
            .then(data => {
                this.setState({ feedItems: data });
            });
    }

    render() {
        return (
            <div className="main d-flex flex-row">
                <Sidenav poopers={this.state.poopers} pooperClick={this.pooperClicked} /> 

                <Timeline feedItems={this.state.feedItems}/>
            </div>
        );
    }
}
