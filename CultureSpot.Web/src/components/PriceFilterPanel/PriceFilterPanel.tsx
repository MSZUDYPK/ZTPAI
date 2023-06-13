import React from "react";
import './PriceFilterPanel.css';

const PriceFilterPanel = (props: any) => {
    return (
        <>
            <h4>Price Range</h4>
            <div className={'price-input-wrapper'}>
                <div className={'price-field'}>
                    <input type={'number'} className={'price-min'} placeholder={'0'}/>
                </div>
                <hr className="separator"/>
                <div className={'price-field'}>
                    <input type={'number'} className={'price-max'} placeholder={'1000'}/>
                </div>
            </div>
        </>
    );
}

export default PriceFilterPanel;