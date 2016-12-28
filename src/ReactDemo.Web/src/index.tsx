import * as React from "react";
import * as ReactDOM from "react-dom";
import { ChatListContainer } from "./components/ChatListContainer"

ReactDOM.render(
    <div>
        <ChatListContainer user="Bart" chathubUrl="http://localhost:3690" />
    </div>,
    document.getElementById("app")
);