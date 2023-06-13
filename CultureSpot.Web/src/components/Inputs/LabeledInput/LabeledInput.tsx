import React from "react";
import './LabeledInput.css';

interface LabeledInputProps {
    id?: string;
    label?: string;
    type?: string;
    value?: string | number
    placeholder?: string;
    className?: string;
    required?: boolean;
    onChange?: (event: React.ChangeEvent<HTMLInputElement>) => void;
    min?: number;
    max?: number;
    step?: number;
}

const LabeledInput = (props: LabeledInputProps) => {

    return (
        <div className={`labeled-input ${props.className}`}>
            {props.label && <label htmlFor={props.id}>{props.label}</label>}
            <input
                id={props.id}
                type={props.type}
                value={props.value}
                placeholder={props.placeholder}
                onChange={props.onChange}
                autoComplete={"on"}
                min={props.min}
                max={props.max}
                step={props.step}
                aria-label={props.label || props.placeholder}
                required={props.required || false}
            />
        </div>
    );
};

export default LabeledInput;