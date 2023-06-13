import React, { FC } from 'react';
import { useNavigate } from 'react-router-dom';
import './CreateEventButton.css';

const GetStartedButton: FC = () => {
    const navigate = useNavigate();

    const handleClick = () => {
        navigate('/creator');
    };

    return (
        <button className={'create-event-btn'} onClick={handleClick}>Add event</button>
    );
};

export default GetStartedButton;