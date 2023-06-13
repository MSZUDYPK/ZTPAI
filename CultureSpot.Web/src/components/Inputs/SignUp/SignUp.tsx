import React from 'react';
import { useState } from 'react';
import axios from 'axios';
import './SignUp.css';
import LabeledInput from "../LabeledInput/LabeledInput";
import AuthorizationButton from "../../Buttons/AuthorizationButton/AuthorizationButton";
import OAuthButton from "../../Buttons/OAuthButton/OAuthButton";
import { faGoogle } from "@fortawesome/free-brands-svg-icons";

interface FormData {
    email: string;
    password: string;
    confirmPassword: string;
}

const SignUp = () => {
    const [formData, setFormData] = useState<FormData>({
        email: '',
        password: '',
        confirmPassword: '',
    });
    const [passwordsMatch, setPasswordsMatch] = useState(true);
    const [emailInUse, setEmailInUse] = useState(false);

    const handleSubmit = async (event: React.FormEvent) => {
        event.preventDefault();

        if (formData.password !== formData.confirmPassword) {
            setPasswordsMatch(false);
            return;
        } else {
            setPasswordsMatch(true);
        }

        const fetchData = async () => {
            try {
                const response = await axios.post('/api/users/sign-up', formData);
                const json = response.data;
                setEmailInUse(false);
            } catch (error : any) {
                if (error.response && error.response.data.code === 'email_already_in_use') {
                    setEmailInUse(true);
                }
            }
        };

        fetchData();
    };

    return (
        <div className={'sign-up-container'}>
            <h1>Sign Up</h1>
            <h2>Join our community!</h2>
            <h3 className={"email-already-in-use"}>{emailInUse ? 'Email already in use.' : ''}</h3>
            <form className={'sign-up-input-container'} onSubmit={handleSubmit}>
                <LabeledInput
                    id={'email-input'}
                    label={'Email*'}
                    type={'email'}
                    className={emailInUse ? 'info' : ''}
                    onChange={(e: React.ChangeEvent<HTMLInputElement>) =>
                        setFormData({ ...formData, email: e.target.value })
                    }
                    required={true}
                />
                <LabeledInput
                    id={'password-input'}
                    label={'Password*'}
                    type={'password'}
                    className={!passwordsMatch ? 'error' : ''}
                    onChange={(e: React.ChangeEvent<HTMLInputElement>) =>
                        setFormData({ ...formData, password: e.target.value })
                    }
                    required={true}
                />
                <LabeledInput
                    id={'confirm-password-input'}
                    label={'Confirm Password*'}
                    type={'password'}
                    className={!passwordsMatch ? 'error' : ''}
                    onChange={(e: React.ChangeEvent<HTMLInputElement>) =>
                        setFormData({ ...formData, confirmPassword: e.target.value })
                    }
                    required={true}
                />
                <AuthorizationButton text={'Sign Up'} />
                <OAuthButton icon={faGoogle} text={'Sign Up with Google'} />
            </form>
        </div>
    );
};

export default SignUp;