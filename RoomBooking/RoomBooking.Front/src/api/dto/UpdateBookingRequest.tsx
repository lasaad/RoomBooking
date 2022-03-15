export interface UpdateBookingRequest {
    id: number,
    roomId: number,
    userId: number,
    startSlot: number,
    endSlot: number,
    date: string
}