import React, { createContext, useContext, useState } from 'react';

export enum SortOptions {
    Relevance = 'Relevance',
    MostPopular = 'Most Popular',
    Newest = 'Newest',
    Rating = 'Rating'
}

export const PanelContext = createContext({
    sortValue: SortOptions.Relevance,
    priceValue: 0,
    startDate: null as Date | null,
    endDate: null as Date | null,
    setSortValue: (value: SortOptions) => {},
    setPriceValue: (value: number) => {},
    setStartDate: (date: Date) => {},
    setEndDate: (date: Date) => {},
});

export const usePanelContext = () => useContext(PanelContext);