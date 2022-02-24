import { UserAction } from "../actions/userActions";
import { Reducer } from "redux";
import { User } from "../domain/User";

export interface UserState {
    users: User[];
}

const initialState: UserState = {
    users: []
};

export const userReducer: Reducer<UserState, UserAction> = (
    state = initialState,
    action
) => {
    switch (action.type) {
        case "FETCH_USERS_SUCCESS":
            return {
                ...state,
                users: action.payload
            };
        default:
            return state;
    }
};