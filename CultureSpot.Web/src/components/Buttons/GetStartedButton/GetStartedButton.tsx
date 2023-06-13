import React, { FC } from 'react';
import { useNavigate } from 'react-router-dom';
import './GetStartedButton.css';

const GetStartedButton: FC = () => {
    const navigate = useNavigate();

    const handleClick = () => {
        navigate('/auth');
    };

    return (
        <button className={'get-started-btn'} onClick={handleClick}>Get Started</button>
    );
};

export default GetStartedButton;