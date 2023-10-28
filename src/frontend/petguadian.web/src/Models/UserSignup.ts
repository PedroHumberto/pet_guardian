import { Pet } from "../Models/Pet";
import { Address } from "../Models/Address";

export class UserSingup
{
    public id: string;
    public email: string;
    public password: string;

    constructor(id: string, email: string, password: string)
    {
        this.id = id;
        this.email = email;
        this.password = password;

    }

}