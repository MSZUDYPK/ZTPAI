import React from "react";
import "./SelectListInput.css";
import {CategoryOptions} from "../../../context/CreatorContext";

interface SelectListInputProps {
    label?: string;
    placeholder?: string;
    className?: string;
    value: CategoryOptions;
    onChange: (value: CategoryOptions) => void;
}

const SelectListInput: React.FC<SelectListInputProps> = ({ label, placeholder, value, className, onChange }) => {
    const enumKeys = Object.keys(CategoryOptions).filter(key => isNaN(Number(key)));

    const handleChange = (event: React.ChangeEvent<HTMLSelectElement>) => {
        onChange(CategoryOptions[event.target.value as keyof typeof CategoryOptions]);
    };

    return (
        <div className={`select-list-input ${className}`}>
            {label && <label>{label}</label>}
            <select required onChange={handleChange} value={CategoryOptions[value]}>
                <option disabled value="">{placeholder}</option>
                {enumKeys.map((key) => (
                    <option key={key} value={key}>{key}</option>
                ))}
            </select>
        </div>
    );
};

export default SelectListInput;