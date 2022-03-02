import { BookingAction } from "../actions/bookingActions";
import { Reducer } from "redux";
import { Booking } from "../domain/Booking";

export interface BookingState {
    bookings: Booking[];
}

const initialState: BookingState = {
    bookings: []
};

export const bookingReducer: Reducer<BookingState, BookingAction> = (
    state = initialState,
    action
) => {
    switch (action.type) {
        case "FETCH_BOOKINGS_SUCCESS":
            return {
                ...state,
                bookings: action.payload
            };
        // case "FETCH_BOOKINGS_FAIL":
        //         return {
        //            ...state,
        //            bookings: action.payload
        //        };
        default:
            return state;
    }
};