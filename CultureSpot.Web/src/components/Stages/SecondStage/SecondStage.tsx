import React, {useContext} from "react";
import './SecondStage.css';
import SubmitButton from "../../Buttons/SubmitButton/SubmitButton";
import {CreatorContext} from "../../../context/CreatorContext";
import {useNavigate} from "react-router-dom";
import EventPlan from "../../EventPlan/EventPlan";

const SecondStage = () => {
    const creator = useContext(CreatorContext);
    const navigate = useNavigate();

    const handleSubmit = async (event: React.FormEvent) => {
        event.preventDefault();
        navigate('/creator/3');
    };

    return (
        <>
            <h1>Schedule</h1>
            <h3 className={'schedule-header'}>Customize your event plan:</h3>
            <EventPlan
                schedule={creator?.schedule || []}
                setSchedule={creator?.setSchedule || (() => {})}
            />
            <SubmitButton onClick={handleSubmit} />
        </>
    );
};

export default SecondStage;