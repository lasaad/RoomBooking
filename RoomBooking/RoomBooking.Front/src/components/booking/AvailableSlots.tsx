import * as React from "react";
import { RootState } from "../../app/store";
import { useSelector } from "react-redux";

const AvailableSlots: React.FC = () => {
    let availableHours = useSelector((state: RootState) => state.booking.availableHours);

    if (availableHours === undefined) {
        availableHours = [];
    }

    return <>
        {availableHours.map(h => <div>{h}</div>)}
    </>;
};

export default AvailableSlots;