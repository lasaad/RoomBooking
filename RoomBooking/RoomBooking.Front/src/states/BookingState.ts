import { Booking } from "../domain/Booking";

export default interface BookingState {
    bookings: Booking[];
    currentBooking: Booking | undefined;
    isOpen: boolean;
    isLoading: boolean;
    availableHours: number[] | undefined;
}
