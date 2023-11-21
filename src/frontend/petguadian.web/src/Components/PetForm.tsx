import { useEffect, useState } from "react"
import { v4 as uuidv4 } from 'uuid';
import { Pet } from "../Models/Pet"
import { AnimalSpecies } from '../Enums/AnimalSpecies';
import './css/petform.css'
import { CreatePetViewModel } from "../ViewModels/PetViewModels/CreatePetViewModel";

export interface AnimalSpeciesMapping {
  [key: string]: AnimalSpecies;
}

export const animalSpeciesMap: AnimalSpeciesMapping = {
  Cachorro: AnimalSpecies.Dog,
  Gato: AnimalSpecies.Cat,
  Passaro: AnimalSpecies.Bird,
  Peixe: AnimalSpecies.Fish,
  Roedor: AnimalSpecies.Rodent,
  Reptil: AnimalSpecies.Reptile,
};

export function PetForm() {

  const [petData, setPetData] = useState({
    petName: '',
    gender: 'M',
    animalSpecies: AnimalSpecies.Dog,
    birthDate: '',
    weight: 0,
    user: ''
  });
  const [showModal, setShowModal] = useState(false)



  const handleInputChange = (e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>) => {
    const { name, value } = e.target;
    setPetData({ ...petData, [name]: value });
  };



  const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();

    // Crie uma instância da classe "CreatePetViewModel" com os dados do formulário
    const pet = new CreatePetViewModel(
      petData.petName,
      petData.gender,
      Number(petData.animalSpecies),
      new Date(petData.birthDate),
      Number(petData.weight),
      petData.user
    );
    //FORMATA PARA O DIA ATUAL NO BRASIL
    pet.birthDate.setDate(pet.birthDate.getDate()+ 1)

    // Faça algo com a instância, como enviar para o servidor ou armazenar localmente
    console.log(pet);
  };
  
  return (
    <>
      <button className="addPetButton" onClick={() => setShowModal(true)}>+</button>
      {showModal && (
        <>
          <div className="modal-background">
            <div className="modal">
              <h2>Cadastro de Pet</h2>
              <form onSubmit={handleSubmit}>
                <label>
                  Nome do Pet:
                  <input
                    type="text"
                    name="petName"
                    value={petData.petName}
                    onChange={handleInputChange}
                    required
                  />
                </label>
                <label>
                  Gênero:
                  <select
                    name="gender"
                    value={petData.gender}
                    onChange={handleInputChange}>
                    <option value="M">M</option>
                    <option value="F">F</option>
                  </select>
                </label>
                <label>
                  Espécie do Animal:
                  <select
                    name="animalSpecies"
                    value={petData.animalSpecies}
                    onChange={handleInputChange}
                  >
                    {Object.keys(animalSpeciesMap).map((species) => (
                      <option key={species} value={animalSpeciesMap[species]}>
                        {species}
                      </option>
                    ))}
                  </select>
                </label>
                <label>
                  Data de Nascimento:
                  <input
                    type="date"
                    name="birthDate"
                    value={petData.birthDate}
                    onChange={handleInputChange}
                    required
                  />
                </label>
                <label>
                  Peso em Kg:
                  <input
                    type="number"
                    name="weight"
                    value={petData.weight}
                    onChange={handleInputChange}
                  />
                </label>
                <div className="addAndCloseBtns">
                  <button type="submit">Cadastrar Pet</button>
                  <button onClick={() => setShowModal(false)}>Cancelar</button>
                </div>
              </form>
            </div>
          </div>
        </>
      )}
    </>
  );
}

export default PetForm;
