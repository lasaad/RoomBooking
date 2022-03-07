import { User } from "../domain/User";

export default interface UserState {
    users: User[];
    isOpen: boolean;
    isLoading: boolean;
    currentUser: User | undefined;
}