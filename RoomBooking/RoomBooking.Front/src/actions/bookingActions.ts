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

export type FetchBooking = {
    type: "FETCH_BOOKING";
    payload: number
};

type FetchBookingSuccess = {
    type: "FETCH_BOOKING_SUCCESS";
    payload: Booking;
};

type FetchBookingFail = {
    type: "FETCH_BOOKING_FAIL";
};

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

type UnavailableSlotBooking = {
    type: "UNAVAILABLE_SLOT";
};

type OpenBookingEditor = {
    type: "OPEN_BOOKING_EDITOR";
};

export type UpdateBooking = {
    type: "UPDATE_BOOKING";
    payload: Booking;
};

type UpdateBookingSuccess = {
    type: "UPDATE_BOOKING_SUCCESS";
    payload: number;
};

type UpdateBookingFail = {
    type: "UPDATE_BOOKING_FAIL";
};

export type BookingAction =
    FetchBookings
    | FetchBookingsSuccess
    | FetchBookingsFail
    | FetchBooking
    | FetchBookingSuccess
    | FetchBookingFail
    | OpenBookingEditor
    | CreateBooking
    | CreateBookingSuccess
    | CreateBookingFail
    | UpdateBooking
    | UpdateBookingSuccess
    | UpdateBookingFail
    | UnavailableSlotBooking;