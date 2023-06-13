import React, {useEffect, useState} from "react";
import './MultiStepProgressBar.css';
import {useLocation} from "react-router-dom";

const MultiStepProgressBar = () => {
    const [step, setStep] = useState(1);
    const location = useLocation();

    useEffect(() => {
        switch (location.pathname) {
            case '/creator':
                setStep(1);
                break;
            case '/creator/2':
                setStep(2);
                break;
            case '/creator/3':
                setStep(3);
                break;
            case '/creator/4':
                setStep(4);
                break;
            default:
                setStep(1);
        }
    }, [location]);

    let width;
    switch (step) {
        case 1:
            width = '0';
            break;
        case 2:
            width = '33%';
            break;
        case 3:
            width = '66%';
            break;
        case 4:
            width = '100%';
            break;
        default:
            width = '0';
    }

    return (
        <div className="steps">
            <span className={`circle ${step >= 1 ? 'active' : ''}`}></span>
            <span className={`circle ${step >= 2 ? 'active' : ''}`}></span>
            <span className={`circle ${step >= 3 ? 'active' : ''}`}></span>
            <span className={`circle ${step >= 4 ? 'active' : ''}`}></span>
            <div className="progress-bar">
                <span className="indicator" style={{ width: width }}></span>
            </div>
        </div>
    );
}

export default MultiStepProgressBar;