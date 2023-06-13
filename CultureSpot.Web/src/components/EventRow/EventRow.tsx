import React from 'react';
import "./EventRow.css";
import Row from 'react-bootstrap/Row';
import EventCard from '../EventCard/EventCard';

interface Event {
    id: string;
    name: string;
    date: string;
    imageUrl: string;
    location: string;
}

interface EventRowProps {
    events: Event[];
}

export const EventRow: React.FC<EventRowProps> = ({ events }) => {
    return (
        <Row className="event-row">
            {events.map((event) => (
                <EventCard
                    key={event.id}
                    id={event.id}
                    name={event.name}
                    date={event.date}
                    image={event.imageUrl}
                    location={event.location}
                />
            ))}
        </Row>
    );
};

export default EventRow;