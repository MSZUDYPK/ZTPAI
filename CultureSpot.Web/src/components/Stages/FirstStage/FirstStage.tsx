import React, {useContext, ChangeEvent, useState} from "react";
import './FirstStage.css';
import LabeledInput from "../../Inputs/LabeledInput/LabeledInput";
import SelectListInput from "../../Inputs/SelectListInput/SelectListInput";
import RadioGroup from "../../RadioGroup/RadioGroup";
import {CategoryOptions, CreatorContext, PriceOptions} from "../../../context/CreatorContext";
import {useNavigate} from "react-router-dom";
import LabeledTextArea from "../../Inputs/LabeledTextArea/LabeledTextArea";
import SubmitButton from "../../Buttons/SubmitButton/SubmitButton";

const FirstStage = () => {
    const pricingOptions = Object.values(PriceOptions);
    const [inputsSet, setInputsSet] = useState([false, false, false]);
    const creator = useContext(CreatorContext);
    const navigate = useNavigate();
    const handleSubmit = (event: React.FormEvent) => {
        const newInputsSet = [
            !creator?.eventName,
            !creator?.organiserName,
            !creator?.eventDescription
        ];
        setInputsSet(newInputsSet);

        if (!newInputsSet.includes(true)) {
            setInputsSet([true, true, true])
            navigate('/creator/2');
        }

        event.preventDefault();
    };

        return (
            <>
                <h1>Event creator</h1>
                <form className={'form-group'}>
                    <div className={'top-form-group'}>
                        <LabeledInput
                            label="Event name*"
                            className={'event-name-input' + (inputsSet[0] ? ' warning' : '')}
                            value={creator?.eventName}
                            required={true}
                            onChange={(event: ChangeEvent<HTMLInputElement>) => creator?.setEventName(event.target.value)}
                        />
                        <LabeledInput
                            label="Organiser*"
                            className={'organiser-input' + (inputsSet[1] ? ' warning' : '')}
                            value={creator?.organiserName}
                            required={true}
                            onChange={(event: ChangeEvent<HTMLInputElement>) => creator?.setOrganiserName(event.target.value)}
                        />
                    </div>
                    <div className={'bottom-form-group'}>
                        <SelectListInput
                            label={'Choose a topic'}
                            value={creator ? creator.eventCategory : CategoryOptions.Concert}
                            onChange={(value) => creator?.setEventCategory(value)}
                        />
                    </div>
                    <span>Pricing</span>
                    <RadioGroup
                        name={"Pricing"}
                        values={pricingOptions}
                        onChange={creator?.setEventPricing}
                        selectedValue={creator?.eventPricing}
                    />
                    <LabeledTextArea
                        label="Description"
                        placeholder={'Type your description...'}
                        className={'description-input' + (inputsSet[2] ? ' warning' : '')}
                        value={creator?.eventDescription}
                        required={true}
                        onChange={(event: ChangeEvent<HTMLTextAreaElement>) => creator?.setEventDescription(event.target.value)}
                        maxLength={875}
                    />
                    <SubmitButton onClick={handleSubmit}/>
                </form>
            </>
        );
}
export default FirstStage;