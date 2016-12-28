import * as React from "react"

interface IChatBoxProps {
    onsubmit: (text:string) => void
}
interface IChatBoxState {
    text: string;
}

export class ChatBox extends React.Component<IChatBoxProps, IChatBoxState> {
    constructor(props: IChatBoxProps) {
        super(props);
        this.state = { text: "" };
    }

    render() {
        return <div className="clearfix">
            <textarea className="form-control" onChange={this.changeHandler} value={this.state.text}></textarea>
            <br />
            <button className="btn btn-primary pull-right" onClick={this.clickHandler}>Plaats bericht</button>
        </div>
    }

    changeHandler = (evt: React.FormEvent<HTMLTextAreaElement>) => {
        this.setState({text : evt.currentTarget.value});
    }

    clickHandler = (evt: React.MouseEvent<HTMLButtonElement>) => {
        var state = this.state.text;
        this.props.onsubmit(state);
        this.setState({text:''});
    }
}