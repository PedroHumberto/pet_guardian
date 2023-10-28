import { Pet } from "../Models/Pet";
import { Address } from "../Models/Address";

export class User 
{
    public name: string;
    public email: string;
    public password: string;
    public pets: Pet[] | null;
    public address: Address | null;
    public deleted: boolean;

    constructor(name: string, email: string, password: string)
    {
        this.name = name;
        this.email = email;
        this.password = password;
        this.pets = null;
        this.address = null;
        this.deleted = false;
    }

}