import room from "./roomSaga";
import user from "./userSaga";

const sagas = [
    room, user
];

export const initSagas = (sagaMiddleware: any) =>
    sagas.forEach(sagaMiddleware.run.bind(sagaMiddleware));