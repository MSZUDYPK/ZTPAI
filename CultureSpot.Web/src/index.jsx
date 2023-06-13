import React from 'react';
import ReactDOM from 'react-dom/client';
import Root from './routers/Root';
import { RouterProvider, createBrowserRouter } from "react-router-dom";
import './index.css';
import { AuthProvider } from './context/AuthContext';

const root = ReactDOM.createRoot(
    document.getElementById("root")
);

const router = createBrowserRouter(Root);

root.render(
    <React.StrictMode>
        <AuthProvider>
                <RouterProvider router={router} />
        </ AuthProvider>
    </React.StrictMode>
);