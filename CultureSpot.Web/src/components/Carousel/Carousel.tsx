import React from 'react';
import './Carousel.css';
import Poster from "../Poster/Poster";
import poster1 from "../../assets/poster1.jpg";
import poster2 from "../../assets/poster2.jpg";
import poster3 from "../../assets/poster3.jpg";
import {FontAwesomeIcon} from "@fortawesome/react-fontawesome";
import {faChevronRight, faChevronLeft} from "@fortawesome/free-solid-svg-icons";

const Carousel = () => {
    return (
        <div className={'carousel-container'}>
            <FontAwesomeIcon icon={faChevronLeft} className={'nav-icon'}/>
            <div id={'first-card'} className={'carousel-card'}>
                <Poster imgSrc={poster1} />
            </div>
            <div id={'second-card'} className={'carousel-card'}>
                <Poster imgSrc={poster2} />
            </div>
            <div id={'third-card'} className={'carousel-card'}>
                <Poster imgSrc={poster3} />
            </div>
            <FontAwesomeIcon icon={faChevronRight} className={'nav-icon'}/>
        </div>
    );
};

export default Carousel;