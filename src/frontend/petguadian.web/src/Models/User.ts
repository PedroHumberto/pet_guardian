import { Pet } from "../Models/Pet";
import { Address } from "../Models/Address";

export class User 
{
    public name: string;
    public email: string;
    public cpf: string;
    public pets: Pet[] | null;
    public address: Address | null;
    public deleted: boolean;

    constructor(name: string, email: string, cpf: string)
    {
        this.name = name;
        this.email = email;
        this.cpf = cpf;
        this.pets = null;
        this.address = null;
        this.deleted = false;
    }

}