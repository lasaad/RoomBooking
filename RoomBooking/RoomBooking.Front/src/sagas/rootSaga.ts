import room from "./roomSaga";
import user from "./userSaga";
import booking from "./bookingSaga";

const sagas = [
    room, user, booking
];

export const initSagas = (sagaMiddleware: any) =>
    sagas.forEach(sagaMiddleware.run.bind(sagaMiddleware)); 