import { Provider } from "react-redux";
import "./App.css";
import { store } from "./app/store";
import { Outlet, Link } from "react-router-dom";

function App() {
  return (
    <div className="App">
      <Provider store={store}>
        <nav
          style={{
            borderBottom: "solid 1px",
            paddingBottom: "1rem",
          }}
        >
          <Link to="/user">Users</Link> 
          |{" "}
          <Link to="/room">Rooms</Link>
          |{" "}
          <Link to="/booking">Bookings</Link> 
        </nav>
        <Outlet />
      </Provider>
    </div>
    
  );
}

export default App;
