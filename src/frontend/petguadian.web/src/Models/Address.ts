import { User } from "../Models/User";

export class Address
{
    public street: String;
    public number: String;
    public complement: String;
    public neighborhood: String;
    public city:String; 
    public state:String; 
    public postalCode:String;
    public user:User;
    
    constructor(street:String,
        number:String,
        complement:String,
        neighborhood:String,
        city:String,
        state:String,
        postalCode:String,
        user:User)
        {
            this.street = street;
            this.number = number;
            this.complement = complement;
            this.neighborhood = neighborhood;
            this.city = city;
            this.state = state;
            this.postalCode = postalCode;
            this.user = user;

        }

}