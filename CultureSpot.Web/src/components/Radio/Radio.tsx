import React from 'react';
import './Radio.css';

interface RadioProps {
    value: string;
    name: string;
    checked: boolean;
    onChange: (value: string) => void;
}

const Radio: React.FC<RadioProps> = ({ value, name, checked, onChange }) => {
    return (
        <label className="radio-label">
            <input
                type="radio"
                name={name}
                value={value}
                checked={checked}
                onChange={() => onChange(value)}
                className="radio-input"
            />
            {value}
        </label>
    );
};
export default Radio;