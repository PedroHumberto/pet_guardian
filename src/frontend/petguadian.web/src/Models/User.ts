import { Pet } from "../Models/Pet";
import { Address } from "../Models/Address";

export class User 
{
    public name: string;
    public email: string;
    public password: string;
    public deleted: boolean;
    public addressId: string;

    constructor(name: string, email: string, password: string, addressId: string)
    {
        this.name = name;
        this.email = email;
        this.password = password;
        this.addressId = addressId;
        this.deleted = false;
    }
}