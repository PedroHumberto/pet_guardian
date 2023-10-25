import { AnimalSpecies } from "../Enums/AnimalSpecies";
import { User } from "../Models/User";
import { PetExams } from "../Models/PetExams";

export class Pet
{
    public petName?: String;
    public gender: String;
    public animalSpecies: AnimalSpecies;
    public birthDate: Date;
    public weight: Number | null;
    public user: String;
    public petExams: PetExams | null

    constructor(petName: String, 
        gender: String, 
        animalSpecies: AnimalSpecies, 
        birthDate: Date,
        weight: Number,
        user: String)
        {
            this.petName = petName;
            this.gender = gender;
            this.animalSpecies = animalSpecies;
            this.birthDate = birthDate;
            this.weight = weight;
            this.user = user
            this.petExams = null;
        }
     
}