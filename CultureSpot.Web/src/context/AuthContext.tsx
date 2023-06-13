import React, { FC, useState, useEffect, createContext, ReactNode } from 'react';
import axios from "axios";

interface AuthContextType {
    isLoggedIn: boolean;
    saveToken: (token: string) => void;
    removeToken: () => void;
}

export const AuthContext = createContext<AuthContextType | undefined>(undefined);

interface AuthProviderProps {
    children: ReactNode;
}

export const AuthProvider: FC<AuthProviderProps> = ({ children }) => {
    const [isLoggedIn, setIsLoggedIn] = useState<boolean>(false);

    useEffect(() => {
        const storedToken = localStorage.getItem('jwtToken');
        if (storedToken) {
            setIsLoggedIn(true);
            axios.defaults.headers.common['Authorization'] = `Bearer ${storedToken}`;
        }
    }, []);

    const saveToken = (jwtToken: string) => {
        localStorage.setItem('jwtToken', jwtToken);
        setIsLoggedIn(true);
        axios.defaults.headers.common['Authorization'] = `Bearer ${jwtToken}`;
    };

    const removeToken = () => {
        localStorage.removeItem('jwtToken');
        setIsLoggedIn(false);
        delete axios.defaults.headers.common['Authorization'];
    };

    return (
        <AuthContext.Provider value={{ isLoggedIn, saveToken, removeToken }}>
            {children}
        </AuthContext.Provider>
    );
};