import { Pet } from "../Models/Pet";
import { Address } from "../Models/Address";

export class UserLogin
{
    public email: string;
    public password: string;

    constructor(email: string, password: string)
    {
        this.email = email;
        this.password = password;
    }

}