import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Room from './components/room/Room';
import Booking from './components/booking/Booking';
import User from './components/user/User';

ReactDOM.render(
  <BrowserRouter>
    <Routes>
    <Route path="/" element={<App />}>
        <Route path="room" element={<Room />} />
        <Route path="user" element={<User />} />
        <Route path="booking" element={<Booking />} />
      </Route>
    </Routes>
  </BrowserRouter>,
  document.getElementById('root')
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
