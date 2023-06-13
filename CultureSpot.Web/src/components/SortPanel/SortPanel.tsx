import React from "react";
import './SortPanel.css';
import { usePanelContext, SortOptions } from '../../context/PanelContext';
import RadioGroup from "../RadioGroup/RadioGroup";

const SortPanel: React.FC = () => {
    const { sortValue, setSortValue } = usePanelContext();

    const sortOptions = Object.values(SortOptions);

    const handleOnChange = (value: string) => {
        if (Object.values(SortOptions).includes(value as SortOptions)) {
            setSortValue(value as SortOptions);
        }
    };

    return (
        <div className="sort-panel">
            <h2>Sort by:</h2>
            <RadioGroup
                name="sort"
                values={sortOptions}
                selectedValue={sortValue}
                onChange={handleOnChange}
                orientation="vertical"
            />
            <hr />
        </div>
    );
};

export default SortPanel;