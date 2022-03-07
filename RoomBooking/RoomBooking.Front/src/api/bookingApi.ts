import client from ".";
import { Booking } from "../domain/Booking";

export const fetchBookings = async (): Promise<Booking[]> => {
    const response = await client.get("/Bookings");
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

export const postBooking = async (booking: Booking): Promise<number> => {
    const response = await client.post("/Bookings", {
        ...booking
    });
    return response.data;
};