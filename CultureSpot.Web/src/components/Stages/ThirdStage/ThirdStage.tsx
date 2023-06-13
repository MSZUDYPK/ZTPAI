import React, {ChangeEvent, useContext, useState} from "react";
import './ThirdStage.css';
import SubmitButton from "../../Buttons/SubmitButton/SubmitButton";
import {CreatorContext, PriceOptions} from "../../../context/CreatorContext";
import {useNavigate} from "react-router-dom";
import LabeledInput from "../../Inputs/LabeledInput/LabeledInput";

const ThirdStage = () => {
    const creator = useContext(CreatorContext);
    const [inputsSet, setInputsSet] =  useState([false, false, false]);
    const navigate = useNavigate();

    const handleSubmit = async (event: React.FormEvent) => {
        const newInputsSet = [
            !creator?.eventLocation,
            !creator?.eventDate,
            !creator?.capacity,
        ];
        setInputsSet(newInputsSet);


        if (!newInputsSet.includes(true)) {
            creator?.createEvent();
            setInputsSet([true, true, true])
            navigate('/creator/4');
        }
    };

    return (
        <>
            <h1>Location</h1>
            <div className={'form-group'}>
                <LabeledInput
                    label={'Location*'}
                    type={'text'}
                    required={true}
                    value={creator?.eventLocation}
                    className={'location-input' + (inputsSet[0] ? ' warning' : '')}
                    onChange={(e: ChangeEvent<HTMLInputElement>) => creator?.setEventLocation(e.target.value)}
                />
                <LabeledInput
                    label={'Date*'}
                    type={'date'}
                    value={creator?.eventDate}
                    onChange={(e: ChangeEvent<HTMLInputElement>) => creator?.setEventDate(e.target.value)}
                    required={true}
                    className={'date-input' + (inputsSet[1] ? ' warning' : '')}
                />
                <LabeledInput
                    label={'Capacity*'}
                    type={'number'}
                    value={creator?.capacity}
                    onChange={(e: ChangeEvent<HTMLInputElement>) => creator?.setCapacity(Number(e.target.value))}
                    required={true}
                    className={'capacity-input' + (inputsSet[2] ? ' warning' : '')}
                    min={1}
                    step={1}
                    max={50000}
                />
                {creator?.eventPricing === PriceOptions.Paid ? (
                <LabeledInput
                    label={'Price*'}
                    type={'number'}
                    required={true}
                    value={creator?.eventPrice}
                    onChange={(e: ChangeEvent<HTMLInputElement>) => creator?.setEventPrice(Number(e.target.value))}
                    min={0}
                    step={0.01}
                    max={1000}
                    className={'price-input'}
                />
                    ) : null }
                <SubmitButton onClick={handleSubmit}/>
            </div>
        </>
    );
}

export default ThirdStage;