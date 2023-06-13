import React from 'react';
import "./EventCard.css";
import Card from 'react-bootstrap/Card';
import Button from 'react-bootstrap/Button';
import Col from 'react-bootstrap/Col';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faTicket, faStar } from '@fortawesome/free-solid-svg-icons';
import {Link} from "react-router-dom";

export interface EventCardProps {
    id: string;
    name: string;
    date: string;
    image: string;
    location: string;
}

export const EventCard: React.FC<EventCardProps> = ({ id, name, date, image, location }) => {
    return (
        <Col xs={12} sm={6} md={4} lg={3}>
            <Link className={'event-link'} to={`/events/${id}`}>
                <Card className="event-card">
                    <Card.Img variant="top" src={image} className="event-card-img" />
                    <Card.Body className="event-card-info">
                        <div className="event-card-info-group">
                            <Card.Title className="event-card-name">{name}</Card.Title>
                            <Card.Text className="event-card-date-location">{date}, {location}</Card.Text>
                        </div>
                        <div className="event-card-button-group">
                            <Button className="event-card-button">
                                <FontAwesomeIcon icon={faTicket} className="event-card-ticket-icon" />
                            </Button>
                            <Button className="event-card-button">
                                <FontAwesomeIcon icon={faStar} className="event-card-star-icon" />
                            </Button>
                        </div>
                    </Card.Body>
                </Card>
            </Link>
        </Col>
    );
}

export default EventCard;