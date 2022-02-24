import { Provider } from "react-redux";
import "./App.css";
import { store } from "./app/store";
import Rooms from "./components/Rooms";
import Users from "./components/Users";

function App() {
  return (
    <div className="App">
      <Provider store={store}>
        <Rooms />
        <Users />
      </Provider>
    </div>
  );
}

export default App;
