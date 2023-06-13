import React, {useEffect, useState} from 'react';
import './EventDetails.css';
import Header from "../Header/Header";
import axios from "axios";
import {useParams} from "react-router-dom";
import {CategoryOptions, Schedule} from "../../context/CreatorContext";
import {Image} from "react-bootstrap";
import EventPlan from "../EventPlan/EventPlan";

interface EventDetails {
    organizer: string;
    description: string;
    type: CategoryOptions;
    price: number;
    capacity: number;
    name: string;
    date: string;
    imageUrl: string;
    location: string;
    schedule: Schedule[];
    id: string;
}

const EventDetails: React.FC = () => {
    const [event, setEvent] = useState<EventDetails>();
    const { eventId } = useParams<{ eventId: string }>();
    const [schedule, setSchedule] = useState<Schedule[]>([
        { name: '', starting: '', ending: '', description: '', date: '' },
        { name: '', starting: '', ending: '', description: '', date: '' },
        { name: '', starting: '', ending: '', description: '', date: '' },
        { name: '', starting: '', ending: '', description: '', date: '' },
        { name: '', starting: '', ending: '', description: '', date: '' },
        { name: '', starting: '', ending: '', description: '', date: '' },
        { name: '', starting: '', ending: '', description: '', date: '' },
    ]);

    useEffect(() => {
        const fetchEvent = async () => {
            try {
                const response = await axios.get<EventDetails>(`/api/events/${eventId}`);
                setEvent(response.data);
                setSchedule(response.data.schedule);
            } catch (error) {
                console.error('Error fetching events:', error);
            }
        };
        fetchEvent();
    }, [eventId]);

    const handleScheduleChange = () => {
       console.log(schedule);
    };

    return (
        <div className="event-page">
            <Header />
            <div className={'event-page-content'}>
                <div className={'event-page-info'}>
                    <section className={'left-content'}>
                        <Image src={'/' + event?.imageUrl} className={'event-page-image'} />
                    </section>
                    <section className={'right-content'}>
                        <h1>{event?.name}</h1>
                        <p>{event?.description}</p>
                        <h3>{"Details "}</h3>
                        <table className={'details-table'}>
                            <tbody>
                            <tr>
                                <th>{"Organizer: "}</th>
                                <td>{event?.organizer}</td>
                            </tr>
                            <tr>
                                <th>{"Location: "}</th>
                                <td>{event?.location}</td>
                            </tr>
                            <tr>
                                <th>{"Date: "}</th>
                                <td>{event?.date}</td>
                            </tr>
                            <tr>
                                <th>{"Price: "}</th>
                                <td>{event?.price}</td>
                            </tr>
                            <tr>
                                <th>{"Capacity: "}</th>
                                <td>{event?.capacity}</td>
                            </tr>
                            <tr>
                                <th>{"Type: "}</th>
                                <td>{event?.type}</td>
                            </tr>
                            </tbody>
                        </table>
                    </section>
                </div>
                <div className={'event-page-schedule'}>
                    <EventPlan schedule={schedule} setSchedule={handleScheduleChange} />
                </div>
            </div>
        </div>
    );
}

export default EventDetails;