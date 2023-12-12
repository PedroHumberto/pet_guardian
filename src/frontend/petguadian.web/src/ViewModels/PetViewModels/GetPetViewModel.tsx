import { AnimalSpecies } from "../../Enums/AnimalSpecies";

export class GetPetViewModel
{
    public petName?: string;
    public gender: string;
    public animalSpecies: AnimalSpecies;
    public birthDate: Date;
    public age: Number;
    public weight: Number | null;
    public user: string;

    constructor(
        petName: string, 
        gender: string, 
        animalSpecies: AnimalSpecies, 
        birthDate: Date,
        age: Number,
        weight: Number,
        user: string)
        {
            this.petName = petName;
            this.gender = gender;
            this.animalSpecies = animalSpecies;
            this.birthDate = birthDate;
            this.age = age;
            this.weight = weight;
            this.user = user;
        }
}