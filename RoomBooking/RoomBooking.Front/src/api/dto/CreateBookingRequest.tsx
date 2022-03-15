export interface CreateBookingRequest {
    id: number,
    roomId: number,
    userId: number,
    startSlot: number,
    endSlot: number,
    date: Date
}