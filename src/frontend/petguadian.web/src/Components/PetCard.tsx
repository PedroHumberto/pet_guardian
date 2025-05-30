import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { format } from 'date-fns';
import { AnimalSpecies } from '../Enums/AnimalSpecies';
import './css/petcard.css'
import { Pet } from '../Models/Pet';

interface PetCardProps {
    petList: Pet[]
}

export function PetCard({ petList }: PetCardProps) {
    const navigate = useNavigate();

    const getGenderLabel = (gender: string) => {
        return gender === 'F' ? 'Fêmea' : 'Macho';
    };
    const handleCardClick = (petId: string) => {
        console.log(petId)
        // Aqui você pode redirecionar para o componente desejado, por exemplo, "/pet-details"
        navigate(`/pet-details/${petId}`);
    };

    const getSpeciesLabel = (species: AnimalSpecies) => {
        switch (species) {
            case AnimalSpecies.Dog:
                return 'Cachorro';
            case AnimalSpecies.Cat:
                return 'Gato';
            case AnimalSpecies.Bird:
                return 'Ave';
            // Adicione mais casos conforme necessário
            default:
                return 'Desconhecido';
        }
    };



    return (
        <>
            {petList.map((pet, index) => (
                <div 
                    className="petContainer" 
                    key={index}
                    onClick={() => handleCardClick(pet.id)}>
                    <h2 className='petName'>{pet.petName}</h2>

                    <div className="petImage">
                        
                    </div>
                        <h3>Idade: {Number(pet.age)}</h3>
                    <div className="petData">
                        <div>
                            <h3>ESPECIE:</h3>
                            <a>{getSpeciesLabel(pet.specie)}</a>

                            <h3>DATA DE NASCIMENTO:</h3>
                            <a>{format(new Date(pet.birthDate), 'dd/MM/yyyy')}</a>

                            <h3>SEXO:</h3>
                            <a>{getGenderLabel(pet.gender)}</a>

                            <h3>PESO:</h3>
                            <a>{Number(pet.weight)}Kg</a>
                        </div>
                    </div>
                </div>
            ))}
        </>
    );
}