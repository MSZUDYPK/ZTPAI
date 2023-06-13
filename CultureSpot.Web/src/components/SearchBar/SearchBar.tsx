import React, { useState } from 'react';
import './SearchBar.css';
import {FontAwesomeIcon} from "@fortawesome/react-fontawesome";
import {faLocationDot} from "@fortawesome/free-solid-svg-icons";
import {faCircleXmark} from "@fortawesome/free-regular-svg-icons";
import SearchButton from "../Buttons/SearchButton/SearchButton";


const SearchBar = () => {
    return (
        <div className={'searchbar-container'}>
            <FontAwesomeIcon icon={faLocationDot} className={'search-input-icon'}/>
            <input type="text" placeholder="Kraków, Krowodrza"/>
            <FontAwesomeIcon icon={faCircleXmark} className={'search-input-icon'}/>
            <SearchButton />
        </div>
    );
};

export default SearchBar;