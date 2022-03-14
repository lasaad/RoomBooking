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

export type FetchUser = {
    type: "FETCH_USER";
    payload: number
};

type FetchUserSuccess = {
    type: "FETCH_USER_SUCCESS";
    payload: User;
};

type FetchUserFail = {
    type: "FETCH_USER_FAIL";
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

type OpenUserEditor = {
    type: "OPEN_USER_EDITOR";
};

export type UpdateUser = {
    type: "UPDATE_USER";
    payload: User;
};

type UpdateUserSuccess = {
    type: "UPDATE_USER_SUCCESS";
    payload: number;
};

type UpdateUserFail = {
    type: "UPDATE_USER_FAIL";
};

export type UserAction =
    FetchUsers
    | FetchUsersSuccess
    | FetchUsersFail
    | FetchUser
    | FetchUserSuccess
    | FetchUserFail
    | OpenUserEditor
    | CreateUser
    | CreateUserSuccess
    | CreateUserFail
    | UpdateUser
    | UpdateUserSuccess
    | UpdateUserFail;