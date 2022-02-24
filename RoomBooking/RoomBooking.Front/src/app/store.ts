import { createStore, combineReducers, applyMiddleware } from "redux";
import { composeWithDevTools } from "redux-devtools-extension";
import createSagaMiddleware from "redux-saga"
import { roomReducer, RoomState } from "../reducers/roomReducer";
import { userReducer, UserState } from "../reducers/userReducer";

import { RoomAction } from "../actions/roomActions";
import { initSagas } from "../sagas/rootSaga"

export interface RootState {
    readonly room: RoomState;
    readonly user: UserState;
}

const rootReducer = combineReducers<RootState>({
    room: roomReducer,
    user: userReducer

});

export type RootActions = RoomAction;

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