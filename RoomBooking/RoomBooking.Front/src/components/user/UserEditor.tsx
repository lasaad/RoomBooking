import React, { useEffect } from "react";
import _ from "lodash";
import { useDispatch, useSelector } from "react-redux";
import { RootState } from "../../app/store";

const UserEditor: React.FC = () => {
    const dispatch = useDispatch();
    const currentUser = useSelector((state: RootState) => state.user.currentUser);

    const currentUserId = _.isNil(currentUser) ? 0 : currentUser.id;
    const currentUserFirstName = _.isNil(currentUser) ? "" : currentUser.firstName;
    const currentUserLastName = _.isNil(currentUser) ? "" : currentUser.lastName;

    const [id, setId] = React.useState(currentUserId)
    const [lastName, setLastName] = React.useState(currentUserLastName);
    const [firstName, setFirstName] = React.useState(currentUserFirstName);

    useEffect(() => {
        setId(currentUserId);
        setFirstName(currentUserFirstName);
        setLastName(currentUserLastName);
    }, [currentUser]);

    const saveUser = () => {
        if (id === 0) {
            dispatch({ type: "CREATE_USER", payload: { id, firstName, lastName } });
        } else {
            dispatch({ type: "UPDATE_USER", payload: { id, firstName, lastName } });
        }
    };

    const userStyle = {
        height: "100px",
        width: "800px",
        margin: "5px auto",
        border: "solid 1px"
    };

    return <div style={userStyle}>
        <div>
            <input type="text" value={firstName} onChange={(e) => setFirstName(e.target.value)} />
        </div>
        <div>
            <input type="text" value={lastName} onChange={(e) => setLastName(e.target.value)} />
        </div>
        <div>
            <button onClick={saveUser}>Save</button>
        </div>
    </div>;
};

export default UserEditor;