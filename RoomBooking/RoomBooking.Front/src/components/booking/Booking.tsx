import * as React from "react";
import { useSelector } from "react-redux";
import { RootState } from "../../app/store";
import Loading from "../shared/Loading";
import BookingEditor from "./BookingEditor";
import Bookings from "./Bookings";

const Booking: React.FC = () => {
    const isOpen = useSelector((state: RootState) => state.room.isOpen);
    const isLoading = useSelector((state: RootState) => state.room.isLoading);

    return <div>
        <Bookings />
        {isLoading && <Loading />}
        {isOpen && <BookingEditor />}
    </div>;
};

export default Booking;