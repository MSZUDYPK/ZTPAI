import React from 'react';
import './ApplyButton.css';

interface ApplyButtonProps {
    onClick: () => void;
}

const ApplyButton: React.FC<ApplyButtonProps> = ({ onClick }) => {
    return (
        <button className="apply-button" onClick={onClick}>
            Apply
        </button>
    );
};

export default ApplyButton;