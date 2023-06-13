import React, {useContext, useState} from "react";
import './FourthStage.css';
import { CreatorContext } from "../../../context/CreatorContext";
import ImageInput from "../../Inputs/ImageInput/ImageInput";
import Poster from "../../Poster/Poster";
import SubmitButton from "../../Buttons/SubmitButton/SubmitButton";
import defaultPoster from "../../../assets/default-poster.jpg";
import axios from "axios";

const FourthStage = () => {
    const creator = useContext(CreatorContext);
    const [selectedImage, setSelectedImage] = useState<string | null>(null);

    const handleOnChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        const file = event.target.files?.[0];
        if (file) {
            const reader = new FileReader();
            reader.onloadend = () => {
                setSelectedImage(reader.result as string);
            };
            reader.readAsDataURL(file);

            creator?.setEventImage(file);
        }
    }

    const handleSubmit = async () => {
        creator?.uploadImage(creator.eventImage!);
    }

    return (
        <div className={'event-preview'}>
            <div className={'image-upload-container'}>
                <div className={'image-preview'}>
                    <Poster imgSrc={selectedImage || defaultPoster} />
                </div>
                <div className={'upload-btn-group'}>
                    <ImageInput name={'image-upload'} label={'Choose a file'} onChange={handleOnChange} />
                    <SubmitButton onClick={handleSubmit} />
                </div>
            </div>
        </div>
    );
}
export default FourthStage;