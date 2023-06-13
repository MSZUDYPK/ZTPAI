import React from 'react';
import './FrontPage.css';
import Header from "../../components/Header/Header";
import SearchBar from "../../components/SearchBar/SearchBar";
import Carousel from "../../components/Carousel/Carousel";

const FrontPage = () => {

    return (
        <div className={'front-page'}>
            <Header />
            <div className={'content'}>
                <div className={'front-page-left-side'}>
                    <div className={'search-input-container'}>
                        <div className={'search-input-text'}>
                            <h1>Time to meet new friends!</h1>
                            <h2>Find events in your area</h2>
                        </div>
                    <SearchBar/>
                    </div>
                </div>
                <div className={'front-page-right-side'}>
                    <h1>Upcoming events</h1>
                    <div className={'event-carousel-container'}>
                        <Carousel />
                    </div>
                </div>
            </div>
        </div>
    );
};

export default FrontPage;