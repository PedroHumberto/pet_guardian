import { useState } from 'react';
import { AnimalSpecies } from '../Enums/AnimalSpecies';
import './css/petcard.css'

export function PetCard()
{
    const [petData, setPetData] = useState({
        petName: 'Luci',
        gender: 'F',
        animalSpecies: AnimalSpecies.Dog,
        birthDate: '10/05/2023',
        weight: 15.32
      });
      
    return(
        <>
            <div className="petContainer">
                <h2 className='petName'>{petData.petName}</h2>

                <div className="petImage">
                    <h1>Imagem</h1>
                </div>
                
                <div className="petData">
                    <div>
                        <h3>RAÇA:</h3>
                        <a>Vira Lata</a>

                        <h3>DATA DE NASCIMENTO:</h3>
                        <a>{petData.birthDate}</a>

                        <h3>SEXO:</h3>                                                
                        <a>Feminino</a>

                        <h3>PESO:</h3>
                        <a>{petData.weight}Kg</a>
                    </div>
                </div>
            </div>
        </>
    )
}