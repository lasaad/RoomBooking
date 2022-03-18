import * as _ from "lodash";
import { BookingAction } from "../actions/bookingActions";
import { Reducer } from "redux";
import BookingState from "../states/BookingState";

const initialState: BookingState = {
    bookings: [],
    currentBooking: undefined,
    isOpen: false,
    isLoading: false,
    availableHours: undefined
};

export const bookingReducer: Reducer<BookingState, BookingAction> = (
    state = initialState,
    action
) => {
    switch (action.type) {
        case "FETCH_BOOKINGS_SUCCESS":
            return {
                ...state,
                isOpen: false,
                isLoading: false,
                bookings: action.payload
            };
        case "FETCH_BOOKING_SUCCESS":
            return {
                ...state,
                isOpen: true,
                isLoading: false,
                currentBooking: action.payload
            };
        case "CREATE_BOOKING":
            return {
                ...state,
                isOpen: false,
                isLoading: false,
                currentUser: action.payload
            };
        case "OPEN_BOOKING_EDITOR":
                return {
                    ...state,
                    currentRoom: undefined,
                    isOpen: true
                };
        case "CREATE_BOOKING_SUCCESS":
            return {
                ...state,
                isOpen: false,
                isLoading: false,
                currentUser: {
                    id: action.payload,
                    date: _.isNil(state.currentBooking) ? "" : state.currentBooking.date,
                    startSlot: _.isNil(state.currentBooking) ? "" : state.currentBooking.startSlot,
                    endSlot: _.isNil(state.currentBooking) ? "" : state.currentBooking.endSlot,
                    roomId: _.isNil(state.currentBooking) ? "" : state.currentBooking.roomId,
                    userId: _.isNil(state.currentBooking) ? "" : state.currentBooking.userId,
                }
            };
        case "CREATE_BOOKING":
        case "UPDATE_BOOKING_SUCCESS":
        default:
            return state;
    }
};