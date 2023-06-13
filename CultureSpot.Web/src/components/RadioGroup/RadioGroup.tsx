import React, { useState } from 'react';
import './RadioGroup.css';
import Radio from "../Radio/Radio";

interface RadioGroupProps<T extends string | number | symbol>  {
    name: string;
    values: T[];
    selectedValue?: T;
    onChange?: (value: T) => void;
    orientation?: 'horizontal' | 'vertical';
}

const RadioGroup: React.FC<RadioGroupProps<any>> = ({ name, values, selectedValue, onChange, orientation = 'vertical' }) => {
    const handleChange = (value: string) => {
        if (onChange) {
            onChange(value);
        }
    };

    const groupClass = orientation === 'horizontal' ? 'radio-group-horizontal' : 'radio-group-vertical';

    return (
        <div className={`radio-group ${groupClass}`}>
            {values.map(value => (
                <Radio
                    key={value}
                    value={value}
                    name={name}
                    checked={value === selectedValue}
                    onChange={handleChange}
                />
            ))}
        </div>
    );
};
export default RadioGroup;
