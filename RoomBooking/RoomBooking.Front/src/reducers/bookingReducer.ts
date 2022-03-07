import * as _ from "lodash";
import { BookingAction } from "../actions/bookingActions";
import { Reducer } from "redux";
import BookingState from "../states/BookingState";

const initialState: BookingState = {
    bookings: [],
    currentBooking: undefined
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
            case "CREATE_BOOKING":
                return {
                    ...state,
                    currentUser: action.payload
                };
            case "CREATE_BOOKING_SUCCESS":
                return {
                    ...state,
                    currentUser: {
                        id: action.payload,
                        date: _.isNil(state.currentBooking) ? "" : state.currentBooking.date,
                        startSlot: _.isNil(state.currentBooking) ? "" : state.currentBooking.startSlot,
                        endSlot: _.isNil(state.currentBooking) ? "" : state.currentBooking.endSlot,
                        roomId: _.isNil(state.currentBooking) ? "" : state.currentBooking.roomId,
                        userId: _.isNil(state.currentBooking) ? "" : state.currentBooking.userId,
                    }
                };
        default:
            return state;
    }
};