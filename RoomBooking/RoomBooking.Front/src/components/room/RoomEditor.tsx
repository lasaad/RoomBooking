import React, { useEffect } from "react";
import _ from "lodash";
import { useDispatch, useSelector } from "react-redux";
import { RootState } from "../../app/store";

const RoomEditor: React.FC = () => {
    const dispatch = useDispatch();
    const currentRoom = useSelector((state: RootState) => state.room.currentRoom);

    const currentRoomId = _.isNil(currentRoom) ? 0 : currentRoom.id;
    const currentRoomName = _.isNil(currentRoom) ? "" : currentRoom.name;

    const [id, setId] = React.useState(currentRoomId);
    const [name, setName] = React.useState(currentRoomName);

    useEffect(() => {
        setId(currentRoomId);
        setName(currentRoomName);
    }, [currentRoom]);

    const saveRoom = () => {
        if (id === 0) {
            dispatch({ type: "CREATE_ROOM", payload: { name } });
        } else {
            dispatch({ type: "UPDATE_ROOM", payload: { id, name } });
        }
    };

    const roomStyle = {
        height: "100px",
        width: "800px",
        margin: "5px auto",
        border: "solid 1px"
    };

    return <div style={roomStyle}>
        <div>
            <input type="text" value={name} onChange={(e) => setName(e.target.value)} />
        </div>
        <div>
            <button onClick={saveRoom}>Save</button>
        </div>
    </div>;
};

export default RoomEditor;