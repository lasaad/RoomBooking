import { fetchBookings, postBooking, putBooking, fetchBooking } from "../api/bookingApi";
import { all, call, put, takeLatest } from "redux-saga/effects";
import { Booking } from "../domain/Booking";
import { CreateBooking, UpdateBooking, FetchBooking } from "../actions/bookingActions";
import { PostBookingResponse } from "../api/dto/PostBookingResponse";

export function* getBookings() {
    try {
        const bookings: Booking[] = yield call(fetchBookings);
        yield put({
            type: "FETCH_BOOKINGS_SUCCESS",
            payload: bookings
        });
    } catch (e) {
        yield put({
            type: "FETCH_BOOKINGS_FAIL"
        });
    }
}

export function* getBooking(action: FetchBooking) {
    try {
        const booking: Booking = yield call(fetchBooking, action.payload);
        yield put({
            type: "FETCH_BOOKING_SUCCESS",
            payload: booking
        });
    } catch (e) {
        yield put({
            type: "FETCH_BOOKING_FAIL"
        });
    }
}

export function* createBooking(action: CreateBooking) {
    try {
        const response: PostBookingResponse = yield call(postBooking, action.payload);

        if(response.isAvailable)
        {
            yield put(
                {
                type: "CREATE_BOOKING_SUCCESS",
                payload: response.isAvailable
            });
        }
        else if (!response.isAvailable)
        {
            yield put(
                {
                type: "UNAVAILABLE_SLOT",
                payload: response.availableHours
            });
        }

    } catch (e) {
        yield put({
            type: "CREATE_BOOKING_FAIL"
        });
    }
}

export function* updateBooking(action: UpdateBooking) {
    try {
        yield call(putBooking, action.payload);
        yield put({
            type: "UPDATE_BOOKING_SUCCESS"
        });
    } catch (e) {
        yield put({
            type: "UPDATE_BOOKING_FAIL"
        });
    }
}

export default function* () {
    yield all([
        takeLatest("FETCH_BOOKINGS", getBookings),
        takeLatest("FETCH_BOOKING", getBooking),
        takeLatest("CREATE_BOOKING", createBooking),
        takeLatest("UPDATE_BOOKING", updateBooking)
    ]);
}