import * as _ from "lodash";
import { UserAction } from "../actions/userActions";
import { Reducer } from "redux";
import UserState from "../states/UserState";

const initialState: UserState = {
    users: [],
    isOpen: false,
    isLoading: false,
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
        case "FETCH_USER":
            return {
                ...state,
                isLoading: true,
                currentUser: {
                    id: action.payload,
                    firstName: "",
                    lastName: ""
                }
            };
        case "FETCH_USER_SUCCESS":
            return {
                ...state,
                isOpen: true,
                isLoading: false,
                currentUser: action.payload
            };
        case "OPEN_USER_EDITOR":
                return {
                    ...state,
                    currentRoom: undefined,
                    isOpen: true
                };
        case "CREATE_USER":
        case "UPDATE_USER":
            return {
                ...state,
                isLoading: true,
                currentUser: action.payload
            };
        case "CREATE_USER_SUCCESS":
        case "UPDATE_USER_SUCCESS":
            return {
                ...state,
                isOpen: false,
                isLoading: false,
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