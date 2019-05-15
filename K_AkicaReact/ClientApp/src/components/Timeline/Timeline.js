import React, { Component } from "react";
import { TimelineNode } from "./TimelineNode";
import "./timeline.css";

export class Timeline extends Component {
    static displayName = Timeline.name;

    constructor(props) {
        super(props);

        //this.incrementCounter = this.incrementCounter.bind(this);
    }

    render() {
        return (
                <div className="Timeline container">
                    {this.props.feedItems.map(feed =>
                        <TimelineNode key={feed.id.toString()} feedItem={feed} />
                    )}
                </div>
        );
    }
}
