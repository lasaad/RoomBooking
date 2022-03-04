import { fetchBookings, postBooking } from "../api/bookingApi";
import { all, call, put, takeLatest } from "redux-saga/effects";
import { Booking } from "../domain/Booking";
import { CreateBooking } from "../actions/bookingActions";

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

export function* createBooking(action: CreateBooking) {
    try {
        const idBooking: number = yield call(postBooking, action.payload);
        yield put({
            type: "CREATE_USER_SUCCESS",
            payload: idBooking
        });
    } catch (e) {
        yield put({
            type: "CREATE_BOOKING_FAIL"
        });
    }
}

export default function* () {
    yield all([
        takeLatest("FETCH_BOOKINGS", getBookings),
        takeLatest("CREATE_BOOKING", createBooking)
    ]);
}