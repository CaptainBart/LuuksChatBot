import * as React from "react"
import { ChatBox } from "./ChatBox"
import { ChatList } from "./ChatList"
import * as Model from "../models"
//import * as $ from 'jquery'

interface IChatListProps {
    user: string;
    chathubUrl: string;
}

interface IChatListState {
    posts: Model.Post[];
} 

export class ChatListContainer extends React.Component<IChatListProps, IChatListState> {
    private hubConnection: SignalR.Hub.Connection;
    private hub: SignalR.Hub.Proxy;
    constructor(props: IChatListProps) {
        super(props);
        this.state = { posts: [] };
        try {
            this.hubConnection = $.hubConnection(this.props.chathubUrl + "/signalr", { useDefaultPath: false });
            this.hub = this.hubConnection.createHubProxy('postsHub');
        }
        catch (err) {
            throw err;
        }
        this.hub.on('publishPost', (msg: Model.Post) => {
            console.log(msg); 
            this.addPost(msg);
        });

        this.hubConnection.start().done(() => {
            console.log('connected');
        });
    } 

    render() {
        return <div className="panel panel-default">
            <div className="panel-body chatlist-container">
                <ChatList posts={this.state.posts} />
            </div>
            <div className="panel-footer">
                <ChatBox onsubmit={this.submitHandler} />
            </div>
        </div>
    }

    addPost(post: Model.Post) {
        this.setState((prevState, props) => {
                return {
                    posts: prevState.posts.concat(post)
                }
            });
    }

    submitHandler = (text: string) => {
        var post : Model.Post = {
            author: this.props.user,
            createdOn: new Date(),
            message : text
        };
        $.ajax({
            url: this.props.chathubUrl  + '/api/posts/',
            method: 'post',
            contentType: 'application/json',
            data: JSON.stringify(post)
        });
    }
}