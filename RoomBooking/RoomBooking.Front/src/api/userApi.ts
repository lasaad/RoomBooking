import client from "../api";
import { User } from "../domain/User";

export const fetchUsers = async (): Promise<User[]> => {
    const response = await client.get("/Users");
    return response.data.users.map((r: any) => ({
        id: r.id,
        firstName: r.firstName,
        lastName: r.lastName
    }));
};
