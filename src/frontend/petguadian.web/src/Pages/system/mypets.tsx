import { PetCard } from "../../Components/PetCard";
import { v4 as uuidv4 } from 'uuid';
import PetForm from "../../Components/PetForm";
import { AnimalSpecies } from "../../Enums/AnimalSpecies";
import { Pet } from "../../Models/Pet";
import './mypets.css'
import { TOKEN_KEY, getEmail, getToken } from "../../Services/auth";
import { IdentiTyApi } from '../../Services/identityApi';
import { petGuardianApi } from '../../Services/petGuardianApi';
import { useEffect, useState } from "react";





interface JWTParts {
  header: any;
  payload: any;
}

function formatarJWT(jwt: string): JWTParts {
  const partes = jwt.split('.');

  if (partes.length !== 3) {
    throw new Error('Formato JWT inválido');
  }

  const [headerBase64, payloadBase64] = partes;

  const header = JSON.parse(atob(headerBase64));
  const payload = JSON.parse(atob(payloadBase64));

  return { header, payload };
}

export function MyPets() {
  const [pets, setPets] = useState<any>([]);


  //TROCAR PARA COOKIES DEPOIS - EXISTE UMA OPÇÃO PARA O COOKIE VENCER CONFORME O TEMPO DE EXPIRAÇÃO DEFINIDO NA API
  var token = getToken();

  if (!token) {
    token = ''
  }
  const decodedToken = JSON.parse(atob(token.split('.')[1]));
  var userId = decodedToken.id
  var email = decodedToken.email

  useEffect(() => {
    const fetchPets = async () => {
      const petResponse = await petGuardianApi.get(`/Pet/get_pet_by_userId?userId=${userId}`)
      console.log("Pet Reponse " + petResponse.data[0].petName)
      setPets(petResponse.data)
    }
    fetchPets()
  }, []);
   

  //DEVO COLOCAR OS DEMAIS ATRIBUTOS NOS PETS COMO MEDICINE
  //petName: 'Luci', gender: 'F', specie: 1, birthDate: '2023-11-27T23:37:39.13', age: 0, …}
  // age : 0

  // birthDate : "2023-11-27T23:37:39.13"
  // gender : "F"
  // medicines : []
  // petName : "Luci"
  // specie 1
  // weight : 14
  console.log(pets[0]);



  const simulatedPets: Pet[] = [
    new Pet(uuidv4(), 'Max', 'M', AnimalSpecies.Dog, new Date('2020-01-15'), 12.5, 'User1'),
    new Pet(uuidv4(), 'Bella', 'F', AnimalSpecies.Cat, new Date('2019-05-03'), 8.2, 'User2'),
    new Pet(uuidv4(), 'Charlie', 'M', AnimalSpecies.Dog, new Date('2021-02-20'), 15.8, 'User3'),
    new Pet(uuidv4(), 'Lucy', 'F', AnimalSpecies.Cat, new Date('2020-10-10'), 7.3, 'User1'),
    new Pet(uuidv4(), 'Cooper', 'M', AnimalSpecies.Dog, new Date('2018-12-08'), 20.0, 'User4'),
    new Pet(uuidv4(), 'Luna', 'F', AnimalSpecies.Cat, new Date('2019-08-25'), 9.5, 'User2'),
    new Pet(uuidv4(), 'Lana', 'F', AnimalSpecies.Cat, new Date('2020-10-10'), 7.3, 'User1'),
    new Pet(uuidv4(), 'Mark', 'M', AnimalSpecies.Dog, new Date('2018-12-08'), 20.0, 'User4'),
    new Pet(uuidv4(), 'Jack', 'F', AnimalSpecies.Cat, new Date('2019-08-25'), 9.5, 'User2'),
  ];

  //FUNÇÃO GETALL TERMINA AQUI

  return (
    <>
    <div className="mypets-container">

      <div className="pet-container">
        <h1>Confira seus Pets Aqui</h1>
        <section className="pets-cards">
          <PetCard petList={simulatedPets} />
        </section>
        <div className="addpet">
          <h2>Adicione o Pet</h2>

          <PetForm />
        </div>

      </div>
    </div>
    </>
  )
}