import React from "react";
import './AuthorizationButton.css';

const AuthorizationButton = (props : any) => {
    return (
        <button className={'authorization-btn'} onClick={props.onClick}>{props.text}</button>
    );
};

export default AuthorizationButton;