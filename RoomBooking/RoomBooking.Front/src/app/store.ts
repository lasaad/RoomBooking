import { createStore, combineReducers, applyMiddleware } from "redux";
import { composeWithDevTools } from "redux-devtools-extension";
import createSagaMiddleware from "redux-saga"
import { roomReducer } from "../reducers/roomReducer";
import { userReducer } from "../reducers/userReducer";
import { bookingReducer } from "../reducers/bookingReducer";
import { BookingAction } from "../actions/bookingActions";
import { initSagas } from "../sagas/rootSaga"
import RoomState from "../states/RoomState";
import UserState from "../states/UserState";
import BookingState from "../states/BookingState";

export interface RootState {
    readonly room: RoomState;
    readonly user: UserState;
    readonly booking: BookingState;
}

const rootReducer = combineReducers<RootState>({
    room: roomReducer,
    user: userReducer,
    booking: bookingReducer

});

// export type RootActions = RoomAction;
export type RootActions = BookingAction;

const sagaMiddleware = createSagaMiddleware();

const configureStore = (): any => {
    const store = createStore(
        rootReducer,
        composeWithDevTools(
            applyMiddleware(sagaMiddleware)
        )
    );
    initSagas(sagaMiddleware);
    return store;
};

export const store = configureStore();