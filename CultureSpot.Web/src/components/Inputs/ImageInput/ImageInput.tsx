import React from "react";
import './ImageInput.css';

interface ImageInputProps {
    name: string;
    label: string;
    onChange: (event: React.ChangeEvent<HTMLInputElement>) => void;
    maxFileSize?: number;
    error?: string;
}

const ImageInput: React.FC<ImageInputProps> = ({ name, label, onChange, maxFileSize, error }) => {
    const handleFileChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        const file = event.target.files?.[0];
        if (file && maxFileSize && file.size > maxFileSize) {
            console.log('File too large');
        } else {
            onChange(event);
        }
    };

    return (
        <form className="image-form-group">
            <label htmlFor={name} className={'image-input-btn'}>{label}</label>
            <input
                type="file"
                name={name}
                accept="image/*"
                id={name}
                onChange={handleFileChange}
                />
            {error && <div className="alert">{error}</div>}
        </form>
    );
}

export default ImageInput;