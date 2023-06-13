import React, { useState } from 'react';
import './Panel.css';
import { SortOptions, PanelContext } from '../../context/PanelContext';
import SortPanel from "../SortPanel/SortPanel";
import PriceFilterPanel from "../PriceFilterPanel/PriceFilterPanel";
import ApplyButton from "../Buttons/ApplyButton/ApplyButton";

interface PanelProps {
    results: number;
    onApply: (values: { sortValue: SortOptions; priceValue: number; startDate: Date | null; endDate: Date | null; }) => void;
}

const Panel: React.FC<PanelProps> = ({ results, onApply }) => {
    const [sortValue, setSortValue] = useState(SortOptions.Relevance);
    const [priceValue, setPriceValue] = useState(0);
    const [startDate, setStartDate] = useState<Date | null>(null);
    const [endDate, setEndDate] = useState<Date | null>(null);

    const handleApply = () => {
        onApply({ sortValue, priceValue, startDate, endDate });
    };

    return (
        <PanelContext.Provider value={{ sortValue, priceValue, startDate, endDate, setSortValue, setPriceValue, setStartDate, setEndDate }}>
            <div className="panel">
                <h2>{results} Results</h2>
                <div className="panel-body">
                    <SortPanel />
                    {/*<PriceFilterPanel />*/}
                </div>
                <div className="panel-btn">
                    <ApplyButton onClick={handleApply} />
                </div>
            </div>
        </PanelContext.Provider>
    );
};

export default Panel;