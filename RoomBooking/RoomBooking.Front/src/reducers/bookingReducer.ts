import { BookingAction } from "../actions/bookingActions";
import { Reducer } from "redux";
import BookingState from "../states/BookingState";

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