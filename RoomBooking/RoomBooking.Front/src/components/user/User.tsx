import * as React from "react";
import { useSelector } from "react-redux";
import { RootState } from "../../app/store";
import Loading from "../shared/Loading";
import UserEditor from "./UserEditor";
import Users from "./Users";

const User: React.FC = () => {
    const isOpen = useSelector((state: RootState) => state.user.isOpen);
    const isLoading = useSelector((state: RootState) => state.user.isLoading);

    return <div>
        <Users />
        {isLoading && <Loading />}
        {isOpen && <UserEditor />}
    </div>;
};

export default User;