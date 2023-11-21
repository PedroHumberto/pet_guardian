export class CreateUserViewModel 
{
    public id: string;
    public name: string;
    public email: string;
    public deleted: boolean;
    public addressId: string;

    constructor(id: string, name: string, email: string, addressId: string)
    {
        this.id = id;
        this.name = name;
        this.email = email;
        this.addressId = addressId;
        this.deleted = false;
    }
}