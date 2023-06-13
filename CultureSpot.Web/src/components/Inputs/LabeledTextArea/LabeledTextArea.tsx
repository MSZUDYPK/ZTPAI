import React from "react";
import './LabeledTextArea.css';

interface LabeledTextAreaProps {
    id?: string;
    placeholder: string;
    label?: string;
    value?: string;
    className?: string;
    onChange?: (event: React.ChangeEvent<HTMLTextAreaElement>) => void;
    required?: boolean;
    maxLength?: number;
}

const LabeledTextArea : React.FC<LabeledTextAreaProps> = ({ id, label, value, className, placeholder,onChange, maxLength, required}) => {

    return (
        <div className={`labeled-textarea ${className}`}>
            {label && <label htmlFor={id}>{label}</label>}
            <textarea
                id={id}
                placeholder={placeholder}
                required={required || false}
                maxLength={maxLength}
                value={value}
                onChange={onChange}
                aria-label={label || placeholder}
            />
        </div>
    );
};

export default LabeledTextArea;