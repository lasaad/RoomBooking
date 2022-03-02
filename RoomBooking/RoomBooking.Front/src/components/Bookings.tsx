import React, { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { RootState } from "../app/store";

const Bookings: React.FC = () => {
    const dispatch = useDispatch();
     
    useEffect(() => {
        dispatch({ type: "FETCH_BOOKINGS" });
    }, []);

    const bookings = useSelector((state: RootState) => state.booking.bookings);
    if (!bookings) {
        return <></>;
    }

    return <div>
       {bookings.map((r) => <div key={r.id} className="room-item">{r.roomId} : {r.startSlot} - {r.endSlot}</div>)}
    </div>
};

export default Bookings;