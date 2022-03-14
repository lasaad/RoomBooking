import React, { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { RootState } from "../../app/store";

const Users: React.FC = () => {
    const dispatch = useDispatch();
     
    useEffect(() => {
        dispatch({ type: "FETCH_USERS" });
    }, []);

    const users = useSelector((state: RootState) => state.user.users); // lis dans le store

    if (!users) {
        return <></>;
    }

    const userStyle = {
        height: "300px",
        width: "800px",
        margin: "5px auto",
        border: "solid 1px"
    };

    return <div style={userStyle}>
        {users.map((r) =>
            <div key={r.id} className="user-item">
                <button onClick={() => dispatch({ type: "FETCH_USER", payload: r.id })}>{r.id}</button> - {r.firstName} {r.lastName}
            </div>)
        }
        <div>
            <button onClick={() => dispatch({ type: "OPEN_USER_EDITOR" })}>New user</button>
        </div>
        <div>sjdfkj
        </div>
    </div>
};

export default Users;