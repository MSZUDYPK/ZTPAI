import React from 'react';
import './App.css';
import FrontPage from "./pages/frontPage/FrontPage";
import { AuthProvider } from './context/AuthContext';

interface AppProps {
    message: string;
}

const App: React.FC<AppProps> = ({ message }) => {
    return (
        <AuthProvider>
            <FrontPage />
        </AuthProvider>
    );
};

export default App;