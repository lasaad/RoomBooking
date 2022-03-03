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

export type CreateUser = {
    type: "CREATE_USER";
    payload: User;
};

type CreateUserSuccess = {
    type: "CREATE_USER_SUCCESS";
    payload: number;
};

type CreateUserFail = {
    type: "CREATE_USER_FAIL";
};

export type UserAction =
    FetchUsers
    | FetchUsersSuccess
    | FetchUsersFail
    | CreateUser
    | CreateUserSuccess
    | CreateUserFail;