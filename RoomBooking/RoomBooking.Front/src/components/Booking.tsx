import * as React from "react";
import { useDispatch } from "react-redux";

interface BookingProps {
}

const Booking: React.FC<BookingProps> = () => {
    const dispatch = useDispatch();
    const [date, setDate] = React.useState("");
    const [startSlot, setstartSlot] = React.useState("");
    const [endSlot, setendSlot] = React.useState("");
    const [roomId, setRoomId] = React.useState("");
    const [userId, setUserId] = React.useState("");

    return <>
        <div>
            Date
        </div>
        <div>
            <input type="date" value={date} onChange={(e) => setDate(e.target.value)} />
        </div>        <div>
            Start Hour
        </div>
        <div>
            <input type="number" value={startSlot} onChange={(e) => setstartSlot(e.target.value)} />
        </div>        <div>
            End Hour
        </div>
        <div>
            <input type="number" value={endSlot} onChange={(e) => setendSlot(e.target.value)} />
        </div>
        <div>
            Room
        </div>
        <div>
            <input type="text" value={roomId} onChange={(e) => setRoomId(e.target.value)} />
        </div>
        <div>
            User
        </div>
        <div>
            <input type="text" value={userId} onChange={(e) => setUserId(e.target.value)} />
        </div>
        <div>
            <button onClick={() => dispatch({ type: "CREATE_BOOKING", payload: { date, startSlot, endSlot, roomId, userId} })}>Save</button>
        </div>
    </>;
};

export default Booking;