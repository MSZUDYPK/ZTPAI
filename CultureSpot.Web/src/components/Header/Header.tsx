import React, {FC, useContext, useEffect, useState} from 'react';
import { AuthContext } from '../../context/AuthContext';
import './Header.css';
import logo from './../../assets/logo.svg';
import GetStartedButton from "../Buttons/GetStartedButton/GetStartedButton";
import CreateEventButton from "../Buttons/CreateEventButton/CreateEventButton";
import {useNavigate} from "react-router-dom";
import axios from "axios/index";

const Header: FC = () => {
    const auth = useContext(AuthContext);
    const [navVisible, setNavVisible] = useState<boolean>(false);
    const navigate = useNavigate();

    const toggleNav = () => {
        setNavVisible(!navVisible);
    };

    const handleClick = () => {
        if (window.location.pathname !== '/events') {
            navigate('/events');
        }
    }

    return (
        <header className={'header'}>
            <div className={'logo'} onClick={handleClick}>
                <img src={logo} alt="Logo" />
            </div>
            {auth?.isLoggedIn ?  <CreateEventButton /> : <GetStartedButton />}
            <button className={'hamburger-btn'} onClick={toggleNav}>
                &#9776;
            </button>
        </header>
    );
};

export default Header;