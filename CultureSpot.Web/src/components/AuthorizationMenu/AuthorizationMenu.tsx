import React, { FC, useState } from 'react';
import './AuthorizationMenu.css';

const AuthorizationMenu: FC<{ onButtonClick: (buttonName: string) => void }> = ({ onButtonClick }) => {
    const [activeButton, setActiveButton] = useState("login");

    const handleButtonClick = (buttonName: string) => {
        setActiveButton(buttonName);
        onButtonClick(buttonName);
    };

    return (
        <>
            <button className={activeButton === "login" ? "active" : ""} onClick={() => handleButtonClick("login")}>Login</button>
            <button className={activeButton === "sign-up" ? "active" : ""} onClick={() => handleButtonClick("sign-up")}>Sign Up</button>
        </>
    );
};

export default AuthorizationMenu;