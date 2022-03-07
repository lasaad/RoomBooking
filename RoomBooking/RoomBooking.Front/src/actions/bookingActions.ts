import { Booking } from "../domain/Booking";

type FetchBookings = {
    type: "FETCH_BOOKINGS";
};

type FetchBookingsSuccess = {
    type: "FETCH_BOOKINGS_SUCCESS";
    payload: Booking[];
};

type FetchBookingsFail = {
    type: "FETCH_BOOKINGS_FAIL";
};

export const fetchBookings = (): FetchBookings => ({
    type: "FETCH_BOOKINGS"
});

export type CreateBooking = {
    type: "CREATE_BOOKING";
    payload: Booking;
};

type CreateBookingSuccess = {
    type: "CREATE_BOOKING_SUCCESS";
    payload: number;
};

type CreateBookingFail = {
    type: "CREATE_BOOKING_FAIL";
};

export type BookingAction =
    FetchBookings
    | FetchBookingsSuccess
    | FetchBookingsFail
    | CreateBooking
    | CreateBookingSuccess
    | CreateBookingFail;