import { RoomAction } from "../actions/roomActions";
import { Reducer } from "redux";
import { Room } from "../domain/Room";

export interface RoomState {
    rooms: Room[];
}

const initialState: RoomState = {
    rooms: []
};

export const roomReducer: Reducer<RoomState, RoomAction> = (
    state = initialState,
    action
) => {
    switch (action.type) {
        case "FETCH_ROOMS_SUCCESS":
            // state.rooms = action.payload;
            // return state;
            return {
                ...state,
                rooms: action.payload
            };
        default:
            return state;
    }
};