import { fetchUsers } from "../api/userApi";
import { all, call, put, takeLatest } from "redux-saga/effects";
import { User } from "../domain/User";

export function* getUsers() {
    try {
        const users: User[] = yield call(fetchUsers);
        yield put({
            type: "FETCH_USERS_SUCCESS",
            payload: users
        });
    } catch (e) {
        yield put({
            type: "FETCH_USERS_FAIL"
        });
    }
}

export default function* () {
    yield all([
        takeLatest("FETCH_USERS", getUsers)
    ]);
}