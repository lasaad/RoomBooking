import { Link } from "react-router-dom";
import { fetchBookings } from "../api/bookingApi";

export default function Invoices() {
  let bookings = fetchBookings();

  return <main style={{ padding: "1rem 0" }}>
    <h2>Réservations</h2>
    {    
        bookings.then(function (ids) {
        ids.map((booking) => (

          <div> {booking.roomId} : {booking.startSlot} - {booking.endSlot}</div>
        ))
      })
    }
  </main>
}