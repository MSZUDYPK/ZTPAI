import React, { useState, useContext } from "react";
import { useNavigate } from 'react-router-dom';
import axios from 'axios';
import './LogIn.css';
import LabeledInput from "../LabeledInput/LabeledInput";
import AuthorizationButton from "../../Buttons/AuthorizationButton/AuthorizationButton";
import OAuthButton from "../../Buttons/OAuthButton/OAuthButton";
import { faGoogle } from "@fortawesome/free-brands-svg-icons";
import {AuthContext} from "../../../context/AuthContext";

interface FormData {
    email: string;
    password: string;
}

const LogIn = () => {
    const [formData, setFormData] = useState<FormData>({
        email: '',
        password: ''
    });
    const [invalidCredentials, setInvalidCredentials] = useState(false);
    const navigate = useNavigate();

    const authContext = useContext(AuthContext);

    if (!authContext) {
        throw new Error('AuthContext is undefined, please ensure it is provided via AuthProvider');
    }

    const { saveToken } = authContext;

    const handleSubmit = async (event: React.FormEvent) => {
        event.preventDefault();

        const fetchData = async () => {
            try {
                const response = await axios.post('/api/users/sign-in', formData);

                if (response.status === 200) {
                    const token = response.data.accessToken;
                    saveToken(token);
                    navigate('/events');
                    setInvalidCredentials(false);
                }
            } catch (error : any) {
                if (error.response && error.response.data.code === 'invalid_credentials') {
                    setInvalidCredentials(true);
                }
            }
        };

        fetchData();
    };

    return (
        <div className={'login-container'}>
            <h1>Log In</h1>
            <h2>Access your CultureSpot account.</h2>
            <h3 className={'login-error'}>{invalidCredentials ? 'Invalid email or password.' : ''}</h3>
            <form className={'login-input-container'} onSubmit={handleSubmit}>
                <LabeledInput
                    id={'email-input'}
                    label={'Email*'}
                    type={'email'}
                    className={invalidCredentials ? 'error' : ''}
                    onChange={(e: React.ChangeEvent<HTMLInputElement>) =>
                        setFormData({ ...formData, email: e.target.value })
                    }
                    required={true}
                />
                <LabeledInput
                    id={'password-input'}
                    label={'Password*'}
                    type={'password'}
                    className={invalidCredentials ? 'error' : ''}
                    onChange={(e: React.ChangeEvent<HTMLInputElement>) =>
                        setFormData({ ...formData, password: e.target.value })
                    }
                    required={true}
                />
                <AuthorizationButton text={'Log In'} />
                <OAuthButton icon={faGoogle} text={'Log In with Google'} />
            </form>
            <h3 className={'login-forgot-password'}>Forgot your password?</h3>
        </div>
    );
};

export default LogIn;