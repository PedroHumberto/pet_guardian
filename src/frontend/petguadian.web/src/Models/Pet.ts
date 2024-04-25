import { AnimalSpecies } from "../Enums/AnimalSpecies";

export class Pet
{
    public id : string;
    public petName?: string;
    public gender: string;
    public specie: AnimalSpecies;
    public birthDate: Date;
    public age: Number;
    public weight: Number | null;
    public user: string;

    constructor(
        petId: string,
        petName: string, 
        gender: string, 
        specie: AnimalSpecies, 
        birthDate: Date,
        age: Number,
        weight: Number,
        user: string)
        {
            this.id = petId
            this.petName = petName;
            this.gender = gender;
            this.specie = specie;
            this.birthDate = birthDate;
            this.age = age;
            this.weight = weight;
            this.user = user;
        }
     
}