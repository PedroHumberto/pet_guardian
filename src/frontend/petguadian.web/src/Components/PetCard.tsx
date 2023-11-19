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
        // Aqui você pode redirecionar para o componente desejado, por exemplo, "/pet-details"
        navigate(`/pet-details/${petId}`);
    };

    const getSpeciesLabel = (species: AnimalSpecies) => {
        switch (species) {
            case AnimalSpecies.Dog:
                return 'Cachorro';
            case AnimalSpecies.Cat:
                return 'Gato';
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
                    onClick={() => handleCardClick(pet.petId)}>
                    <h2 className='petName'>{pet.petName}</h2>

                    <div className="petImage">
                        <h1>Imagem</h1>
                    </div>

                    <div className="petData">
                        <div>
                            <h3>ESPECIE:</h3>
                            <a>{getSpeciesLabel(pet.animalSpecies)}</a>

                            <h3>DATA DE NASCIMENTO:</h3>
                            <a>{format(pet.birthDate, 'dd/MM/yyyy')}</a>

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