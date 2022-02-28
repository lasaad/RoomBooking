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
          <Link to="/users">Users</Link> |{" "}
          <Link to="/rooms">Rooms</Link>
        </nav>
        <Outlet />
      </Provider>
    </div>
    
  );
}

export default App;
