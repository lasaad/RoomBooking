import client from "../api";
import { User } from "../domain/User";
import { UpdateUserRequest } from "./dto/UpdateUserRequest";

export const fetchUsers = async (): Promise<User[]> => {
    const response = await client.get("/Users");
    return response.data.users.map((r: any) => ({
        id: r.id,
        firstName: r.firstName,
        lastName: r.lastName
    }));
};

export const postUser = async (user: User): Promise<number> => {
    const response = await client.post("/Users", {
        ...user
    });
    return response.data;
};

export const fetchUser = async (id: number): Promise<User> => {
    const response = await client.get(`/Users/${id}`);
    return {
        id: response.data.id,
        firstName: response.data.firstName,
        lastName: response.data.lastName
    };
};

export const putUser = async (user: User): Promise<void> => {
    const request: UpdateUserRequest = {
        id: user.id,
        firstName: user.firstName,
        lastName: user.lastName
    };
    await client.put(`/Users`, request);
};