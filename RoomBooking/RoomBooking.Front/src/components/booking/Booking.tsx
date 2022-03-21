import * as React from "react";
import { useSelector } from "react-redux";
import { RootState } from "../../app/store";
import Loading from "../shared/Loading";
import AvailableSlots from "./AvailableSlots";
import BookingEditor from "./BookingEditor";
import Bookings from "./Bookings";

const Booking: React.FC = () => {
    const isOpen = useSelector((state: RootState) => state.booking.isOpen);
    const isLoading = useSelector((state: RootState) => state.booking.isLoading);
    const displayAvailableHours = useSelector((state: RootState) => state.booking.displayAvailableHours);

    return <div>
        <Bookings />
        {isLoading && <Loading />}
        {isOpen && <BookingEditor />}
        {displayAvailableHours && <AvailableSlots />}
    </div>;
};

export default Booking;