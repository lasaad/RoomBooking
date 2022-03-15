import React, { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { RootState } from "../../app/store";

const Bookings: React.FC = () => {
    const dispatch = useDispatch();
     
    useEffect(() => {
        dispatch({ type: "FETCH_BOOKINGS" });
    }, []);

    const bookings = useSelector((state: RootState) => state.booking.bookings); // lis dans le store

    if (!bookings) {
        return <></>;
    }

    const bookingStyle = {
        height: "300px",
        width: "800px",
        margin: "5px auto",
        border: "solid 1px"
    };

    return <div style={bookingStyle}>
        {bookings.map((r) =>
            <div key={r.id} className="booking-item">
                <button onClick={() => dispatch({ type: "FETCH_BOOKING", payload: r.id })}>{r.id}</button> - {r.userId}
            </div>)
        }
        <div>
            <button onClick={() => dispatch({ type: "OPEN_BOOKING_EDITOR" })}>New booking</button>
        </div>
    </div>
};

export default Bookings;