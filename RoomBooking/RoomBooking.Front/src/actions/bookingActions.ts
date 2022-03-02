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

export type BookingAction =
    FetchBookings
    | FetchBookingsSuccess
    | FetchBookingsFail;