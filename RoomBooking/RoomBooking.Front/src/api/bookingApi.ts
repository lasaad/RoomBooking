import { setDefaultResultOrder } from "dns/promises";
import client from ".";
import { Booking } from "../domain/Booking";
import { UpdateBookingRequest } from "./dto/UpdateBookingRequest";

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

export const fetchBooking = async (id: number): Promise<Booking> => {
    const response = await client.get(`/Bookings/${id}`);
    let result =  response.data.bookings.map((r: Booking) => ({
        id: r.id,
        roomId: r.roomId,
        userId: r.userId,
        startSlot: r.startSlot,
        endSlot: r.endSlot,
        date: r.date
    }));
    return result;
};

export const putBooking = async (booking: Booking): Promise<void> => {
    const request: UpdateBookingRequest = {
        id: booking.id,
        roomId: booking.roomId,
        userId: booking.userId,
        startSlot: booking.startSlot,
        endSlot: booking.endSlot,
        date: booking.date
    };
    await client.put(`/Users`, request);
};