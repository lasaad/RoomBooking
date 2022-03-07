import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Users from './components/Users';
import Bookings from './components/Bookings';
import User from './components/User';
import Room from './components/room/Room';

ReactDOM.render(
  <BrowserRouter>
    <Routes>
    <Route path="/" element={<App />}>
        <Route path="room" element={<Room />} />
        <Route path="users" element={<Users />} />
        <Route path="user" element={<User />} />
        <Route path="bookings" element={<Bookings />} />
      </Route>
    </Routes>
  </BrowserRouter>,
  document.getElementById('root')
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
