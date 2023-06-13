import React, {useContext, useEffect, useState} from 'react';
import './AuthorizationPage.css';
import logo from "../../assets/logo.svg";
import AuthorizationMenu from "../../components/AuthorizationMenu/AuthorizationMenu";
import LogIn from "../../components/Inputs/LogIn/LogIn";
import SignUp from "../../components/Inputs/SignUp/SignUp";
import {AuthContext} from "../../context/AuthContext";

const AuthorizationPage = () => {
    const [activeButton, setActiveButton] = useState("login");
    const auth = useContext(AuthContext);

    useEffect(() => {
        if (auth?.isLoggedIn) {
            window.location.href = "/";
        }
    }, [auth?.isLoggedIn]);



    return (
            <div className={'authorization-page'}>
                <div className={'logo'}>
                    <img src={logo} alt="Logo" />
                </div>
                <div className={'authorization-container'}>
                    <div className={'authorization-menu-container'}>
                        <AuthorizationMenu onButtonClick={setActiveButton} />
                    </div>
                    {activeButton === "login" && <LogIn />}
                    {activeButton === "sign-up" && <SignUp />}
                </div>
            </div>
    );
};

export default AuthorizationPage;