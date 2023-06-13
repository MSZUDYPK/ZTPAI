import React, {createContext, FC, ReactNode, useContext, useEffect, useState} from "react";
import axios from "axios";

export enum PriceOptions {
    Free = 'Free',
    Paid = 'Paid',
    Other = 'Other'
}

export enum CategoryOptions {
    Concert = 0,
    Exhibition = 1,
    Workshop = 3,
    Conference = 4,
    Theater = 5,
    Movie = 6,
    Festival = 7,
    Sport = 8,
    Food = 9,
    Other = 10
}

export interface Schedule {
    name: string;
    starting: string;
    ending: string;
    description: string;
    date: string;
}

export const scheduleFieldTypes = {
    name: 'text',
    starting: 'time',
    ending: 'time',
    description: 'text',
    date: 'date',
};

interface CreatorContextType {
    eventName: string;
    setEventName: (value: string) => void;
    eventDescription: string;
    setEventDescription: (value: string) => void;
    eventLocation: string;
    setEventLocation: (value: string) => void;
    eventDate: string;
    setEventDate: (date: string) => void;
    eventPricing: PriceOptions;
    setEventPricing: (value: PriceOptions) => void;
    eventPrice: number;
    setEventPrice: (value: number) => void;
    capacity: number;
    setCapacity: (value: number) => void;
    eventImage: File | null;
    setEventImage: (value: File | null) => void;
    eventCategory: CategoryOptions
    setEventCategory: (value: CategoryOptions) => void;
    organiserName: string;
    setOrganiserName: (value: string) => void;
    createEvent: () => void;
    schedule: Schedule[];
    setSchedule: (value: Schedule[]) => void;
    uploadImage: (file: File) => void;
}

export const CreatorContext = createContext<CreatorContextType | undefined>(undefined);

interface CreatorProviderProps {
    children: ReactNode;
}

export const CreatorProvider: FC<CreatorProviderProps> = ({ children }) => {
    const [eventName, setEventName] = useState<string>('');
    const [eventDescription, setEventDescription] = useState<string>('');
    const [eventLocation, setEventLocation] = useState<string>('');
    const [eventDate, setEventDate] = useState<string>("");
    const [eventPricing, setEventPricing] = useState<PriceOptions>(PriceOptions.Free);
    const [eventPrice, setEventPrice] = useState<number>(0);
    const [capacity, setCapacity] = useState<number>(0);
    const [eventImage, setEventImage] = useState<File | null>(null);
    const [eventCategory, setEventCategory] = useState<CategoryOptions>(CategoryOptions.Other);
    const [organiserName, setOrganiserName] = useState<string>('');
    const [schedule, setSchedule] = useState<Schedule[]>([
        { name: '', starting: '', ending: '', description: '', date: '' },
        { name: '', starting: '', ending: '', description: '', date: '' },
        { name: '', starting: '', ending: '', description: '', date: '' },
        { name: '', starting: '', ending: '', description: '', date: '' },
        { name: '', starting: '', ending: '', description: '', date: '' },
        { name: '', starting: '', ending: '', description: '', date: '' },
        { name: '', starting: '', ending: '', description: '', date: '' },
    ]);
    const [eventId, setEventId] = useState<string>('');

    const createEvent = async () => {
        const scheduleWithoutEmptyFields = schedule.filter(s => s.name !== '' && s.starting !== '' && s.ending !== '' && s.description !== '' && s.date !== '');
        try {
            const response = await axios.post(`/api/events`, {
                name: eventName,
                organizerName: organiserName,
                description: eventDescription,
                type: eventCategory,
                schedule: scheduleWithoutEmptyFields,
                address: eventLocation,
                price: eventPrice,
                capacity: capacity,
                date: eventDate,
            });
            setEventId(response.data);
        } catch (error) {
            console.log(error);
        }
    };

    const uploadImage = async () => {
        if (!eventImage) {
            return;
        }
        const formData = new FormData();
        formData.append('eventId', eventId);
        formData.append('file', eventImage);

        try {
            const response = await axios.put(`/api/events/${eventId}`, formData, {
                headers: {
                    'Content-Type': 'multipart/form-data'
                }
            });

            console.log(response.data);
        } catch (error) {
            console.error("Error uploading file", error);
        }
    }

    return (
        <CreatorContext.Provider value={{eventName, setEventName, eventDescription, setEventDescription, eventLocation, setEventLocation, eventDate, setEventDate, eventPrice, setEventPrice, eventPricing, setEventPricing, capacity, setCapacity, eventImage, setEventImage, eventCategory, setEventCategory, organiserName, setOrganiserName, schedule, setSchedule , createEvent, uploadImage}}>
            {children}
        </CreatorContext.Provider>
    );
};