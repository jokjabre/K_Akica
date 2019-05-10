import React, { Component } from "react";
import "./timeline.css";

export class TimelineNode extends Component {
    static displayName = TimelineNode.name;

    constructor(props) {
        super(props);

        //this.incrementCounter = this.incrementCounter.bind(this);
    }

    render() {
        return (
            <div className="Timeline-Node">
                <div className="Timeline-Header">
                    <h3 className="Timeline-Time">{this.props.feedItem.time}</h3>
                    <div className="Timeline-Icons" />
                    <div className="Timeline-Duration" >{this.props.feedItem.duration}</div>
                </div>
                <div className="Timeline-Description">
                    <p>
                        {this.props.feedItem.description.map((desc, index) =>
                            <React.Fragment key={index.toString()}>
                                {desc} <br />
                            </React.Fragment>
                        )}
                    </p>
                </div>
            </div>
        );
    }
}
