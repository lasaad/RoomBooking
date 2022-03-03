import { fetchUsers, postUser } from "../api/userApi";
import { all, call, put, takeLatest } from "redux-saga/effects";
import { User } from "../domain/User";
import { CreateUser } from "../actions/userActions";

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

export function* createUser(action: CreateUser) {
    try {
        const idUser: number = yield call(postUser, action.payload);
        yield put({
            type: "CREATE_USER_SUCCESS",
            payload: idUser
        });
    } catch (e) {
        yield put({
            type: "CREATE_USER_FAIL"
        });
    }
}

export default function* () {
    yield all([
        takeLatest("FETCH_USERS", getUsers),
        takeLatest("CREATE_USER", createUser)
    ]);
}