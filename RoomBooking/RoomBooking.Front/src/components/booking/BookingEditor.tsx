import React, { useEffect } from "react";
import _ from "lodash";
import { useDispatch, useSelector } from "react-redux";
import { RootState } from "../../app/store";

const BookingEditor: React.FC = () => {
    const dispatch = useDispatch();
    const currentBooking = useSelector((state: RootState) => state.booking.currentBooking);

    const currentBookingId = _.isNil(currentBooking) ? 0 : currentBooking.id;
    const currentBookingDate = _.isNil(currentBooking) ? "" : currentBooking.date;
    const currentBookingStartSlot = _.isNil(currentBooking) ? "" : currentBooking.startSlot;
    const currentBookingEndSlot = _.isNil(currentBooking) ? "" : currentBooking.endSlot;
    const currentBookingRoomId = _.isNil(currentBooking) ? "" : currentBooking.roomId;
    const currentBookingUserId = _.isNil(currentBooking) ? "" : currentBooking.userId;

    const [id, setId] = React.useState(currentBookingId);
    const [date, setDate] = React.useState(currentBookingDate);
    const [startSlot, setStartSlot] = React.useState(currentBookingStartSlot);
    const [endSlot, setEndSlot] = React.useState(currentBookingEndSlot);
    const [roomId, setRoomId] = React.useState(currentBookingRoomId);
    const [userId, setUserId] = React.useState(currentBookingUserId);

    useEffect(() => {
        setId(currentBookingId);
        setDate(currentBookingDate);
        setStartSlot(currentBookingStartSlot);
        setEndSlot(currentBookingEndSlot);
        setRoomId(currentBookingRoomId);
        setUserId(currentBookingUserId);
    }, [currentBooking]);

    const saveBooking = () => {
        if (id === 0) {
            dispatch({ type: "CREATE_BOOKING", payload: { id, date, startSlot, endSlot, roomId, userId } });
        } else {
            dispatch({ type: "UPDATE_BOOKING", payload: { id, date, startSlot, endSlot, roomId, userId } });
        }
    };

    const bookingStyle = {
        height: "100px",
        width: "800px",
        margin: "5px auto",
        border: "solid 1px"
    };

    return <div style={bookingStyle}>
        <div>
            <label htmlFor={date}>Date</label>
            <input type="text" value={date} onChange={(e) => setDate(e.target.value)} />
        </div>
        <div>
            <label>Begin</label>
            <input type="number" value={startSlot} onChange={(e) => setStartSlot(e.target.value)} />
        </div>
        <div>
            <label>End</label>
            <input type="number" value={endSlot} onChange={(e) => setEndSlot(e.target.value)} />
        </div>
        <div>
            <label>Room Id</label>
            <input type="number" value={roomId} onChange={(e) => setRoomId(e.target.value)} />
        </div>
        <div>
            <label>UserId</label>
            <input type="text" value={userId} onChange={(e) => setUserId(e.target.value)} />
        </div>
        <div>
            <button onClick={saveBooking}>Save</button>
        </div>
    </div>;
};

export default BookingEditor;