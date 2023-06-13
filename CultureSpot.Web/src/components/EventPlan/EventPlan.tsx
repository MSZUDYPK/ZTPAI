import React, {FC, useContext} from "react";
import './EventPlan.css';
import {CreatorContext, Schedule, scheduleFieldTypes} from "../../context/CreatorContext";
import EditableRow from "../EditableRow/EditableRow";

interface EventPlanProps {
    schedule: Schedule[];
    setSchedule: (value: Schedule[]) => void;
}

const EventPlan : FC<EventPlanProps> = ({schedule, setSchedule}) => {
    const creator = useContext(CreatorContext);
    const onEdit = (index: number, updatedSchedule: Schedule) => {
        const newSchedule = [...schedule];
        newSchedule[index] = updatedSchedule;

        if (index === newSchedule.length - 1 && Object.values(updatedSchedule).some(value => value.trim() !== '')) {
            newSchedule.push({ name: '', starting: '', ending: '', description: '', date: '' });
        }

        if (index !== newSchedule.length - 1 && Object.values(updatedSchedule).every(value => value.trim() === '')) {
            newSchedule.splice(index, 1);
        }

        setSchedule(newSchedule);
        console.log(newSchedule);
    };

    return (
        <table className={'editable-table'}>
            <thead>
            <tr>
                <th>Name</th>
                <th>Starting</th>
                <th>Ending</th>
                <th>Description</th>
                <th>Date</th>
                <th>Actions</th>
            </tr>
            </thead>
            <tbody>
            {schedule.map((scheduleRow, index) => (
                <EditableRow
                    key={index}
                    scheduleRow={scheduleRow}
                    fieldTypes={scheduleFieldTypes}
                    onEdit={(editedScheduleRow) => onEdit(index, editedScheduleRow)}
                />
            ))}
            </tbody>
        </table>
    );
}

export default EventPlan;