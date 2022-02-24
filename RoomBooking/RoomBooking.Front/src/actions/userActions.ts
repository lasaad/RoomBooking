import { User } from "../domain/User";

type FetchUsers = {
    type: "FETCH_USERS";
};

type FetchUsersSuccess = {
    type: "FETCH_USERS_SUCCESS";
    payload: User[];
};

type FetchUsersFail = {
    type: "FETCH_USERS_FAIL";
};

export const fetchUsers = (): FetchUsers => ({
    type: "FETCH_USERS"
});

export type UserAction =
    FetchUsers
    | FetchUsersSuccess
    | FetchUsersFail;