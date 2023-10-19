import { AnimalSpecies } from "../Enums/AnimalSpecies";
import { User } from "../Models/User";

export class Pet
{
    public petName: String;
    public gender: String;
    public animalSpecies: AnimalSpecies;
    public birthDate: Date;
    public weight: Number | null;
    public user: User;
    public petExams: PetExams | null

    constructor(petName: String, 
        gender: String, 
        animalSpecies: AnimalSpecies, 
        birthDate: Date,
        user: User)
        {
            this.petName = petName;
            this.gender = gender;
            this.animalSpecies = animalSpecies;
            this.birthDate = birthDate;
            this.weight = null;
            this.user = user
            this.petExams = null;
        }
     
}