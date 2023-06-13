import React from 'react';
import './creator.css';
import FirstStage from "../../components/Stages/FirstStage/FirstStage";
import Header from "../../components/Header/Header";
import {CreatorProvider} from "../../context/CreatorContext";
import {Route, Routes} from "react-router-dom";
import SecondStage from "../../components/Stages/SecondStage/SecondStage";
import MultiStepProgressBar from "../../components/MultiStepProgressBar/MultiStepProgressBar";
import ThirdStage from "../../components/Stages/ThirdStage/ThirdStage";
import FourthStage from "../../components/Stages/FourthStage/FourthStage";

const Creator = () => {
    return (
        <CreatorProvider>
            <div className={'creator'}>
                <Header />
                <Routes>
                    <Route path={'/'} element={<FirstStage />} />
                    <Route path={'/2'} element={<SecondStage />} />
                    <Route path={'/3'} element={<ThirdStage />} />
                    <Route path={'/4'} element={<FourthStage />} />
                </Routes>
                <div className={'progress-bar-container'}>
                    <MultiStepProgressBar/>
                </div>
            </div>
        </CreatorProvider>
    );
};

export default Creator;