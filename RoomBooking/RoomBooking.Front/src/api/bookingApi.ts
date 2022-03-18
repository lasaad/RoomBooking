import client from ".";
import { Booking } from "../domain/Booking";
import { PostBookingResponse } from "./dto/PostBookingResponse";
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

export const postBooking = async (booking: Booking): Promise<PostBookingResponse> => {
    const response = await client.post("/Bookings", {
        ...booking
    });
    return response.data;
};

export const fetchBooking = async (id: number): Promise<Booking> => {
    const response = await client.get(`/Bookings/${id}`);
    let result =  {
        id: response.data.id,
        roomId: response.data.roomId,
        userId: response.data.userId,
        startSlot: response.data.startSlot,
        endSlot: response.data.endSlot,
        date: response.data.date
    };
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
    await client.put(`/Bookings`, request);
};