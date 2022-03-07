import React, { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { RootState } from "../app/store";

const Users: React.FC = () => {
    const dispatch = useDispatch();
     
    useEffect(() => {
        dispatch({ type: "FETCH_USERS" });
    }, []);

    const users = useSelector((state: RootState) => state.user.users);

    if (!users) {
        return <></>;
    }

    return <div>
        {users.map((r) =>
            <div key={r.id} className="room-item">
                <button onClick={() => dispatch({ type: "FETCH_USER", payload: { id: r.id } })}>{r.id}</button> - {r.firstName} - {r.lastName}
            </div>)
        }
    </div>
};

export default Users;