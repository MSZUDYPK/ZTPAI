import React from "react";
import axios from 'axios';
import { useEffect, useState } from 'react';
import "./Main.css";
import 'bootstrap/dist/css/bootstrap.min.css';
import Header from "../../components/Header/Header";
import Panel from "../../components/Panel/Panel";
import EventRow from "../../components/EventRow/EventRow";
interface Event {
    name: string;
    date: string;
    imageUrl: string;
    location: string;
    id: string;
}

const Main: React.FC = () => {
    const [events, setEvents] = useState<Event[]>([]);

    useEffect(() => {
        const fetchEvents = async () => {
            try {
                const response = await axios.get<Event[]>('api/events');
                setEvents(response.data);
            } catch (error) {
                console.error('Error fetching events:', error);
            }
        };
        fetchEvents();
    }, []);

    const handleApply = () => {
        const fetchMe = async () => {
            try {
                const response = await axios.get('api/users/me');
                console.log(response.data);
            } catch (error) {
                console.error('Error fetching me:', error);
            }
        };
        fetchMe();
    };

    return (
        <div className="main-page">
            <Header />
            <div className="main-page-content">
                <Panel onApply={handleApply} results={events.length}/>
                <div className="main-page-events">
                    <EventRow events={events} />
                </div>
            </div>
        </div>
    );
}

export default Main;
