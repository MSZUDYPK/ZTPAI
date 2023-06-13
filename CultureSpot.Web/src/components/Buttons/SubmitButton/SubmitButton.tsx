import React from 'react';
import './SubmitButton.css';

interface SubmitButtonProps {
    onClick: (event: React.FormEvent<HTMLButtonElement>) => void;
}

const SubmitButton: React.FC<SubmitButtonProps> = ({ onClick }) => {
    return (
        <button type={'submit'} className="submit-button" onClick={onClick}>
            Submit
        </button>
    );
};

export default SubmitButton;