import { fetchBookings } from "../api/bookingApi";
import { all, call, put, takeLatest } from "redux-saga/effects";
import { Booking } from "../domain/Booking";

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

export default function* () {
    yield all([
        takeLatest("FETCH_BOOKINGS", getBookings)
    ]);
}