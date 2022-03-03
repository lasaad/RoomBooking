import * as _ from "lodash";
import { UserAction } from "../actions/userActions";
import { Reducer } from "redux";
import { User } from "../domain/User";

export interface UserState {
    users: User[];
    currentUser: User | undefined;
}

const initialState: UserState = {
    users: [],
    currentUser: undefined
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
        case "CREATE_USER":
            return {
                ...state,
                currentUser: action.payload
            };
        case "CREATE_USER_SUCCESS":
            return {
                ...state,
                currentUser: {
                    id: action.payload,
                    firstName: _.isNil(state.currentUser) ? "" : state.currentUser.firstName,
                    lastName: _.isNil(state.currentUser) ? "" : state.currentUser.lastName
                }
            };
        default:
            return state;
    }
};