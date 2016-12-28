import * as React from "react"
import * as ReactDOM from "react-dom";
import * as moment from "moment"
import * as Model from "../models"


interface IChatListProps {
    posts: Model.Post[];
}

export class ChatList extends React.Component<IChatListProps, {}> {
    private shouldScrollBottom: boolean;
    constructor() {
        super();
    }

    render() {
        var messages = this.props.posts.map((p) => this.renderChildItem(p));
        return <div className="list-group chatlist">{messages}</div>
    }

    renderChildItem(post: Model.Post) {
        return <a href="#" className="list-group-item">
            <h5 className="list-group-item-heading"><strong>{post.author}</strong> zei om {moment(post.createdOn).format('HH:mm')}:</h5>
            <p className="list-group-item-text">{post.message}</p>
        </a>
    }

    componentWillUpdate() {
        var node = ReactDOM.findDOMNode<HTMLDivElement>(this);
        this.shouldScrollBottom = node.scrollTop + node.offsetHeight === node.scrollHeight;
    }

    componentDidUpdate() {
        if (this.shouldScrollBottom) {
            var node = ReactDOM.findDOMNode<HTMLDivElement>(this);
            node.scrollTop = node.scrollHeight
        }
    }
}