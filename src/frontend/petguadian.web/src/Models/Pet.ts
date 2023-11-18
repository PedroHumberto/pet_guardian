import { AnimalSpecies } from "../Enums/AnimalSpecies";

export class Pet
{
    public petName?: string;
    public gender: string;
    public animalSpecies: AnimalSpecies;
    public birthDate: Date;
    public weight: Number | null;
    public user: string;

    constructor(petName: string, 
        gender: string, 
        animalSpecies: AnimalSpecies, 
        birthDate: Date,
        weight: Number,
        user: string)
        {
            this.petName = petName;
            this.gender = gender;
            this.animalSpecies = animalSpecies;
            this.birthDate = birthDate;
            this.weight = weight;
            this.user = user;
        }
     
}