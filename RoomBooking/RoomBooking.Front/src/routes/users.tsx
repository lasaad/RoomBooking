import { Link } from "react-router-dom";
import { fetchUsers } from "../api/userApi";

export default function Invoices() {
  let users = fetchUsers();

  return <main style={{ padding: "1rem 0" }}>
    <h2>Users </h2>
    {
      users.then(function (ids) {
        ids.map((user) => (
          <div> {user.firstName} {user.lastName}</div>
        ))
      })
    }
  </main>
}