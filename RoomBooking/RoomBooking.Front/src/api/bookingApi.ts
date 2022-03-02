import client from ".";
import { Booking } from "../domain/Booking";

export const fetchBookings = async (): Promise<Booking[]> => {
    const response = await client.get("/Bookings");
    console.log(response)
    let a =  response.data.bookings.map((r: Booking) => ({
        id: r.id,
        roomId: r.roomId,
        userId: r.userId,
        startSlot: r.startSlot,
        endSlot: r.endSlot,
        date: r.date
    }));
    return a;
};