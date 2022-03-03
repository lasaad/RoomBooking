import * as React from "react";
import { useDispatch } from "react-redux";

interface UserProps {
}

const User: React.FC<UserProps> = () => {
    const dispatch = useDispatch();
    const [firstName, setFirstName] = React.useState("");
    const [lastName, setLastName] = React.useState("");

    return <>
        <div>
            First name
        </div>
        <div>
            <input type="text" value={firstName} onChange={(e) => setFirstName(e.target.value)} />
        </div>
        <div>
            Last name
        </div>
        <div>
            <input type="text" value={lastName} onChange={(e) => setLastName(e.target.value)} />
        </div>
        <div>
            <button onClick={() => dispatch({ type: "CREATE_USER", payload: { firstName, lastName} })}>Save</button>
        </div>
    </>;
};

export default User;