import React from "react";
import './OAuthButton.css';
import {FontAwesomeIcon} from "@fortawesome/react-fontawesome";
const OAuthButton = (props : any) => {
    return (
        <button className={'oauth-btn'}>
            <FontAwesomeIcon icon={props.icon} className={'oauth-icon'}/>
            <span className={'oauth-btn-text'}>{props.text}</span>
        </button>
    );
}

export default OAuthButton;