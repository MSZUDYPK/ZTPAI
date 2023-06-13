import React, { useState } from 'react';
import './EditableRow.css';
import {Schedule} from "../../context/CreatorContext";

interface EditableRowProps {
    scheduleRow: Schedule;
    fieldTypes: { [key in keyof Schedule]: string };
    onEdit: (schedule: Schedule) => void;
}

const EditableRow: React.FC<EditableRowProps> = ({ scheduleRow, fieldTypes, onEdit}) => {
    const [isEditing, setIsEditing] = useState(false);
    const [editedSchedule, setEditedSchedule] = useState(scheduleRow);

    const handleEdit = () => {
        setIsEditing(true);
    };

    const handleSave = () => {
        setIsEditing(false);
        onEdit(editedSchedule);
    };

    const handleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        const { name, value } = event.target;
        setEditedSchedule({ ...editedSchedule, [name]: value });
    };

    return (
        <tr className={'editable-row'}>
            {Object.keys(scheduleRow).map((key) => (
                <td key={key}>
                    {isEditing ? (
                        <input
                            type={fieldTypes[key as keyof Schedule]}
                            name={key}
                            value={editedSchedule[key as keyof Schedule]}
                            onChange={handleChange}
                        />
                    ) : (
                        scheduleRow[key as keyof Schedule]
                    )}
                </td>
            ))}
            <td>
                {isEditing ? (
                    <button className={'row-action-btn'} onClick={handleSave}>Save</button>
                ) : (
                    <button className={'row-action-btn'} onClick={handleEdit}>Edit</button>
                )}
            </td>
        </tr>
    );
};

export default EditableRow;