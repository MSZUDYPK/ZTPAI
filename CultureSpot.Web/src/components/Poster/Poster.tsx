import React from 'react';
import './Poster.css';

interface PosterProps {
    imgSrc?: string;
}

const Poster: React.FC<PosterProps> = ({ imgSrc }) => {
    return (
        <img src={imgSrc} className={'poster'} alt="Event poster" />
    );
};

export default Poster;