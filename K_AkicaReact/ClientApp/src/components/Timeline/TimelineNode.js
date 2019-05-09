import React, { Component } from "react";
import "./timeline.css";

export class TimelineNode extends Component {
    static displayName = TimelineNode.name;

    constructor(props) {
        super(props);

        this.state = { currentCount: 0 };
        this.incrementCounter = this.incrementCounter.bind(this);
    }

    incrementCounter() {
        this.setState({
            currentCount: this.state.currentCount + 1
        });
    }

    render() {
        return (
            <div className="Timeline-Node">
                <div className="Timeline-Header">
                    <h3 className="Timeline-Time">19:53</h3>
                    <div className="Timeline-Icons" />
                    <div className="Timeline-Duration" />
                </div>
                <div className="Timeline-Description">
                    <p>
                        Creative Direction,
            <br />
                        User Experience, <br />
                        Visual Design, <br />
                        Project Management, <br />
                        Team <br />
                        Leading
            <br />
                        <br />
                        <br />
                        <br />
                        <br />
                    </p>
                </div>
            </div>
        );
    }
}
